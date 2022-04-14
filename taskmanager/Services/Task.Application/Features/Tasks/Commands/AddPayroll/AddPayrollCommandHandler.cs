using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;
using Task.Domain.Entities;

namespace Task.Application.Features.Tasks.Commands.AddPayroll
{
    public class AddPayrollCommandHandler : IRequestHandler<AddPayrollCommand, EmployeePayroll>
    {
        private readonly IEmployeeRepository _emprepository;
        private readonly IEmployeeBenefitRepository _empBenrepository;
        private readonly IPayrollRepository _payrollRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddPayrollCommandHandler> _logger;

        public AddPayrollCommandHandler(IEmployeeRepository emprepository, IEmployeeBenefitRepository empBenrepository, IPayrollRepository payrollRepository, IMapper mapper, ILogger<AddPayrollCommandHandler> logger)
        {
            _emprepository = emprepository;
            _empBenrepository = empBenrepository;
            _payrollRepository = payrollRepository;
            _mapper = mapper;
            _logger = logger;
        }

       

        public async  Task<EmployeePayroll> Handle(AddPayrollCommand request, CancellationToken cancellationToken)
        {
            var data = await _payrollRepository.SaveEmployeePayroll(request.Id);
            return data;
        }
    }
}
