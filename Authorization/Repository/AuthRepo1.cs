using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorization.Repository;
using Authorization.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Authorization.Repository
{
    public class AuthRepo1 : IAuth
    {

        private IConfiguration _config;
        IEmployeeRepo<AuthorizationTable> _repo;
        
        public AuthRepo1(IConfiguration config, IEmployeeRepo<AuthorizationTable> repo)
        {
            _config = config;
            _repo = repo;
            
        }
        public AuthorizationTable AuthenticateUser(AuthorizationTable authorization)
        {
            var user = _repo.GetAll();
            foreach (var i in user)
            {
                if (i.UserName == authorization.UserName && i.Pswd == authorization.Pswd && i.EmpId == authorization.EmpId)
                {
                    return authorization;
                }

            }
            return null;
        }
        public string GenerateJSONWebToken()
        {
           // var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credential = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["JWT:Issuer"], _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(30), signingCredentials: credential);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
