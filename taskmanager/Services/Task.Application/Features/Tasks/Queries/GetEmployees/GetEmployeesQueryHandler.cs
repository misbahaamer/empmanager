using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task.Application.Contracts.Persistence;

namespace Task.Application.Features.Tasks.Queries.GetEmployees
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, List<EmployeesVM>>
    {
        private readonly IEmployeeRepository _empRepository;
        private readonly IDependentRepository _depRepository;
        private readonly IMapper _mapper;

        public GetEmployeesQueryHandler(IEmployeeRepository empRepository, IDependentRepository depRepository, IMapper mapper)
        {
            _empRepository = empRepository;
            _depRepository = depRepository;
            _mapper = mapper;
        }

        public async  Task<List<EmployeesVM>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _empRepository.GetEmployeesAndTheirDependents();
            var empdto =  _mapper.Map<List<EmployeesVM>>(employees);
            return empdto;
        }
    }
}
