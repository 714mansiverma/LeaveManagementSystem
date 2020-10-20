using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Repository
{
    public interface IAdmin<T>
    {
        IEnumerable<T> GetUserName();
        T GetById(string id);
        void AddDetail(T details);
    }
}
