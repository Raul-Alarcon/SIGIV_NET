using SIGIV.CLS.DTO;
using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    internal class DistritosCLS
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int idMunicipio { get; set; }
        public int idDepartamento { get; set; }
        public int idPais { get; set; }

        public async static Task<List<DistritosDTO>> GetAllDTOAsync()
        {
            List<DistritosDTO> distritos = new List<DistritosDTO>();
            using (var db = new SIGIVEntities())
            {
                distritos = await (from distrito in db.Distritos
                                   join municipio in db.Municipios on distrito.idMunicipio equals municipio.idMunicipio
                                   join departamento in db.Departamentos on municipio.idDepartamento equals departamento.idDepartamento
                                   join pais in db.Paises on departamento.idPais equals pais.idPais
                                   select new DistritosDTO
                                   {
                                       ID = distrito.idDistrito,
                                       Distrito = distrito.Distrito,
                                       Municipio = municipio.Municipio,
                                       Departamento = departamento.Departamento,
                                       Pais = pais.Pais
                                   }).ToListAsync();
            }
            return distritos;
        }

        public static async Task<DistritosCLS> GetByIdAsync(int id)
        {
            DistritosCLS distrito = new DistritosCLS();
            using (var db = new SIGIVEntities())
            {
                Distritos dis = await db.Distritos.Where(x => x.idDistrito == id).FirstOrDefaultAsync();
                distrito.id = dis.idDistrito;
                distrito.nombre = dis.Distrito;
                distrito.idMunicipio = dis.idMunicipio;
            }
            return distrito;
        }

        public async Task<bool> SaveAsync()
        {
            bool succes = false;
            using (var db = new SIGIVEntities())
            {
                Distritos distrito = new Distritos
                {
                    Distrito = nombre,
                    idMunicipio = idMunicipio
                };
                db.Distritos.Add(distrito);
                int result = await db.SaveChangesAsync();
                succes = result > 0;
            }
            return succes;
        }

        public async Task<bool> UpdateAsync()
        {
            bool succes = false;
            using (var db = new SIGIVEntities())
            {
                Distritos distrito = await db.Distritos.Where(x => x.idDistrito == id).FirstOrDefaultAsync();
                distrito.Distrito = nombre;
                distrito.idMunicipio = idMunicipio;
                db.Entry(distrito).State = EntityState.Modified;
                int result = await db.SaveChangesAsync();
                succes = result > 0;
            }
            return succes;
        }

        public async Task<bool> DeleteAsync()
        {
            bool succes = false;
            using (var db = new SIGIVEntities())
            {
                Distritos distrito = await db.Distritos.Where(x => x.idDistrito == id).FirstOrDefaultAsync();
                db.Distritos.Remove(distrito);
                int result = await db.SaveChangesAsync();
                succes = result > 0;
            }
            return succes;
        }

        public async void validar()
        {
            if(string.IsNullOrEmpty(nombre)) throw new Exception("El nombre del distrito es requerido");
            if(idMunicipio <= 0) throw new Exception("El municipio es requerido");
        }

    }
}
