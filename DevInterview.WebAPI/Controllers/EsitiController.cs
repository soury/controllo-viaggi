using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("esiti")]
    public class EsitiController : Controller
    {
        private IRepository<Esiti, int> service;
        public EsitiController(IRepository<Esiti, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getEsiti()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getEsitioById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult createEsitio([FromBody] Esiti Esitio)
        {
            return Ok(service.Save(Esitio));
        }
        [HttpPatch("{id}")]
        public IActionResult createEsitio(int id, [FromBody] Esiti Esitio)
        {
            return Ok(service.Save(Esitio));
        }
    }
}
