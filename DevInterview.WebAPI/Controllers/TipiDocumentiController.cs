using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("tipi-documenti")]
    public class TipiDocumentiController : Controller
    {
        private IRepository<TipiDocumenti, int> service;
        public TipiDocumentiController(IRepository<TipiDocumenti, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getTipiDocumenti()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getTipiDocumentiById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult createTipiDocumenti([FromBody] TipiDocumenti TipiDocumenti)
        {
            return Ok(service.Save(TipiDocumenti));
        }
        [HttpPatch("{id}")]
        public IActionResult createTipiDocumenti(int id, [FromBody] TipiDocumenti TipiDocumenti)
        {
            return Ok(service.Save(TipiDocumenti));
        }
    }
}
