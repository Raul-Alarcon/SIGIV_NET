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
    internal class DepartamentosCLS
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int idPais { get; set; }

        public static async Task<List<DepartamentosCLS>> GetAllAsync()
        {
            List<DepartamentosCLS> departamentos = new List<DepartamentosCLS>();
            using(var db = new SIGIVEntities())
            {
                departamentos = await (from departamento in db.Departamentos
                                       select new DepartamentosCLS
                                       {
                                           id = departamento.idDepartamento,
                                           nombre = departamento.departamento,
                                           idPais = (int)departamento.idPais
                                       }).ToListAsync();
            }
            return departamentos;
        }

        public static async Task<List<DepartamentoDTO>> GetAllDTOAsync()
        {
            List<DepartamentoDTO> departamentos = new List<DepartamentoDTO>();
            using(var db = new SIGIVEntities())
            {
                departamentos = await (from departamento in db.Departamentos
                                       join pais in db.Paises on departamento.idPais equals pais.idPais
                                       select new DepartamentoDTO
                                       {
                                           ID = departamento.idDepartamento,
                                           Departamento = departamento.departamento,
                                           Pais = pais.pais
                                       }).ToListAsync();
            }
            return departamentos;
        }


        public static async Task<DepartamentosCLS> GetByIdAsync(int id)
        {
            DepartamentosCLS departamento = new DepartamentosCLS();
            using(var db = new SIGIVEntities())
            {
                Departamentos dep = await db.Departamentos.Where(x => x.idDepartamento == id).FirstOrDefaultAsync();
                departamento.id = dep.idDepartamento;
                departamento.nombre = dep.departamento;
                departamento.idPais = (int)dep.idPais;
            }
            return departamento;
        }

        public async Task<bool> SaveAsync()
        {
            bool success = false;
            using(var db = new SIGIVEntities())
            {
                Departamentos departamento = new Departamentos
                {
                    departamento = nombre,
                    idPais = idPais
                };
                db.Departamentos.Add(departamento);
                int result = await db.SaveChangesAsync();
                success = result > 0;
            }
            return success;
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using(var db = new SIGIVEntities())
            {
                Departamentos departamento = db.Departamentos.Where(x => x.idDepartamento == id).FirstOrDefault();
                departamento.departamento = nombre;
                departamento.idPais = idPais;
                db.Entry(departamento).State = System.Data.Entity.EntityState.Modified;
                int result = await db.SaveChangesAsync();
                success = result > 0;
            }
            return success;
        }

        public async Task<bool> DeleteAsync()
        {
            bool success = false;
            using(var db = new SIGIVEntities())
            {
                Departamentos departamento = db.Departamentos.Where(x => x.idDepartamento == id).FirstOrDefault();
                db.Departamentos.Remove(departamento);
                int result = await db.SaveChangesAsync();
                success = result > 0;
            }
            return success;
        }

        public void validar()
        {
            if (string.IsNullOrEmpty(nombre)) throw new ArgumentException("El nombre del departamento es requerido");
            if (idPais == 0) throw new ArgumentException("El país es requerido");
        }
    }
}
