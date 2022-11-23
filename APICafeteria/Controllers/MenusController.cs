using APICafeteria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICafeteria.Controllers
{
    [Route("menus")]
    [ApiController]
    public class MenusController : ControllerBase
    {


        // GET: category
        [Route("allcategory")]
        [HttpGet]
        public IEnumerable<Models.Articulos> GetCategory()
        {
            using (var db = new Models.CafeteriaDBContext())
            {

                var results = db.Categorias.ToList();
                return results;

            }

        }


        [HttpPost]
        [Route("newcategory")]
        public async Task SetCategory(string name)
        {

            var db = new Models.CafeteriaDBContext();
            var entity = new Articulos()
            {
                Nombre = name
            };

#pragma warning disable format
            db.Categorias.Add(entity);
#pragma warning restore format
            await db.SaveChangesAsync();
        }


        // GET: category
        [Route("allarticle")]
        [HttpGet]
        public IEnumerable<Models.Articulo> GetArticles()
        {
            using (var db = new Models.CafeteriaDBContext())
            {

                var results = db.Articulos.ToList();
                return results;

            }

        }



    }

}
