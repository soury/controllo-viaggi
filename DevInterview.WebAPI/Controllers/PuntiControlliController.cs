using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("punti-controlli")]
    public class PuntiControlliController : Controller
    {
        private IRepository<PuntiControlli, int> service;
        public PuntiControlliController(IRepository<PuntiControlli, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getPuntiControlli()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getPuntiControlliById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult createPuntiControlli([FromBody] PuntiControlli PuntiControlli)
        {
            return Ok(service.Save(PuntiControlli));
        }
        [HttpPatch("{id}")]
        public IActionResult createPuntiControlli(int id, [FromBody] PuntiControlli PuntiControlli)
        {
            return Ok(service.Save(PuntiControlli));
        }
    }
}
