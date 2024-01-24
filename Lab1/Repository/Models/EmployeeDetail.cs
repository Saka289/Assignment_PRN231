using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class EmployeeDetail
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? Age { get; set; }
        public string? Gender { get; set; }
        public string? Address { get; set; }
    }
}
