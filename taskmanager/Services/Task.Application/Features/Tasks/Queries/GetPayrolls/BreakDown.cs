using System;

namespace Task.Application.Features.Tasks.Queries.GetPayrolls
{
    public class BreakDown
    {
        public DateTime  Date { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
        public decimal Deduction { get; set; }
    }
}