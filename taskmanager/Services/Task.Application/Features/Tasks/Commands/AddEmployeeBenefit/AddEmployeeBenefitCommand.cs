using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Application.Features.Tasks.Commands.AddEmployeeBenefit
{
    public class AddEmployeeBenefitCommand: IRequest<EmployeeBenefit>
    {
    
        public int EmployeeKey { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
