using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyAppData;
using MyAppData.Interfaces;
using MyAppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAppServices
{
    public class ApplicantService : IApplicant
    {
        private readonly ApplicationDbContext _context;
        public ApplicantService(ApplicationDbContext context)
        {
            _context = context;
          
        }
       
        public async Task<Applicants> AddApplicant(Applicants appl, string author)
        {
            appl.CreatedDate = DateTime.UtcNow;
            appl.CreatedBy = author;
            appl.ModifiedDate = DateTime.UtcNow;
            appl.ModifiedBy = author;
            var result = await _context.Applicants.AddAsync(appl);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

       
        public async Task<Applicants> DeleteApplicant(long Id)
        {
            var result = await _context.Applicants
                .FirstOrDefaultAsync(e => e.Id == Id);
            if (result != null)
            {
                _context.Applicants.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }

       
        public async Task<IEnumerable<Applicants>> GetApplicants()
        {
            return await _context.Applicants.ToListAsync();
        }
        public async Task<Applicants> GetApplicant(long Id)
        {
            return await _context.Applicants
                .FirstOrDefaultAsync(e => e.Id == Id);
        }
        public async Task<Applicants> UpdateApplicant(Applicants applicant)
        {
            var result = await _context.Applicants
                .FirstOrDefaultAsync(e => e.Id == applicant.Id);

            if (result != null)
            {
                result.ApplicantTypeId = applicant.ApplicantTypeId;
                result.ApplicationTypeId = applicant.ApplicationTypeId;
                result.FirstName = applicant.FirstName;
                result.MiddleName = applicant.MiddleName;
                result.LastName = applicant.LastName;
                result.FullName = applicant.FullName;
                result.MaritalStatusId = applicant.MaritalStatusId;
                result.GenderId = applicant.GenderId;
                result.Address = applicant.Address;
                result.StatesId = applicant.StatesId;
                result.LgaId = applicant.LgaId;
                result.LkTradeId = applicant.LkTradeId;
                result.DisabilityId = applicant.DisabilityId;
                result.NumOfChildren = applicant.NumOfChildren;
                result.AverageEarning = applicant.AverageEarning;
                result.ModifiedDate = DateTime.UtcNow;
                result.ModifiedBy = applicant.ModifiedBy;
                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

     
    }
}
