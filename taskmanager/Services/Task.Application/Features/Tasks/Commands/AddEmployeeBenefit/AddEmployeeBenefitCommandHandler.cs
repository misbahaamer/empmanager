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

namespace Task.Application.Features.Tasks.Commands.AddEmployeeBenefit
{
    public class AddEmployeeBenefitCommandHandler :  IRequestHandler<AddEmployeeBenefitCommand, EmployeeBenefit>
    {
        private readonly IEmployeeRepository _emprepository;
        private readonly IEmployeeBenefitRepository _empBenrepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddEmployeeBenefitCommandHandler> _logger;

        public AddEmployeeBenefitCommandHandler(IEmployeeBenefitRepository _empBenRepository, IEmployeeRepository emprepository, IMapper mapper, ILogger<AddEmployeeBenefitCommandHandler> logger)
        {
            _emprepository = emprepository;
            _empBenrepository = _empBenRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async  Task<EmployeeBenefit> Handle(AddEmployeeBenefitCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EmployeeBenefit>(request);
            var data = await _empBenrepository.SaveEmployeeBenefit(entity);
            return data;
        }

        
    }
}
