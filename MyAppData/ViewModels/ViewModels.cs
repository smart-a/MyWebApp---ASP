using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyAppData.ViewModels
{
    public class DisplayDetails
    {
        public string Id { get; set; }
        public string DisplayField { get; set; }
        public string SecondaryKey { get; set; }
    }

    public class ApplicantsVM
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Applicant Type required")]
        public string ApplicantTypeId { get; set; }

        [Display(Name = "Application Type")]
        [Required(ErrorMessage = "Application Type required")]
        public string ApplicationTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }


        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(11)]
        public string Tel1 { get; set; }


        [Required]
        public string GenderId { get; set; }
       

        [Required]
        public string MaritalStatusId { get; set; }

        [StringLength(300)]
        [Required]
        public string Address { get; set; }

        [Required]
        public string StatesId { get; set; }

        [Required]
        public string LgaId { get; set; }


        [Required]
        public string LkTradeId { get; set; }

        [Required]
        public string DisabilityId { get; set; }

        [Required]
        public string NumOfChildren { get; set; }

        [Required]
        public string AverageEarning { get; set; }


        //[Required]
        public string RefKey { get; set; }


    }
    public class ResponseCVM
    {
        public string Description { get; set; }
        public string StatusDescription { get; set; }
        public string StatusCode { get; set; }
    }

}
