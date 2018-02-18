using MedServer.Api.Shared;
using MedServer.Domain.Dtos.DoctorDtos;
using MedServer.Domain.Services;
using MedServer.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedServer.Api.Controllers

    public class DoctorController : BaseController
    {
        private readonly IDoctorService _serviceDoctor;
      
        public DoctorController(IDoctorService serviceDoctor, IUow uow) : base(uow)
        {
            _serviceDoctor = serviceDoctor;          
        }

        [HttpPost]
        [Route("v1/doctor")]
        public async Task<IActionResult> Post([FromBody] CreateDoctorDto doctor)
        {
            var listError = ValidPropertiesObject.ObjIsValid(doctor);
            if (listError.Count > 0)
                return await ResponseNullOrEmpty(listError);

            var result = _serviceDoctor.Create(doctor);
            return await Response(result, _serviceDoctor.Validate());
        }

        [HttpGet]
        [Route("v1/doctor")]
        public async Task<IActionResult> GetByRange(
          [FromQuery(Name = "page_size")]int page_size,
          [FromQuery(Name = "page")]int page)
        {
            if (page_size == 0 && page == 0)
            {
                var result = _serviceDoctor.Get();
                return await ResponseList(result);
            }
            else
            {
                var skip = (page - 1) * page_size;
                var result = _serviceDoctor.Get(skip, page_size);
                return await ResponseList(result);
            }
        }

        [HttpGet]
        [Route("v1/doctor/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _serviceDoctor.Get(id);
            return await ResponseList(result);
        }
           
        [HttpDelete]
        [Route("v1/doctor/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _serviceDoctor.Delete(id);
            return await Response(result, _serviceDoctor.Validate());
        }

        [HttpPut]
        [Route("v1/doctor")]
        public async Task<IActionResult> Update([FromBody] EditDoctorDto doctor)
        {
            var listError = ValidPropertiesObject.ObjIsValid(doctor);
            if (listError.Count > 0)
                return await ResponseNullOrEmpty(listError);

            var result = _serviceDoctor.Update(doctor);
            return await Response(result, _serviceDoctor.Validate());
        }
    }
}
