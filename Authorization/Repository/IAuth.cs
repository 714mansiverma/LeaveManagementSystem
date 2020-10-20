using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorization.Models;
using Authorization.Repository;

namespace Authorization.Repository
{
   public interface IAuth
    {
        string GenerateJSONWebToken();
        AuthorizationTable AuthenticateUser(AuthorizationTable user);
    }
}
