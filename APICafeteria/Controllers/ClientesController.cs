using APICafeteria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICafeteria.Controllers
{
    [Route("clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [Route("all")]
        [HttpGet]
        public IEnumerable<Models.Cliente> GetClientes()
        {
            using (var db = new Models.CafeteriaDBContext())
            {

                var results = db.Clientes.ToList();
                return results;

            }

        }

        [HttpPost]
        [Route("new")]
        public async Task SetClients(string name, string email, string date)
        {

            var db = new Models.CafeteriaDBContext();
            var entity = new Cliente()
            {
                Nombre = name,
                Email = email,
                FechaRegistro = date
            };

            db.Clientes.Add(entity);
            await db.SaveChangesAsync();
             
        
        }

        [HttpPost]
        [Route("update")]
        public async Task UpdateCliente(int id, string name, string email,string date)
        {

            using (var db = new Models.CafeteriaDBContext())
            {
                var addclient = db.Clientes.Where(e => e.Id == id).FirstOrDefault();

#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                addclient.Nombre = name;
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
                addclient.Email = email;

                addclient.FechaRegistro = date;
                db.SaveChanges();
            }
            


        }

        [HttpPost]
        [Route("delete")]
        public async Task UpdateCliente(int id)
        {

            using (var db = new Models.CafeteriaDBContext())
            {
                var addclient = db.Clientes.Where(e => e.Id == id).FirstOrDefault();

#pragma warning disable CS8604 // Posible argumento de referencia nulo
                db.RemoveRange(addclient);
#pragma warning restore CS8604 // Posible argumento de referencia nulo
#pragma warning restore CS8602 
                db.SaveChanges();
            }



        }




    }


}
