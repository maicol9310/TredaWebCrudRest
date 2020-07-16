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
    public class StoresController : Controller
    {
        // GET: Stores
        [HttpGet]
        public ActionResult IndexS()
        {
            return View();
        }

        public async Task<JsonResult> StoresJson()
        {
            List<Stores> countries = new List<Stores>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:44395/api/Stores");
            string apiResponse = await response.Content.ReadAsStringAsync();
            countries = JsonConvert.DeserializeObject<List<Stores>>(apiResponse);

            return Json(countries, JsonRequestBehavior.AllowGet);

        }

        public ViewResult AddStore() => View();
        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public async Task<ActionResult> AddStore(Stores store)
        {
            Stores countries = new Stores();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(store), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44395/api/Stores", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    countries = JsonConvert.DeserializeObject<Stores>(apiResponse);
                }
            }
            return RedirectToAction("IndexS");
        }

        public ActionResult Delete(int id)
        {
        Stores store = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44395/");

                var responseTask = client.GetAsync("api/Stores/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Stores>();
                    readTask.Wait();
                    store = readTask.Result;
                }


            }
            return View(store);
        }

        [HttpPost]
        public ActionResult Delete(Stores store, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44395/");

                var deleteTask = client.DeleteAsync($"api/Stores/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("IndexS");
                }
            }
            return RedirectToAction("IndexS");
        }

        public ActionResult Edit(int id)
        {
            Stores store = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44395/");

                var responseTask = client.GetAsync("api/Stores/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Stores>();
                    readTask.Wait();
                    store = readTask.Result;
                }


            }
            return View(store);
        }

        [HttpPost]
        public ActionResult Edit(Stores store, int id)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44395/");

                var putTask = client.PutAsJsonAsync($"api/Stores/{store.StoreId}", store);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("IndexS");
                }
            }
            return RedirectToAction("IndexS");
        }
    }
}