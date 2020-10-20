using System;
using System.Collections.Generic;

namespace Authorization.Models
{
    public partial class AuthorizationTable
    {
        public string UserName { get; set; }
        public string Pswd { get; set; }
        public string EmpId { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
