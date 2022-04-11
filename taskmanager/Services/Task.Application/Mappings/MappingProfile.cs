using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Application.Features.Tasks.Commands.AddTask;
using Task.Application.Features.Tasks.Commands.UpdateTask;
using Task.Application.Features.Tasks.Queries.GetEmployees;
using Task.Application.Features.Tasks.Queries.GetTasksList;
using Task.Domain.Entities;

namespace Task.Application.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            // CreateMap<Employee, MyTaskVm>().ReverseMap();
            // CreateMap<Employee, AddTaskCommand>().ReverseMap();
            //CreateMap<Employee, UpdateTaskCommand>().ReverseMap();
            CreateMap<Employee, EmployeesVM>().ForMember(x => x.Dependents, a => a.MapFrom(b => b.Dependents)).ReverseMap();
        }
        
    }
}
