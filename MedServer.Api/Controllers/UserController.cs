using MedServer.Domain.Dtos.User;
using MedServer.Domain.Services;
using MedServer.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedServer.Api.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _service;

        public UserController(IUserService service, IUow uow) : base(uow)
        {
            _service = service;
        }

        [HttpPost]
        [Route("v1/user")]
        public async Task<IActionResult> Post([FromBody] CreateUserDto user)
        {
            var result = _service.Create(user);
            return await Response(result, _service.Validate());
        }

        [HttpGet]
        [Route("v1/user")]
        public async Task<IActionResult> Get()
        {
            var result = _service.Get();
            return await ResponseList(result);
        }
    }
}
