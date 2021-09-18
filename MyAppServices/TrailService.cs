using MyAppData;
using MyAppData.Interfaces;
using MyAppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAppServices
{
    public class TrailService : ITrail
    {
        ApplicationDbContext _context;
        public TrailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public long Add(AuditTrail cl, string author)
        {
            cl.UserId = author;
            cl.TimeStamp = DateTime.UtcNow;
            _context.AuditTrail.Add(cl);
            long cID = _context.SaveChanges();
            return cID;
        }

        public long Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuditTrail> GetAll()
        {
            var c = _context.AuditTrail.OrderByDescending(x => x.TimeStamp).ToList();
            return c;
        }

        public AuditTrail GetId(long Id)
        {
            throw new NotImplementedException();
        }
    }
}

