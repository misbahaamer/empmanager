using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Task.Application.Features.Tasks.Commands.AddEmployeeBenefit;
using Task.Application.Features.Tasks.Commands.AddPayroll;
using Task.Application.Features.Tasks.Queries.GetEmployees;
using Task.Application.Features.Tasks.Queries.GetPayrolls;
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

        [HttpGet("GetEmployees", Name = "GetEmployees")]
        [ProducesResponseType(typeof(IEnumerable<EmployeesVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EmployeesVM>>> GetEmployees()
        {
            var query = new GetEmployeesQuery();
            var emps = await _mediator.Send(query);
            return Ok(emps);
        }

        [HttpGet("GetPayrolls", Name = "GetPayrolls")]
        [ProducesResponseType(typeof(IEnumerable<PayrollVM>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<PayrollVM>>> GetPayrolls()
        {
            var query = new GetPayrollsQuery();
            var pays = await _mediator.Send(query);
            return Ok(pays);
        }


        [HttpPost("CalculateEmployeeCost", Name = "CalculateEmployeeCost")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeBenefit>> CalculateEmployeeCost([FromBody] AddEmployeeBenefitCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("SaveEmployeePayroll", Name = "SaveEmployeePayroll")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeePayroll>> SaveEmployeePayroll([FromBody] AddPayrollCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }




    }
}
