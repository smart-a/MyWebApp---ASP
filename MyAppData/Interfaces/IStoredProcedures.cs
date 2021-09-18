using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppData.Interfaces
{
    public interface IStoredProcedures
    {
        IList<SelectListItem> GetRoles(string connectionString);
    }
}
