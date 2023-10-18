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
        public IActionResult Index()
        {
            List<Producto> products = new List<Producto>();

            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Producto>>(data);
            }

            return View(products);
        }

        // GET: ProductoController/Details/5
        public IActionResult Details(int IdProducto)
        {
            Producto p;

			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + IdProducto).Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				p = JsonConvert.DeserializeObject<Producto>(data);

                return View(p);
			}

			return RedirectToAction("Index");
		}

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto p)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync(_client.BaseAddress, p).Result;
			return RedirectToAction("Index");
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int IdProducto)
        {
            Producto p;
			HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/" + IdProducto).Result;

			if (response.IsSuccessStatusCode)
			{
				string data = response.Content.ReadAsStringAsync().Result;
				p = JsonConvert.DeserializeObject<Producto>(data);

				return View(p);
			}
			return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Producto Producto)
        {
			HttpResponseMessage response = _client.PutAsJsonAsync(_client.BaseAddress + "/" + Producto.IdProducto, Producto).Result;

            return RedirectToAction("Index");
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int IdProducto)
        {
			HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/" + IdProducto).Result;

			return RedirectToAction("Index");
        }
    }
}
