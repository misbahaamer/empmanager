using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Task.Domain.Common;

namespace Task.Domain.Entities
{
    public class Dependent : EntityBase
    {
        public int EmployeeKey { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public Employee Employee { get; set; }

    }
}
