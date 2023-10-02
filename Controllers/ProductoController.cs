using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacionIV.Models;
using ProgramacionIV.NewFolder;



namespace ProgramacionIV.Controllers
{
    public class ProductoController : Controller
    {
        // GET: ProductoController
        public IActionResult Index()
        {
            return View(Utils.ListaProductos);
        }

        // GET: ProductoController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto p)
        {
            int cant = Utils.ListaProductos.Count();
            p.IdProducto = cant + 1;
            Utils.ListaProductos.Add(p);
            return View();
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int IdProducto)
        {
            Producto p = Utils.ListaProductos.Find(x => x.IdProducto == IdProducto);
            if(p != null)
            {
                Utils.ListaProductos.Remove(p);
            }
            
            return RedirectToAction("Index");
        }
    }
}
