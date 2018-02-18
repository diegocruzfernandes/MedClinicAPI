using MedServer.Api.Shared;
using MedServer.Domain.Dtos.UserDtos;
using MedServer.Domain.Services;
using MedServer.Infra.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedServer.Api.Controllers
{
    [Authorize(Policy = "Doctors")]
    public class UserController : BaseController
    {
        private readonly IUserService _service;

        public UserController(IUserService service, IUow uow) : base(uow)
        {
            _service = service;
        }

        [HttpGet]
        [Route("v1/user")]
        public async Task<IActionResult> Get()
        {
            var result = _service.Get();
            return await ResponseList(result);
        }

        [HttpGet]
        [Route("v1/user/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _service.Get(id);
            return await ResponseList(result);
        }

        [HttpDelete]
        [Route("v1/user/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _service.Delete(id);
            return await Response(result, _service.Validate());
        }

        [HttpPut]
        [Route("v1/user")]
        public async Task<IActionResult> Update([FromBody] EditUserDto user)
        {
            var listError = ValidPropertiesObject.ObjIsValid(user);
            if (listError.Count > 0)
                return await ResponseNullOrEmpty(listError);

            var result = _service.Update(user);
            return await Response(result, _service.Validate());
        }

        [HttpGet]
        [Route("v1/user/{id}/resetpass")]
        public async Task<IActionResult> ResetPassword(int id)
        {
            var result = _service.ResetPassword(id);
            return await Response(result, _service.Validate());
        }
    }
}
