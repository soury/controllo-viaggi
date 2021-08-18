using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("utenti")]
    public class UtentiController : Controller
    {
        private IRepository<Utenti, int> service;
        public UtentiController(IRepository<Utenti, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getUtenti()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getUtentiById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult createUtenti([FromBody] Utenti Utenti)
        {
            return Ok(service.Save(Utenti));
        }
        [HttpPatch("{id}")]
        public IActionResult createUtenti(int id, [FromBody] Utenti Utenti)
        {
            return Ok(service.Save(Utenti));
        }
    }
}
