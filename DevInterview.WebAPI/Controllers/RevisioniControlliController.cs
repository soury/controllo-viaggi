using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("revisioni-controlli")]
    public class RevisioniControlliController : Controller
    {
        private IRepository<RevisioniControlli, int> service;
        public RevisioniControlliController(IRepository<RevisioniControlli, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getRevisioniControlli()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getRevisioniControlliById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult createRevisioniControlli([FromBody] RevisioniControlli RevisioniControlli)
        {
            return Ok(service.Save(RevisioniControlli));
        }
        [HttpPatch("{id}")]
        public IActionResult createRevisioniControlli(int id, [FromBody] RevisioniControlli RevisioniControlli)
        {
            return Ok(service.Save(RevisioniControlli));
        }
    }
}
