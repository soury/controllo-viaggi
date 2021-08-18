using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("motivazioni-revisione")]
    public class MotivazioniRevisioneController : Controller
    {
        private IRepository<MotivazioniRevisione, int> service;
        public MotivazioniRevisioneController(IRepository<MotivazioniRevisione, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getMotivazioniRevisione()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getMotivazioniRevisioneById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult createMotivazioniRevisione([FromBody] MotivazioniRevisione MotivazioniRevisione)
        {
            return Ok(service.Save(MotivazioniRevisione));
        }
        [HttpPatch("{id}")]
        public IActionResult createMotivazioniRevisione(int id, [FromBody] MotivazioniRevisione MotivazioniRevisione)
        {
            return Ok(service.Save(MotivazioniRevisione));
        }
    }
}
