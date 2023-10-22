using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProgramacionIV.Models;
using ProgramacionIV.NewFolder;
using System.Text.Json.Serialization;

namespace ProgramacionIV.Controllers
{
    public class ProductoController : Controller
    {
        Uri baseAdd = new Uri("https://localhost:7106/api/Producto");
        private readonly HttpClient _client;

        public ProductoController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAdd;
        }

        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<Producto> products = await _client.GetFromJsonAsync<List<Producto>>(_client.BaseAddress);

            return View(products);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int IdProducto)
        {
            Producto p = await _client.GetFromJsonAsync<Producto>(_client.BaseAddress + "/" + IdProducto);

			if (p != null)
			{
                return View(p);
			}

			return RedirectToAction("Index");
		}

        // GET: ProductoController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto p)
        {
            var a = await _client.PostAsJsonAsync(_client.BaseAddress, p);
			return RedirectToAction("Index");
        }

        // GET: ProductoController/Edit/5
        public async Task<ActionResult> Edit(int IdProducto)
        {
            Producto p = await _client.GetFromJsonAsync<Producto>(_client.BaseAddress + "/" + IdProducto);

			if (p != null)
			{
				return View(p);
			}
			return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Producto Producto)
        {
			await _client.PutAsJsonAsync(_client.BaseAddress + "/" + Producto.IdProducto, Producto);

            return RedirectToAction("Index");
        }

        // GET: ProductoController/Delete/5
        [HttpDelete]
        public async Task<ActionResult> Delete(int IdProducto)
        {
			await _client.DeleteAsync(_client.BaseAddress + "/" + IdProducto);

			return RedirectToAction("Index");
        }
    }
}
