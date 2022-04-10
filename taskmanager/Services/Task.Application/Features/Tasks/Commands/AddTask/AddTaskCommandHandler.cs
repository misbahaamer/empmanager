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

namespace Task.Application.Features.Tasks.Commands.AddTask
{
    public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, int>
    {
        private readonly IEmployeeRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AddTaskCommandHandler> _logger;

        public AddTaskCommandHandler(IEmployeeRepository taskRepository, IMapper mapper, ILogger<AddTaskCommandHandler> logger)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            //var taskEntity = _mapper.Map<Employee>(request);
            //var newTask = await _taskRepository.AddAsync(taskEntity);
            //_logger.LogInformation($"Task is successfully created {newTask.Id}");
            //return newTask.Id;
            throw new NotImplementedException();
        }
    }
}
