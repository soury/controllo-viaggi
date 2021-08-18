using DevInterview.Core.Model;
using DevInterview.Providers.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInterview.WebAPI.Controllers
{
    [ApiController, Route("categorie-merchi")]
    public class CategorieMerchiController : Controller
    {
        private IRepository<CategorieMerchi, int> service;
        public CategorieMerchiController(IRepository<CategorieMerchi, int> service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getCategorieMerchi()
        {
            return Ok(service.All());
        }
        [HttpGet("{id}")]
        public IActionResult getCategorieMerchioById(int id)
        {
            return Ok(service.FindById(id));
        }
        [HttpPost]
        public IActionResult createCategorieMerchio([FromBody] CategorieMerchi CategorieMerchio)
        {
            return Ok(service.Save(CategorieMerchio));
        }
        [HttpPatch("{id}")]
        public IActionResult createCategorieMerchio(int id, [FromBody] CategorieMerchi CategorieMerchio)
        {
            return Ok(service.Save(CategorieMerchio));
        }
    }
}
