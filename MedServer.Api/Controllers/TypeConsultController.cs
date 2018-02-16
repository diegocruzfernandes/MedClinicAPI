using MedServer.Api.Shared;
using MedServer.Domain.Dtos.TypeConsultDtos;
using MedServer.Domain.Services;
using MedServer.Infra.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedServer.Api.Controllers
{
    public class TypeConsultController : BaseController
    {
        private readonly ITypeConsultService _service;

        public TypeConsultController(ITypeConsultService service, IUow uow) : base(uow)
        {
            _service = service;
        }

        [HttpPost]
        [Route("v1/typeConsult")]
        public async Task<IActionResult> Post([FromBody] CreateTypeConsultDto typeConsult)
        {
            var listError = ValidPropertiesObject.ObjIsValid(typeConsult);
            if (listError.Count > 0)
                return await ResponseNullOrEmpty(listError);

            var result = _service.Create(typeConsult);
            return await Response(result, _service.Validate());
        }

        [HttpGet]
        [Route("v1/typeConsult")]
        public async Task<IActionResult> Get()
        {
            var result = _service.Get();
            return await ResponseList(result);
        }

        [HttpGet]
        [Route("v1/typeConsult/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _service.Get(id);
            return await ResponseList(result);
        }

        [HttpDelete]
        [Route("v1/typeConsult/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _service.Delete(id);
            return await Response(result, _service.Validate());
        }

        [HttpPut]
        [Route("v1/typeConsult")]
        public async Task<IActionResult> Update([FromBody] EditTypeConsultDto typeConsult)
        {
            var listError = ValidPropertiesObject.ObjIsValid(typeConsult);
            if (listError.Count > 0)
                return await ResponseNullOrEmpty(listError);

            var result = _service.Update(typeConsult);
            return await Response(result, _service.Validate());
        }
    }
}
