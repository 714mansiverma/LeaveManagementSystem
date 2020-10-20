using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using LeaveManageApp.Controllers;
using LeaveManageApp.Helper;
using LeaveManageApp.Models;
namespace LeaveManageApp
{
    public class client
    {
        public HttpClient EmployeeDetails()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44342");
            return client;
        }
       
        public HttpClient AuthClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44379");
            return client;
        }
        
    }
}
