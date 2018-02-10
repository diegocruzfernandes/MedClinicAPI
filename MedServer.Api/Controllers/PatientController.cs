using MedServer.Domain.Dtos.Patient;
using MedServer.Domain.Services;
using MedServer.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedServer.Api.Controllers
{
    public class PatientController : BaseController
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service, IUow uow) : base(uow)
        {
            _service = service;
        }

        [HttpPost]
        [Route("v1/patient")]
        public async Task<IActionResult> Post([FromBody] CreatePatientDto patient)
        {
            var result = _service.Create(patient);
            return await Response(result, _service.Validate());
        }

        [HttpGet]
        [Route("v1/patient")]
        public async Task<IActionResult> Get()
        {
            var result = _service.Get();
            return await ResponseList(result);
        }
    }
}
