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
    public class LeaveController : Controller
    {
        
        LeaveApi _api = new LeaveApi();
        public async Task<IActionResult> Index()
        {
            
            List<LeaveService> leave = new List<LeaveService>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/LeaveServices");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                leave = JsonConvert.DeserializeObject<List<LeaveService>>(result);

            }
            return View(leave);
        }
    }
}
