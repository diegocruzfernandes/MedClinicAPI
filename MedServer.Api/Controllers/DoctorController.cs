using MedServer.Domain.Dtos.Doctor;
using MedServer.Domain.Services;
using MedServer.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Post([FromBody] CreateDoctorDto doctor)
        {
            var result = _service.Create(doctor);
            return await Response(result, _service.Validate());
        }

        [HttpGet]
        [Route("v1/doctor")]
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
        [Route("v1/doctor/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _service.Get(id);
            return await ResponseList(result);
        }

        [HttpDelete]
        [Route("v1/doctor/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _service.Delete(id);
            return await Response(result, _service.Validate());
        }

        [HttpPut]
        [Route("v1/doctor")]
        public async Task<IActionResult> Update([FromBody] EditDoctorDto doctor)
        {
            var result = _service.Update(doctor);
            return await Response(result, _service.Validate());
        }
    }
}
