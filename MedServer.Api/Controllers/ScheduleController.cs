﻿using MedServer.Api.Shared;
using MedServer.Domain.Dtos.SheduleDtos;
using MedServer.Domain.Services;
using MedServer.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MedServer.Api.Controllers
{
    public class ScheduleController : BaseController
    {
        private readonly IScheduleService _service;

        public ScheduleController(IScheduleService service, IUow uow) : base(uow)
        {
            _service = service;
        }

        [HttpPost]
        [Route("v1/schedule")]
        public async Task<IActionResult> Post([FromBody] CreateScheduleDto schedule)
        {
            var listError = ValidPropertiesObject.ObjIsValid(schedule);
            if (listError.Count > 0 || schedule == null)
                return await ResponseNullOrEmpty(listError);

            var result = _service.Create(schedule);
            return await Response(result, _service.Validate());
        }

        [HttpGet]
        [Route("v1/schedule")]
        public async Task<IActionResult> GetByRange(
          [FromQuery(Name = "page_size")]int page_size,
          [FromQuery(Name = "page")]int page,
          [FromQuery(Name = "name")]string name
          )
        {
            Object result;
            if(page <= 0 && page_size <= 0)
            {
                page = 1;
                page_size = 10;
            }

            var skip = (page - 1) * page_size;
                result = _service.GetAll(skip, page_size, name);
            return await ResponseList(result);
        }

        [HttpGet]
        [Route("v1/schedule/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _service.Get(id);
            return await ResponseList(result);
        }

        [HttpDelete]
        [Route("v1/schedule/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _service.Delete(id);
            return await Response(result, _service.Validate());
        }

        [HttpPut]
        [Route("v1/schedule")]
        public async Task<IActionResult> Update([FromBody] EditScheduleDto schedule)
        {
            var listError = ValidPropertiesObject.ObjIsValid(schedule);
            if (listError.Count > 0 || schedule == null)
                return await ResponseNullOrEmpty(listError);

            var result = _service.Update(schedule);
            return await Response(result, _service.Validate());
        }

    }
}
