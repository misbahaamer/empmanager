using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
            CreateMap<Employee, EmployeesVM>().ForMember(x => x.Dependents, a => a.MapFrom(b => b.Dependents)).ReverseMap();
        }
        
    }
}
