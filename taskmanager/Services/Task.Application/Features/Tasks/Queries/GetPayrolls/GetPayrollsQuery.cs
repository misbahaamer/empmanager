using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Application.Features.Tasks.Queries.GetPayrolls
{
    public class GetPayrollsQuery : IRequest<List<PayrollVM>>
    {
        public GetPayrollsQuery()
        {
        }
    }
}
