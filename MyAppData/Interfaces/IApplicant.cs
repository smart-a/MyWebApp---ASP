using System.Collections.Generic;
using System.Threading.Tasks;
using MyAppData.Models;

namespace MyAppData.Interfaces
{
    public interface IApplicant
    {
    
        Task<Applicants> AddApplicant(Applicants appl, string author);
       
        Task<Applicants> GetApplicant(long Id);
        Task<Applicants> DeleteApplicant(long Id);
        Task<Applicants> UpdateApplicant(Applicants applicant);
        Task<IEnumerable<Applicants>> GetApplicants();

    }
}
