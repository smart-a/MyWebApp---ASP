using MyAppData;
using MyAppData.Interfaces;
using MyAppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAppServices
{
    public class PictureService : IPictures
    {
       ApplicationDbContext _context;
        public PictureService(ApplicationDbContext context)
        {
            _context = context;
        }

        public long Add(Pictures res)
        {
            _context.Pictures.Add(res);
            long cID = _context.SaveChanges();
            return cID;
        }

        public long Delete(string UserId)
        {
            long ctID = 0;
            var ct = _context.Pictures.FirstOrDefault(b => b.UserId == UserId);
            if (ct != null)
            {
                _context.Pictures.Remove(ct);
                ctID = _context.SaveChanges();
            }
            return ctID;
        }


        public IEnumerable<Pictures> GetAll(string RefKey)
        {
            throw new NotImplementedException();
        }

        public Pictures GetId(long Id)
        {

            var res = _context.Pictures
                  .FirstOrDefault(b => b.Id == Id);
            return res;
        }

        public Pictures GetByUserId(string UserId)
        {

            var res = _context.Pictures
                  .FirstOrDefault(b => b.UserId == UserId);
            return res;
        }

        public string GetFilenameByUserId(string UserId)
        {

            var res = _context.Pictures
                  .FirstOrDefault(b => b.UserId == UserId);
            if (res != null)
            {
                return res.FileName;
            }
            else
            {
                return "user.png";
            }

        }

        public long Update(string UserId, Pictures pic)
        {
            int ctID = 0;
            var pa = _context.Pictures.Where(x => x.UserId == UserId).SingleOrDefault();
            if (pa != null)
            {
                pa.FileName = pic.FileName;
                ctID = _context.SaveChanges();
            }
            return ctID;
        }

        public long Update1(string UserId, string filename)
        {
            int ctID = 0;
            var pa = _context.Pictures.Where(x => x.UserId == UserId).SingleOrDefault();
            if (pa != null)
            {
                pa.FileName = filename;
                ctID = _context.SaveChanges();
            }
            return ctID;
        }
    }
}
