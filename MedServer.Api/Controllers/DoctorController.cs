using MedServer.Domain.Dtos.Doctor;
using MedServer.Domain.Services;
using MedServer.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedServer.Api.Controllers
{
    public class DoctorController : BaseController
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service, IUow uow) : base(uow)
        {
            _service = service;
        }

        [HttpPost]
        [Route("v1/doctor")]
        public async Task<IActionResult> Post([FromBody] CreateDoctorDto patient)
        {
            var result = _service.Create(patient);
            return await Response(result, _service.Validate());
        }

        [HttpGet]
        [Route("v1/doctor")]
        public async Task<IActionResult> Get()
        {
            var result = _service.Get();
            return await ResponseList(result);
        }
    }
}
