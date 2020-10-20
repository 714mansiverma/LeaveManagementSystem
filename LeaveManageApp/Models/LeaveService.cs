using System;
using System.Collections.Generic;

namespace LeaveManageApp.Models
{
    public partial class LeaveService
    {
        public string EmpId { get; set; }
        public int NoOfDaysLeave { get; set; }
        public string EmpName { get; set; }
        public string Status { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
