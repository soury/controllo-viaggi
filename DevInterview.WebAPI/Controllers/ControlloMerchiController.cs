using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("controllo-merchi")]
    public class ControlloMerchiController : Controller
    {
        private IRepository<ControlloMerchi, int> service;
        public ControlloMerchiController(IRepository<ControlloMerchi, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getControlloMerchi()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getControlloMerchioById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult createControlloMerchio([FromBody] ControlloMerchi ControlloMerchio)
        {
            return Ok(service.Save(ControlloMerchio));
        }
        [HttpPatch("{id}")]
        public IActionResult createControlloMerchio(int id, [FromBody] ControlloMerchi ControlloMerchio)
        {
            return Ok(service.Save(ControlloMerchio));
        }
    }
}
