using APICafeteria.Models;
 
using Microsoft.AspNetCore.Mvc;
 

namespace APICafeteria.Controllers
{
    [Route("employee")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        [Route("all")]
        [HttpGet]
        public IEnumerable<Models.Empleado> GetEmployees()
        {
            using (var db = new Models.CafeteriaDBContext())
            {

                var results = db.Empleados.Where((e)=>e.Estado == "Activo").ToList();
                return results;

            }

        }


        [Route("new")]
        [HttpPost]       
        //add employee
        public async Task SetEmployee(
             string name,
            string cedula,
            string tanda,
            string datepost,
            string state,
            string cargo,
            string email)
        {

            var db = new Models.CafeteriaDBContext();
            var entity = new Empleado()
            {
                Nombre = name,
                Cedula = cedula,
                Tanda = tanda,
                FechaIngreso = datepost,
                Estado = state,
                Cargo=cargo,
                Emails = email,
                Email = email
            };

            db.Empleados.Add(entity);
            await db.SaveChangesAsync();


        }


        //update employee
       // [AllowAnonymous]
       // [IgnoreAntiforgeryToken]
        //[DisableCors]
        [HttpPost]
        [Route("update")]
        public async Task UpdateEmployee(
            int id,
            string name, 
            string cedula,
            string tanda, 
            string datepost, 
            string state, 
            string cargo,
            string email
            )
        {
           

            using (var db = new Models.CafeteriaDBContext())
            {
                var adduser = db.Empleados.Where(e => e.Id == id).FirstOrDefault();

#pragma warning disable CS8602 // Desreferencia de una referencia posiblemente NULL.
                adduser.Nombre = name;
#pragma warning restore CS8602 // Desreferencia de una referencia posiblemente NULL.
                adduser.Cedula = cedula;
                adduser.Tanda = tanda;
                adduser.FechaIngreso= datepost;
                adduser.Estado= state;
                adduser.Cargo = cargo;
                adduser.Email = email;
                adduser.Emails = email;

                db.SaveChanges();
            }


        }

        //delete employee
        [HttpPost]
        [Route("delete")]
        public async Task DeleteEmployee(int id)
        {

            using (var db = new Models.CafeteriaDBContext())
            {
                var removeemployee = db.Empleados.Where(e => e.Id == id).FirstOrDefault();

#pragma warning disable CS8604 // Posible argumento de referencia nulo
                db.RemoveRange(removeemployee);
#pragma warning restore CS8604 // Posible argumento de referencia nulo
#pragma   warning restore CS8602
                db.SaveChanges();
            }



        }
    }

}
 