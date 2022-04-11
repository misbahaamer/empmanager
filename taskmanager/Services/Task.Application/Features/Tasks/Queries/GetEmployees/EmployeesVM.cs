using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Domain.Entities;

namespace Task.Application.Features.Tasks.Queries.GetEmployees
{
    public class EmployeesVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }


       
        public List<Dependent> Dependents { get; set; }
       
    }
}
