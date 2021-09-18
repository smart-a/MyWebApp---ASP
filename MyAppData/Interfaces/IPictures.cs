using System;
using System.Collections.Generic;
using System.Text;
using MyAppData.Models;

namespace MyAppData.Interfaces
{
    public interface IPictures
    {
        IEnumerable<Pictures> GetAll(string UserId);
        Pictures GetId(long Id);
        long Add(Pictures res);
        long Update(string UserId, Pictures pic);
        Pictures GetByUserId(string UserId);
        string GetFilenameByUserId(string UserId);
        long Delete(string UserId);
        long Update1(string UserId, string filename);
    }
}
