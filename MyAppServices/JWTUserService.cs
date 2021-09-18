using MyAppData;
using MyAppData.Interfaces;
using MyAppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAppServices
{
    public class JWTUserService : IJWTUser
    {
        private readonly ApplicationDbContext _context;
        public JWTUserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(JWTUser jwtu)
        {
            _context.JWTUser.Add(jwtu);
            int cID = _context.SaveChanges();
            return cID;
        }

        public void Delete(int Id)
        {
            int ctID = 0;
            var user = _context.JWTUser.FirstOrDefault(b => b.UserId == Id);
            if (user != null)
            {
                _context.JWTUser.Remove(user);
                ctID = _context.SaveChanges();
            }
        }



        public IEnumerable<JWTUser> GetAll()
        {
            var c = _context.JWTUser.OrderBy(x => x.UserName).ToList();
            return c;
        }

        public JWTUser GetId(string Id)
        {
            var res = _context.JWTUser
              .FirstOrDefault(b => b.UserName == Id);
            return res;
        }
    }
}
