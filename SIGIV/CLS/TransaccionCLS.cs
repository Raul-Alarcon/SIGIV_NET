using SIGIV.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;

namespace SIGIV.CLS
{
    public class TransaccionCLS
    {
        public int id { get; set; }
        public int idFactura { get; set; }
        public int idTipoPago { get; set; }
        public decimal monto { get; set; }
        public DateTime fechaTransaccion { get; set; }


        public async Task<bool> SaveAsync()
        {
            bool success = false;
            using (var db = new SIGIVEntities())
            {
                var transaccion = new TransaccionesPago
                {
                    idFactura = this.idFactura,
                    monto = this.monto,
                    fechaTransaccion = this.fechaTransaccion,
                    idTipoPago = this.idTipoPago,
                };
                db.TransaccionesPago.Add(transaccion);
                int result = await db.SaveChangesAsync();
                success = result > 0;
            }
            return success;
        }
    }
}
