using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;

namespace Task.Application.Features.Tasks.Queries.GetPayrolls
{
    public class GetPayrollsQyeryHandler : IRequestHandler<GetPayrollsQuery, List<PayrollVM>>
    {
        private readonly IPayrollRepository _payRepository;
        private readonly IMapper _mapper;

        public GetPayrollsQyeryHandler(IPayrollRepository payRepository, IMapper mapper)
        {
            _payRepository = payRepository;
            _mapper = mapper;
        }

        public async  Task<List<PayrollVM>> Handle(GetPayrollsQuery request, CancellationToken cancellationToken)
        {
            var pays = await _payRepository.GetEmployeePayrolls();
            var paydto = _mapper.Map<List<PayrollVM>>(pays);

            return paydto;
        }
    }
}
