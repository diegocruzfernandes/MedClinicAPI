using Flunt.Notifications;
using MedServer.Api.Security;
using MedServer.Domain.Dtos.UserDtos;
using MedServer.Domain.Entities;
using MedServer.Domain.Services;
using MedServer.Infra.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MedServer.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IUserService _service;
        private readonly IConfiguration _config;
        private User _user;

        public AccountController(IUserService service, IConfiguration config, IUow uow ) : base(uow) 
        {
            _service = service;
            _config = config;
        }

        [HttpPost]
        [Route("v1/account")]
        public async Task<IActionResult> Post([FromForm] AuthUserDto loginUser)
        {
            if (loginUser == null)
                return BadRequest("Usuário ou Senha nulos");

            if (string.IsNullOrEmpty(loginUser.Email) || string.IsNullOrEmpty(loginUser.Password))
                return BadRequest("Usuário ou Senha nulos");

            var identity = await GetClaims(loginUser);

            if (identity == null)
                return await Response(null, new List<Notification> { new Notification("User", "Usuário ou senha inválidos") });

            var jtb = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create(_config["secretyKey"]))
                                .AddSubject(_user.Email)
                                .AddIssuer(_config["issuer"])
                                .AddAudience(_config["audience"])
                                .AddNameId(_user.Id.ToString())
                                .AddClaim("Nickname", _user.Nickname)
                                .AddClaim("medclinic", identity)
                                .AddExpiry(2880)
                                .Build();

            var response = new
            {
                token = jtb,
                expire = 2,
                user = new
                {
                    id = _user.Id,
                    name = _user.Nickname,
                    email = _user.Email
                }
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }

        private Task<string> GetClaims(AuthUserDto loginUser)
        {
            var user = _service.GetByEmail(loginUser.Email);

            if (user == null)
                return Task.FromResult<string>(null);

             if(!user.Authenticate(loginUser.Email, loginUser.Password))
                return Task.FromResult<string>(null);

            _user = user;
            
            return Task.FromResult(user.Permission.ToString());
        }

    }
}
