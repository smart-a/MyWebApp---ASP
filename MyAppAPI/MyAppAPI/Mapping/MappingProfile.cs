using AutoMapper;
using MyAppData.Models;
using MyAppData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppAPI.Mapping
{
    public class MappingProfile : Profile
    {
 
            public MappingProfile()
            {
                CreateMap<Applicants, ApplicantsVM>();
                CreateMap<ApplicantsVM, Applicants>();

            }
    }
}
