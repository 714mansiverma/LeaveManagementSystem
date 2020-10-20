using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using LeaveManageApp.Models;
using LeaveManageApp.Helper;
using LeaveManageApp.Controllers;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace LeaveManageApp.Controllers
{
    public class ClientController : Controller
    {
        client cs = new client();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       [HttpGet]
       public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create( Employee employee)
        {
            using (var httpClient=new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

                using(var res=await httpClient.PostAsync("https://localhost:44342/api/Employees",content))
                {
                    if(res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Access");
                    }
                    return View();
                }
            }

        }
        [HttpPost]
        public IActionResult Index(AuthorizationTable auth)
        {
            HttpClient client12 = cs.AuthClient();
            var contentType = new MediaTypeWithQualityHeaderValue
       ("application/json");
            client12.DefaultRequestHeaders.Accept.Add(contentType);
            string Data = JsonConvert.SerializeObject(auth);
            var contentData = new StringContent(Data,System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client12.PostAsync("api/Auth", contentData).Result;
            string jwtdata = response.Content.ReadAsStringAsync().Result;
            webtoken jwt = JsonConvert.DeserializeObject<webtoken>(jwtdata);
            if (jwt.Token == null)
                return RedirectToAction("Index");

            HttpContext.Session.SetString("token", jwt.Token);
            return RedirectToAction("Access");
        }
      
     
        public class webtoken
        {
            public string Token { get; set; }
        }
     
        [HttpGet]
        public async Task<IActionResult> Access()
        {
            List<Employee> employees = new List<Employee>();
            HttpClient client34 = cs.EmployeeDetails();
            HttpResponseMessage res = await client34.GetAsync("api/Employees");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<Employee>>(result);
            }
            return View(employees);
        }
      


    }
}
