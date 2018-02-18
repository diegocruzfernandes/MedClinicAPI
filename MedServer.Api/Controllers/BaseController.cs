using Flunt.Notifications;
using MedServer.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedServer.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    _uow.Commit();
                    return Ok(new
                    {
                        success = true,
                        data = result                        
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(new
                    {
                        success = false,
                        data = new[] { "Ocorreu uma falha  interna no servidor.", ex.Source + " - " + ex.Message }
                    });
                }
            }
            else
            {
                return Ok(new
                {
                    success = false,
                    data = notifications
                });
            }
        }

        public async Task<IActionResult> ResponseList(object result)
        {
             try
            {
                return Ok(result);
            }
            catch
            {
                return Ok(new
                {
                    success = false,
                    data = new[] { "Ocorreu uma folha interna no servidor." }
                });
            }
        }

        public async Task<IActionResult> ResponseNullOrEmpty(List<string> listError)
        {
            return Ok(new
            {
                success = false,
                errors = new[] { "Dados não preenchidos ou inválidos." },
                data = listError
            });
        }

        public async Task<IActionResult> ResponseNullOrEmpty()
        {
            return Ok(new
            {
                success = false,
                errors = new[] { "Dados não preenchidos ou inválidos." }
            });
        }
    }
}
