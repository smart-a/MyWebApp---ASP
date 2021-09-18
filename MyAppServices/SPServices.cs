using Microsoft.AspNetCore.Mvc.Rendering;
using MyAppData.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MyAppServices
{
    public class SPServices : IStoredProcedures
    {
        public IList<SelectListItem> GetRoles(string connectionString)
        {


            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                // 1.  create a command object identifying the stored procedure
                NpgsqlCommand cmd = new NpgsqlCommand("core.getroles", conn);

                // 2. set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                // execute the command
                using (var rdr = cmd.ExecuteReader())
                {
                    IList<SelectListItem> result = new List<SelectListItem>();
                    //3. Loop through rows
                    while (rdr.Read())
                    {
                        //Get each column
                        result.Add(new SelectListItem()
                        {
                            Value = rdr.GetString(0),
                            Text = rdr.GetString(1)
                        });
                    }

                    return result;
                }
            }

        }
    }
}
