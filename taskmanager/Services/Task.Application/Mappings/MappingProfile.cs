using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Features.Tasks.Commands.AddEmployeeBenefit;
using Task.Application.Features.Tasks.Commands.AddTask;
using Task.Application.Features.Tasks.Commands.UpdateTask;
using Task.Application.Features.Tasks.Queries.GetEmployees;

using Task.Domain.Entities;

namespace Task.Application.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<EmployeeBenefit, AddEmployeeBenefitCommand>().ForMember(x => x.EmployeeKey, a => a.MapFrom(b => b.EmployeeKey)).ForMember(x => x.CreatedDate, a=> a.MapFrom(b => b.CreatedDate)).ReverseMap();
            CreateMap<Employee, EmployeesVM>().ForMember(x => x.Dependents, a => a.MapFrom(b => b.Dependents)).ReverseMap();
        }
        
    }
}
