using System;
using System.Collections.Generic;
using System.Text;
using MyAppData.Models;

namespace MyAppData.Interfaces
{
    public interface IJWTUser
    {
        IEnumerable<JWTUser> GetAll();
        JWTUser GetId(string Id);
        int Add(JWTUser jwtu);
        void Delete(int Id);
    }
}
