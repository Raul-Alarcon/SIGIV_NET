using SIGIV.CLS.DTO;
using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    internal class MunicipiosCLS
    {
        public int id { get; set; }
        public string Municipio { get; set; }
        public int idDepartamento { get; set; }
        public int idPais { get; set; }

        public async static Task<List<MunicipiosDTO>> GetAllDTOAsync()
        {
            List<MunicipiosDTO> municipios = new List<MunicipiosDTO>();
            using (var db = new SIGIVEntities())
            {
                municipios = await (from municipio in db.Municipios
                                    join departamento in db.Departamentos on municipio.idDepartamento equals departamento.idDepartamento
                                    join pais in db.Paises on departamento.idPais equals pais.idPais
                                    select new MunicipiosDTO
                                    {
                                        id = municipio.idMunicipio,
                                        Municipio = municipio.Municipio,
                                        Departamento = departamento.Departamento,
                                        Pais = pais.Pais
                                    }).ToListAsync();
            }
            return municipios;
        }

        public static async Task<MunicipiosCLS> GetByIdAsync(int id)
        {
            MunicipiosCLS municipio = new MunicipiosCLS();
            using (var db = new SIGIVEntities())
            {
                Municipios mun = await db.Municipios.Where(x => x.idMunicipio == id).FirstOrDefaultAsync();
                municipio.id = mun.idMunicipio;
                municipio.Municipio = mun.Municipio;
                municipio.idDepartamento = mun.idDepartamento;
            }
            return municipio;
        }

        public async Task<bool> SaveAsync()
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                Municipios municipio = new Municipios
                {
                    Municipio = Municipio,
                    idDepartamento = idDepartamento
                };
                db.Municipios.Add(municipio);
                int result = await db.SaveChangesAsync();
                success = result > 0;
            }
            return success;
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                Municipios municipio = db.Municipios.Where(x => x.idMunicipio == id).FirstOrDefault();
                municipio.Municipio = Municipio;
                municipio.idDepartamento = idDepartamento;
                db.Entry(municipio).State = EntityState.Modified;
                int result = await db.SaveChangesAsync();
                success = result > 0;
            }
            return success;
        }

        public async Task<bool> DeleteAsync()
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                Municipios municipio = db.Municipios.Where(x => x.idMunicipio == id).FirstOrDefault();
                db.Municipios.Remove(municipio);
                int result = await db.SaveChangesAsync();
                success = result > 0;
            }
            return success;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Municipio)) throw new ArgumentException("El campo Municipio es requerido");
            if (idDepartamento <= 0) throw new ArgumentException("El campo Departamento es requerido");
        }
    }
}
