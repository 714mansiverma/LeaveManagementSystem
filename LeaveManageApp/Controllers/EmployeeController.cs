using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeaveManageApp.Models;
using LeaveManageApp.Helper;
using System.Net.Http;
using Newtonsoft.Json;

namespace LeaveManageApp.Controllers
{
    public class EmployeeController : Controller
    {
     

        EmployeeApi _api = new EmployeeApi();
        public async Task<IActionResult> Index()
        {
           
            List<Employee> employee = new List<Employee>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Employees");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<List<Employee>>(result);

            }
            return View(employee);
        }
    }
}
