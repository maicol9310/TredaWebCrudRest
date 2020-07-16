using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TredaFront.Models;

namespace TredaFront.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [HttpGet]
        public ActionResult IndexP()
        {
            return View();
        }

        public async Task<JsonResult> ProductsJson()
        {
            List<Products> countries = new List<Products>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44395/api/Products");
            string apiResponse = await response.Content.ReadAsStringAsync();
            countries = JsonConvert.DeserializeObject<List<Products>>(apiResponse);

            return Json(countries, JsonRequestBehavior.AllowGet);

        }

        public ViewResult AddProducts() => View();
        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public async Task<ActionResult> AddProducts(Products products)
        {
            Products product = new Products();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(products), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44395/api/Products", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    product = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
            }
            return RedirectToAction("IndexS");
        }

        public ActionResult Delete(int id)
        {
            Products pro = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44395/");

                var responseTask = client.GetAsync("api/Products/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Products>();
                    readTask.Wait();
                    pro = readTask.Result;
                }


            }
            return View(pro);
        }

        [HttpPost]
        public ActionResult Delete(Products pro, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44395/");

                var deleteTask = client.DeleteAsync($"api/Products/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("IndexP");
                }
            }
            return RedirectToAction("IndexP");
        }

        public ActionResult Edit(int id)
        {
            Products pro = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44395/");

                var responseTask = client.GetAsync("api/Products/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Products>();
                    readTask.Wait();
                    pro = readTask.Result;
                }


            }
            return View(pro);
        }

        [HttpPost]
        public ActionResult Edit(Products pro, int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44395/");

                var putTask = client.PutAsJsonAsync($"api/Products/{pro.SKU}", pro);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("IndexP");
                }
            }
            return RedirectToAction("IndexP");
        }
    }
}