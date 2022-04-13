﻿using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Task.Application.Features.Tasks.Commands.AddEmployeeBenefit;
using Task.Application.Features.Tasks.Commands.AddTask;
using Task.Application.Features.Tasks.Commands.UpdateTask;
using Task.Application.Features.Tasks.Queries.GetEmployees;
using Task.Domain.Entities;

namespace Task.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetEmployees")]
        [ProducesResponseType(typeof(IEnumerable<EmployeesVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EmployeesVM>>> GetEmployees()
        {
            var query = new GetEmployeesQuery();
            var tasks = await _mediator.Send(query);
            return Ok(tasks);
        }


        [HttpPost(Name = "CalculateEmployeeCost")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeBenefit>> AddTask([FromBody] AddEmployeeBenefitCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        //[HttpPut(Name = "UpdateTask")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult> UpdateTask([FromBody] UpdateTaskCommand command)
        //{
        //    await _mediator.Send(command);
        //    return NoContent();
        //}


    }
}
