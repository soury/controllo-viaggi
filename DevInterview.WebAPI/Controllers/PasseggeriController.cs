using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("passeggeri")]
    public class PasseggeriController : Controller
    {
        private IRepository<Passeggeri, int> service;
        public PasseggeriController(IRepository<Passeggeri, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getPasseggeri()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getPasseggeriById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult createPasseggeri([FromBody] Passeggeri Passeggeri)
        {
            return Ok(service.Save(Passeggeri));
        }
        [HttpPatch("{id}")]
        public IActionResult createPasseggeri(int id, [FromBody] Passeggeri Passeggeri)
        {
            return Ok(service.Save(Passeggeri));
        }
    }
}
