using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Features.Tasks.Queries.GetEmployees
{
    public class GetEmployeesQuery : IRequest<List<EmployeesVM>>
    {
        public GetEmployeesQuery()
        {
        }
    }
}
