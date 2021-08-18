using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("aeroporti")]
    public class AeroportiController : Controller
    {
        private IRepository<Aeroporti, int> service;
        public AeroportiController(IRepository<Aeroporti, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getAeroporto()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getAeroportoById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult createAeroporto([FromBody] Aeroporti Aeroporti)
        {
            return Ok(service.Save(Aeroporti));
        }
        [HttpPatch("{id}")]
        public IActionResult createAeroporto(int id, [FromBody] Aeroporti Aeroporti)
        {
            return Ok(service.Save(Aeroporti));
        }
    }
}
