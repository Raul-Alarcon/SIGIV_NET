using SIGIV.CLS.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    public class EmpleadoCLS
    {
        public int idEmpleado { get; set; }
        public string nombresEmpleado { get; set; }
        public string apellidosEmpleado { get; set; }
        public System.DateTime fechaNacimiento { get; set; }
        public string dui { get; set; }
        public string ISSS { get; set; }
        public string telefono { get; set; }
        public string eMail { get; set; }
        public int idCargo { get; set; }

        public static async Task<List<EmpleadoDTO>> GetAllAsync()
        {
            List<EmpleadoDTO> empleados = new List<EmpleadoDTO>();
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                empleados = await (from emp in db.Empleados
                                   join car in db.Cargos on emp.idCargo equals car.idCargo
                                   select new EmpleadoDTO
                                   {
                                       ID = emp.idEmpleado,
                                       Nombres = emp.nombresEmpleado,
                                       Apellidos = emp.apellidosEmpleado,
                                       FechaNacimiento = (DateTime)emp.fechaNacimiento,
                                       DUI = emp.dui,
                                       ISSS = emp.ISSS,
                                       Telefono = emp.telefono,
                                       Correo = emp.eMail,
                                       Cargo = car.cargo
                                   }).ToListAsync();
            }
            return empleados;
        }
        
        public async Task<bool> AddAsync()
        {
            bool success = false;
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.Empleados emp = new DataLayer.Empleados
                {
                    nombresEmpleado = this.nombresEmpleado,
                    apellidosEmpleado = this.apellidosEmpleado,
                    fechaNacimiento = this.fechaNacimiento,
                    dui = this.dui,
                    ISSS = this.ISSS,
                    telefono = this.telefono,
                    eMail = this.eMail,
                    idCargo = this.idCargo
                };
                db.Empleados.Add(emp);
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.Empleados emp = db.Empleados.Where(x => x.idEmpleado == this.idEmpleado).FirstOrDefault();
                emp.nombresEmpleado = this.nombresEmpleado;
                emp.apellidosEmpleado = this.apellidosEmpleado;
                emp.fechaNacimiento = this.fechaNacimiento;
                emp.dui = this.dui;
                emp.ISSS = this.ISSS;
                emp.telefono = this.telefono;
                emp.eMail = this.eMail;
                emp.idCargo = this.idCargo;
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }
        public static async Task<EmpleadoCLS> GetByIdAsync(int idEmpleado)
        {
            EmpleadoCLS empleado = new EmpleadoCLS();
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.Empleados emp = await db.Empleados.Where(x => x.idEmpleado == idEmpleado).FirstOrDefaultAsync();
                empleado.idEmpleado = emp.idEmpleado;
                empleado.nombresEmpleado = emp.nombresEmpleado;
                empleado.apellidosEmpleado = emp.apellidosEmpleado;
                empleado.fechaNacimiento = (DateTime)emp.fechaNacimiento;
                empleado.dui = emp.dui;
                empleado.ISSS = emp.ISSS;
                empleado.telefono = emp.telefono;
                empleado.eMail = emp.eMail;
                empleado.idCargo =(int)emp.idCargo;
            }
            return empleado;
        }

        public async Task<bool> DeleteAsync()
        {
            bool success = false;
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.Empleados emp = db.Empleados.Where(x => x.idEmpleado == this.idEmpleado).FirstOrDefault();
                db.Empleados.Remove(emp);
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }

        public static async Task<bool> DeleteByIdAsync(int idEmpleado)
        {
            bool success = false;
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.Empleados emp = db.Empleados.Where(x => x.idEmpleado == idEmpleado).FirstOrDefault();
                db.Empleados.Remove(emp);
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }

        public async Task<DireccionEmpleadoCLS> GetDireccionAsync()
        {
            DireccionEmpleadoCLS direccion = new DireccionEmpleadoCLS();
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                var model = await db.EmpleadoDireccion.Where(x => x.idEmpleado == this.idEmpleado).FirstOrDefaultAsync();
                if (model != null)
                {
                    direccion.id = model.idEmpleadoDireccion;
                    direccion.idEmpleado = (int)model.idEmpleado;
                    direccion.Linea1 = model.Linea1;
                    direccion.Linea2 = model.Linea2;
                    direccion.codigoPostal = model.codigoPostal;
                }
            }
            return direccion;
        }

        public void validar()
        {
            if (string.IsNullOrEmpty(this.nombresEmpleado)) throw new Exception("El campo Nombres es requerido");
            if (string.IsNullOrEmpty(this.apellidosEmpleado)) throw new Exception("El campo Apellidos es requerido");
            if (this.fechaNacimiento == null) throw new Exception("El campo Fecha de Nacimiento es requerido");
            if (string.IsNullOrEmpty(this.dui)) throw new Exception("El campo DUI es requerido");
            if (string.IsNullOrEmpty(this.ISSS)) throw new Exception("El campo ISSS es requerido");
            if (string.IsNullOrEmpty(this.telefono)) throw new Exception("El campo Teléfono es requerido");
            if (string.IsNullOrEmpty(this.eMail)) throw new Exception("El campo Correo es requerido");
            if (this.idCargo == 0) throw new Exception("El campo Cargo es requerido");
        }

    }
}
