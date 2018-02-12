using MedServer.Api.Shared;
using MedServer.Domain.Dtos.PatientDtos;
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
            var listError = ValidPropertiesObject.ObjIsValid(patient);
            if (listError.Count > 0)
                return await ResponseNullOrEmpty(listError);

            var result = _service.Create(patient);
            return await Response(result, _service.Validate());
        }
               
        [HttpGet]
        [Route("v1/patient")]
        public async Task<IActionResult> GetByRange(
          [FromQuery(Name = "page_size")]int page_size,
          [FromQuery(Name = "page")]int page)
        {
            if(page_size == 0 && page == 0)
            {
                var result = _service.Get();
                return await ResponseList(result);
            }
            else
            {
                var skip = (page - 1) * page_size;
                var result = _service.Get(skip, page_size);
                return await ResponseList(result);
            }           
        }

        [HttpGet]
        [Route("v1/patient/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _service.Get(id);
            return await ResponseList(result);
        }

        [HttpDelete]
        [Route("v1/patient/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _service.Delete(id);
            return await Response(result, _service.Validate());
        }

        [HttpPut]
        [Route("v1/patient")]
        public async Task<IActionResult> Update([FromBody] EditPatientDto patient)
        {
            var listError = ValidPropertiesObject.ObjIsValid(patient);
            if (listError.Count > 0)
                return await ResponseNullOrEmpty(listError);

            var result = _service.Update(patient);
            return await Response(result, _service.Validate());
        }
    }
}
