using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Task.Domain.Common;

namespace Task.Domain.Entities
{
    public class EmployeeBenefit : EntityBase
    {
        public int EmployeeKey { get; set; }
        public int DependentKey { get; set; }
        public int BenefitKey { get; set; }
        public decimal EmployeeCost { get; set; }
        public decimal DependentCost { get; set; }
        public decimal TotalCost { get; set; }

        [JsonIgnore]
        public Employee Employee { get; set; }
        [JsonIgnore]
        public Dependent Dependent { get; set; }
        [JsonIgnore]
        public Benefit Benefit { get; set; }
    }
}
