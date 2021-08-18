using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("stati")]
    public class StatiController : Controller
    {
        private IRepository<Stati, int> service;
        public StatiController(IRepository<Stati, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getStati()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getStatiById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult createStati([FromBody] Stati Stati)
        {
            return Ok(service.Save(Stati));
        }
        [HttpPatch("{id}")]
        public IActionResult createStati(int id, [FromBody] Stati Stati)
        {
            return Ok(service.Save(Stati));
        }
    }
}
