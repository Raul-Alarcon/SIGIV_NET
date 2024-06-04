using SIGIV.CLS.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGIV.CLS
{
    public class ClienteCLS
    {
        public int id { get; set; }
        public string nombres{ get; set; }
        public string apellidos { get; set; }
        public string dui { get; set; }
        public string telefono { get; set; }
        public string eMail { get; set; }

        public static async Task<List<ClienteDTO>> GetAllDTOAsync()
        {
            List<ClienteDTO> clientes = new List<ClienteDTO>();
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                clientes = await (from cli in db.Clientes
                                  select new ClienteDTO
                                  {
                                 ID = cli.IDCliente,
                                 Nombres = cli.nombresCliente,
                                 DUI = cli.dui,
                                 Telefono = cli.telefono,
                                 Correo = cli.eMail
                             }).ToListAsync();
            }
            return clientes;
        }

        public async Task<bool> AddAsync()
        {
            bool success = false;
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.Clientes cli = new DataLayer.Clientes
                {
                    nombresCliente = this.nombres,
                    apellidosCliente = this.apellidos,
                    dui = this.dui,
                    telefono = this.telefono,
                    eMail = this.eMail
                };
                db.Clientes.Add(cli);
                success = await db.SaveChangesAsync() > 0;
            }
            return success;
        }

        public async Task<bool> UpdateAsync()
        {
            bool success = false;
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.Clientes cli = db.Clientes.Where(x => x.IDCliente == this.id).FirstOrDefault();
                if (cli != null)
                {
                    cli.nombresCliente = this.nombres;
                    cli.apellidosCliente = this.apellidos;
                    cli.dui = this.dui;
                    cli.telefono = this.telefono;
                    cli.eMail = this.eMail;
                    success = await db.SaveChangesAsync() > 0;
                }
            }
            return success;
        }

        public static async Task<bool> DeleteAsync(int idCliente)
        {
            bool success = false;
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.Clientes cli = db.Clientes.Where(x => x.IDCliente == idCliente).FirstOrDefault();
                if (cli != null)
                {
                    db.Clientes.Remove(cli);
                    success = await db.SaveChangesAsync() > 0;
                }
            }
            return success;
        }

        public static async Task<ClienteCLS> GetByIdAsync(int idCliente)
        {
            ClienteCLS cliente = new ClienteCLS();
            using (DataLayer.SIGIVEntities db = new DataLayer.SIGIVEntities())
            {
                DataLayer.Clientes cli = await db.Clientes.Where(x => x.IDCliente == idCliente).FirstOrDefaultAsync();
                if (cli != null)
                {
                    cliente.id = cli.IDCliente;
                    cliente.nombres = cli.nombresCliente;
                    cliente.apellidos = cli.apellidosCliente;
                    cliente.dui = cli.dui;
                    cliente.telefono = cli.telefono;
                    cliente.eMail = cli.eMail;
                }
            }
            return cliente;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(this.nombres)) throw new ArgumentException("El campo nombres es requerido");
            if (string.IsNullOrEmpty(this.apellidos)) throw new ArgumentException("El campo apellidos es requerido");
            if (string.IsNullOrEmpty(this.dui)) throw new ArgumentException("El campo DUI es requerido");
            if (string.IsNullOrEmpty(this.telefono)) throw new ArgumentException("El campo teléfono es requerido");
            if (string.IsNullOrEmpty(this.eMail)) throw new ArgumentException("El campo correo electrónico es requerido");
            
        }
    }
}
