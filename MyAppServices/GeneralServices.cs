using MyAppData;
using MyAppData.Interfaces;
using MyAppData.Models;
using MyAppData.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyAppServices
{
    public class GeneralServices : IGeneral
    {
        private ApplicationDbContext _context; // private field to store the context.
        private readonly IConfiguration _configuration;
        private IHostingEnvironment _hostingEnv;
        public GeneralServices(ApplicationDbContext context, IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _context = context;
            _hostingEnv = env;
    
        }
    

        public bool CheckPicExists(string UserId)
        {
            var existing = _context.Pictures.Where(x => x.UserId == UserId).FirstOrDefault();
            if (existing != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkFullNameExists(string fn)
        {
            var existingFN = _context.Applicants.Where(x => x.FullName == fn).FirstOrDefault();
            if (existingFN != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkTelExists(string Tel1)
        {
            var existing = _context.Applicants.Where(x=>x.Tel1==Tel1).FirstOrDefault();
            if (existing != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetDesig(string Id)
        {
            throw new NotImplementedException();
        }

        public string GetFullNameFromTel(string tel)
        {
            throw new NotImplementedException();
        }

        public string GetGender(string Id)
        {
            throw new NotImplementedException();
        }

      

        public IEnumerable<DisplayDetails> GetLkCountries()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DisplayDetails> GetLkDesignations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DisplayDetails> GetLkGenders()
        {
            var datasource = from x in _context.Gender.OrderBy(x => x.Name)
                             select new DisplayDetails
                             {
                                 Id = x.Id.ToString(),
                                 DisplayField = x.Name
                             };
            return datasource;


        }

       
        public IEnumerable<DisplayDetails> GetLkMaritalStatus()
        {
            var datasource = from x in _context.MaritalStatus.OrderBy(x => x.Id)
                             select new DisplayDetails
                             {
                                 Id = x.Id.ToString(),
                                 DisplayField = x.Name
                             };
            return datasource;


        }

       
       
      


        public IEnumerable<DisplayDetails> GetLkMedicalSpecialties()
        {
            throw new NotImplementedException();
        }

      

        public IEnumerable<DisplayDetails> GetLkProfession()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DisplayDetails> GetLkSpecialties()
        {
            throw new NotImplementedException();
        }

       
        public string GetMS(string Id)
        {
            throw new NotImplementedException();
        }

        public string GetNOKRel(string Id)
        {
            throw new NotImplementedException();
        }

       
       
        public string GetPic(string UserId)
        {
            string foldername = "Employees" + $@"\" + "Pictures";
            string q = _hostingEnv.WebRootPath + $@"\" + foldername + $@"\" + UserId;
            if (Directory.Exists(q))
            {
                string[] array1 = Directory.GetFiles(q);
                string fn = Path.GetFileName(array1[0]);
                //_session.SetString("Pic", "/Employees/Pictures/" + UserId + "/");
                return "/Employees/Pictures/" + UserId + "/" + fn;
            }
            else
            {
                return "/images/user.png";
            }

        }

        public int GetTrailActionId(string ActionName)
        {
            var query = _context.TrailActions.SingleOrDefault(x => x.Name == ActionName);
            return query.Id;
        }
     
        public string GetPreferredLocation(string Id)
        {
            throw new NotImplementedException();
        }

        public string GetProfession(string Id)
        {
            throw new NotImplementedException();
        }

        public string GetSpecialty(string Id)
        {
            throw new NotImplementedException();
        }

       
        public string GetUsersId(string Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DisplayDetails> GetLkStates()
        {
            var datasource = from x in _context.States.OrderBy(x => x.StatesId)
                             select new DisplayDetails
                             {
                                 Id = x.StatesId.ToString(),
                                 DisplayField = x.StateName
                             };
            return datasource;


        }
        public IEnumerable<DisplayDetails> GetLkLga()
        {
            var datasource = from x in _context.Lga.OrderBy(x => x.LgaId)
                             select new DisplayDetails
                             {
                                 Id = x.LgaId.ToString(),
                                 DisplayField = x.LgaName,
                                 SecondaryKey = x.StatesId.ToString()
                             };
            return datasource;


        }

      
    }
}
