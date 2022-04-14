using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Application.Features.Tasks.Commands.AddPayroll
{
    public class AddPayrollCommand :  IRequest<EmployeePayroll>
    {
        public int Id { get; set; }
    
    }
}
