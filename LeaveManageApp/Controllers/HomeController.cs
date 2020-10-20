using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LeaveManageApp.Models;

//using LeaveManageApp.Repository;
using LeaveManageApp.Helper;
using System.Net.Http;
using System.ComponentModel.Design;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace LeaveManageApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //LeaveSystemContext _leave;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
  

        public async Task<IActionResult> Index()
        {
            return View();
        }
        
     
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}
