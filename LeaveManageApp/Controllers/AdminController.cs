using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LeaveManageApp.Helper;
using LeaveManageApp.Controllers;
using LeaveManageApp.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace LeaveManageApp.Controllers
{
    public class AdminController : Controller
    {


        AdminApi _api = new AdminApi();
        public async Task<IActionResult> Index()
        {

            List<AuthorizationTable> employee = new List<AuthorizationTable>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/AuhtorizationTables");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<List<AuthorizationTable>>(result);

            }
            return View(employee);
        }
    }
}
