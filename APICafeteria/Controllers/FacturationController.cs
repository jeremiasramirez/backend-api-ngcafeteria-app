using APICafeteria.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICafeteria.Controllers
{
    [Route("facturation")]
    [ApiController]
    public class FacturationController : ControllerBase
    {


        // GET: facturacions
        [Route("all")]
        [HttpGet]
        public IEnumerable<Models.Facturacion> GetAllFacturacion()
        {
            using (var db = new Models.CafeteriaDBContext())
            {
                var results = db.Facturacions.ToList();
                return  results;
            }

        }

        [HttpPost]
        [Route("new")]
        public async Task SetFacturation(string name, string productname, int cantidad,float subtotal,float total,string estado)
        {
 
            var db = new Models.CafeteriaDBContext();
            var entity = new Facturacion()
            {
                NombreCliente = name,
                NombreProducto = productname,
                Cantidad = cantidad,
                Subtotal = subtotal,
                Total = total,
                Estado=estado
            };

            db.Facturacions.Add(entity);
            await db.SaveChangesAsync();

            
        }


        [HttpPost]
        [Route("update")]
        public async Task UpdateFacturation(int id, string status)
        {

            using (var db = new Models.CafeteriaDBContext())
            {
                var addclient = db.Facturacions.Where(e => e.Id == id).FirstOrDefault();

#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                addclient.Estado=status;
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
                 
                db.SaveChanges();
            }



        }
    }
}
