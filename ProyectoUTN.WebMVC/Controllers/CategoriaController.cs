using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoUTN.UAPI;
using System.Configuration;

namespace ProyectoUTN.WebMVC.Controllers
{
    public class CategoriaController : Controller
    {
        private Crud<Modelos.Categoria> Categorias = new Crud<Modelos.Categoria>();
        private string Url;
        public CategoriaController(IConfiguration config) {
        this.Url= config.GetValue<string>("apiurl")+"/Categorias";
        }
        
        // GET: CategoriaController
        public ActionResult Index()
        {
            var datos = Categorias.Select(Url);
            return View(datos);
        }

        // GET: CategoriaController/Details/5
        public ActionResult Details(int id)
        {
            var datos = Categorias.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Modelos.Categoria datos)
        {
            try
            {
                Categorias.Insert(Url, datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: CategoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            var datos = Categorias.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Modelos.Categoria datos)
        {
            try
            {
                Categorias.Update(Url, id.ToString(), datos);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }

        // GET: CategoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            var datos =Categorias.Select_ById(Url, id.ToString());
            return View(datos);
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Modelos.Categoria datos)
        {
            try
            {
                Categorias.Delete(Url, id.ToString());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(datos);
            }
        }
    }
}
