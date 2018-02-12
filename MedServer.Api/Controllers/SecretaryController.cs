using MedServer.Api.Shared;
using MedServer.Domain.Dtos.SecretaryDtos;
using MedServer.Domain.Services;
using MedServer.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedServer.Api.Controllers
{
    public class SecretaryController: BaseController
    {
        private readonly ISecretaryService _service;

        public SecretaryController(ISecretaryService service, IUow uow) : base(uow)
        {
            _service = service;
        }

        [HttpPost]
        [Route("v1/secretary")]
        public async Task<IActionResult> Post([FromBody] CreateSecretaryDto secretary)
        {
            var listError = ValidPropertiesObject.ObjIsValid(secretary);
            if (listError.Count > 0)
                return await ResponseNullOrEmpty(listError);

            var result = _service.Create(secretary);
            return await Response(result, _service.Validate());
        }

        [HttpGet]
        [Route("v1/secretary")]
        public async Task<IActionResult> GetByRange(
          [FromQuery(Name = "page_size")]int page_size,
          [FromQuery(Name = "page")]int page)
        {
            if (page_size == 0 && page == 0)
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
        [Route("v1/secretary/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _service.Get(id);
            return await ResponseList(result);
        }

        [HttpDelete]
        [Route("v1/secretary/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _service.Delete(id);
            return await Response(result, _service.Validate());
        }

        [HttpPut]
        [Route("v1/secretary")]
        public async Task<IActionResult> Update([FromBody] EditSecretaryDto secretary)
        {
            var listError = ValidPropertiesObject.ObjIsValid(secretary);
            if (listError.Count > 0)
                return await ResponseNullOrEmpty(listError);

            var result = _service.Update(secretary);
            return await Response(result, _service.Validate());
        }

    }
}
