using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Authorization.Repository;
using Authorization.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Authorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthController));
        IConfiguration _config;
        IEmployeeRepo<AuthorizationTable> _emp;
        IAuth auth1;

        public AuthController(IConfiguration config,IEmployeeRepo<AuthorizationTable> emp,IAuth auth)
        {
            _config = config;
            auth1 = auth;
            _emp = emp;
        }
        [HttpPost]
        public IActionResult Login(AuthorizationTable employee)
        {
            _log4net.Info("GetRequest() called with json input");
            IActionResult response = Unauthorized();
            var user = auth1.AuthenticateUser(employee);
            if(user!=null)
            {
                var tokenstring = auth1.GenerateJSONWebToken();
                response = Ok(new { token = tokenstring });
            }
            return response;
        }
   
    }
}
