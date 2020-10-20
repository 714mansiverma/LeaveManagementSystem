using System;
using System.Collections.Generic;

namespace Authorization.Models
{
    public partial class Employee
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public int? Age { get; set; }
        public string Department { get; set; }
        public int? NoOfLeaveLeft { get; set; }

        public virtual AuthorizationTable AuthorizationTable { get; set; }
        public virtual LeaveService LeaveService { get; set; }
    }
}
