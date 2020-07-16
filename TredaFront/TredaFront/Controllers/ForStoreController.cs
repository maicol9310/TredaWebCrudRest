using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TredaFront.Models;

namespace TredaFront.Controllers
{
    public class ForStoreController : Controller
    {
        // GET: ForStore
        public ViewResult Index() => View();
        [HttpPost]
        public async Task<ActionResult> Index(int id)
        {
            List<ForStore> store = new List<ForStore>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44395/api/ForStore/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    store = JsonConvert.DeserializeObject<List<ForStore>>(apiResponse);
                }
            }
            return View(store);

        }
    }
}