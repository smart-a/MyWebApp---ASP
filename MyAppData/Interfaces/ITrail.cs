using System;
using System.Collections.Generic;
using System.Text;
using MyAppData.Models;

namespace MyAppData.Interfaces
{
    public interface ITrail
    {
        IEnumerable<AuditTrail> GetAll();
        AuditTrail GetId(long Id);
        long Add(AuditTrail cl, string author);
        long Delete(long Id);
    }
}
