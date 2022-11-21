using APICafeteria.Models;
using Microsoft.AspNetCore.Mvc;
 
namespace APICafeteria.Controllers
{
    [Route("users")]
    [ApiController]
    public class UsersController : ControllerBase
    {

       
        
            [Route("all")]
            [HttpGet]
            public IEnumerable<Models.Usuario> GetUsers()
            {
                using (var db = new Models.CafeteriaDBContext())
                {

                    var results = db.Usuarios.ToList();
                    return results;

                }

            }

            [Route("new")]
        [HttpPost]
        //add user
        public async Task SetUsers(string name,string usertype, 
            string state,string clave,string sessionkey, string email)
        {

            var db = new Models.CafeteriaDBContext();
            var entity = new Usuario()
            {
                Nombre = name,
                TipoDeUsuario = usertype,
                Estado = state,
                Clave=clave,
                SessionKey=sessionkey,
                Email=email 
            };

            db.Usuarios.Add(entity);
            await db.SaveChangesAsync();


        }

        //update user
        [HttpPost]
        [Route("update")]
        public async Task UpdateUser(int id, string name, string usertype,
            string state, string clave, string sessionkey, string email)
        {

            using (var db = new Models.CafeteriaDBContext())
            {
                var adduser= db.Usuarios.Where(e => e.Id == id).FirstOrDefault();

#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                adduser.Nombre = name;
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
                adduser.TipoDeUsuario = usertype;
                adduser.Estado = state;
                adduser.Clave = clave;
                adduser.SessionKey = sessionkey;
                adduser.Email = email;

                db.SaveChanges();
            }

             
        }

        //delete user
        [HttpPost]
        [Route("delete")]
        public async Task DeleteUser(int id)
        {

            using (var db = new Models.CafeteriaDBContext())
            {
                var removeuser= db.Usuarios.Where(e => e.Id == id).FirstOrDefault();

#pragma warning disable CS8604 // Posible argumento de referencia nulo
                db.RemoveRange(removeuser);
#pragma warning restore CS8604 // Posible argumento de referencia nulo
#pragma   warning restore CS8602
                db.SaveChanges();
            }



        }
    }
  }
