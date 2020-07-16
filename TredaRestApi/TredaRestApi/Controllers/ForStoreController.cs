using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TredaRestApi.DataProcesos;
using TredaRestApi.ModelTreda;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TredaRestApi.Controllers
{
    [Route("api/[controller]")]
    public class ForStoreController : Controller
    {
        private readonly ForStoreId _DBSP;

        public ForStoreController(ForStoreId DBSP)
        {
            this._DBSP = DBSP ?? throw new ArgumentNullException(nameof(DBSP));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ForStore>>> Get(int id)
        {
            var response = await _DBSP.SPProductosPorTienda(id);
            if (response == null) { return NotFound(); }
            return response;
        }

    }
}
