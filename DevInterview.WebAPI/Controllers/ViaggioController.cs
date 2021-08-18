using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("viaggi")]
    public class ViaggioController : Controller
    {
        private IRepository<Viaggi, int> service;
        public ViaggioController(IRepository<Viaggi, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getViaggi()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getViaggioById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult createViaggio([FromBody] Viaggi Viaggio)
        {
            return Ok(service.Save(Viaggio));
        }
        [HttpPatch("{id}")]
        public IActionResult createViaggio(int id, [FromBody] Viaggi Viaggio)
        {
            return Ok(service.Save(Viaggio));
        }
    }
}
