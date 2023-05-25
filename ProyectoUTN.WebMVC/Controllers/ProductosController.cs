using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoUTN.Modelos;
using ProyectoUTN.UAPI;

namespace ProyectoUTN.WebMVC.Controllers
{
    public class ProductosController : Controller
    {
        
        private string  Url;


        private Crud<Producto> Crud { get; set; }
        public ProductosController(IConfiguration config)
        {
            this.Url = config.GetValue<string>("apiurl") + "/Productos";

            Crud = new Crud<Producto>();
        }

        // GET: ProductosController
        public ActionResult Index()
        {
            var datos =  Crud.Select(Url);

            return View(datos);
        }

        // GET: ProductosController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Crud.Select_ById(Url,id.ToString());
            return View(datos);
        }

        // GET: ProductosController/Create
        public ActionResult Create()
        {
            var listaCategorias = new Crud<Categoria>()
                .Select(Url.Replace("Producto", "Categoria"))
                .Select(p => new SelectListItem     // transformamos del tipo Privincia -> SelectListItem
                {
                    Value = p.Id.ToString(),       // codigo de provincia
                    Text = p.Nombre               // nombre de provincia
                })
                .ToList();

            ViewBag.ListaCategorias = listaCategorias;  // pasamos la lista de Provincias a la vista

            return View();
        }

        // POST: ProductosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto datos)
        {
            try
            {
                 Crud.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: ProductosController/Edit/5
        public ActionResult Edit(int id)
        {

            var datos = Crud.Select_ById(Url, id.ToString());
            var listaCategorias = new Crud<Categoria>()
               .Select(Url.Replace("Producto", "Categoria"))
               .Select(p => new SelectListItem     // transformamos del tipo Privincia -> SelectListItem
               {
                   Value = p.Id.ToString(),       // codigo de provincia
                   Text = p.Nombre               // nombre de provincia
               })
               .ToList();

            ViewBag.ListaCategorias = listaCategorias;  // pasamos la lista de Provincias a la vista
            return View(datos);
        }

        // POST: ProductosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Producto datos)
        {
            try
            {
                Crud.Update(Url,id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: ProductosController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos = Crud.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: ProductosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Producto datos)
        {
            try
            {
                Crud.Delete(Url,id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
