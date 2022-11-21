using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICafeteria.Controllers
{
     
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
       // private readonly string cors = "mycors";
          Models.CafeteriaDBContext  context =  new Models.CafeteriaDBContext();
       //obtenemos los datos del usuario mediante su email y password
        [HttpGet]
        [Route("sign")]
        //[DisableCors]
        public  IEnumerable<Models.Usuario> SignIn(string email,string pass )
        {
            using (var db = new Models.CafeteriaDBContext())
            {
               
                 var results = db.Usuarios.Where(data=>data.Email==email && data.Clave==pass && data.Estado=="Activo").ToList();
                 return results;

            }

        }
        
        //actualizamos el token de la session cada vez que iniciamos o cerramos sesion 
        [HttpPost]
        [Route("setsessionkey")]
        public async Task SetToken(string email,string password, string token)
        {

            using(var db=new Models.CafeteriaDBContext())
            {
                var updateuser=db.Usuarios.Where(u=>u.Email==email && u.Clave==password && u.Estado=="Activo").FirstOrDefault();

                // CS8602
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                updateuser.SessionKey = token;
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.

                  db.SaveChanges();
                 //db.SaveChanges();
            }
        
        }


        [HttpGet]
        [Route("verifysessionkey")]
        public IEnumerable<Models.Usuario> VerifyToken(string token)
        {
            using (var db = new Models.CafeteriaDBContext())
            {

                var results = db.Usuarios.Where(data => data.SessionKey == token).ToList();
                return results;

            }

        }


        [HttpPost]
        [Route("removesessionkey")]
        public async Task RemoveToken(string newtoken)
        {

            using (var db = new Models.CafeteriaDBContext())
            {
                var updateuser = db.Usuarios.Where(u => u.SessionKey!="").FirstOrDefault();

                // CS8602
#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                updateuser.SessionKey = newtoken;
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.

                db.SaveChanges();
                //db.SaveChanges();
            }

        }


        //obtenemos los datos del usuario mediante su token
        [HttpGet]
        [Route("getbytoken")]
        public IEnumerable<Models.Usuario> GetByToken(string token)
        {

            using (var db = new Models.CafeteriaDBContext())
            {
                var results = db.Usuarios.Where(u => u.SessionKey == token).ToList();


                return results;
            }

        }
















        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
