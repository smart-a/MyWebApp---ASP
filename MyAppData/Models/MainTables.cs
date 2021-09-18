using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyAppData.Models
{
    [Table("TBL_TRAIL")]
    public class AuditTrail
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Trail action required")]
        public int TrailActionsId { get; set; }

        [Display(Name = "Trail Action")]
        public TrailActions TrailActions { get; set; }

        [Required(ErrorMessage = "User is required.")]
        [StringLength(50)]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Narrative required.")]
        [StringLength(400)]
        [Display(Name = "Narrative")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "No narrative provided yet.")]
        public string Narrative { get; set; }

        [StringLength(50)]
        public string IpAddress { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }


    }

    [Table("TBL_PICTURES")]
    public class Pictures
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(36)]
        public string UserId { get; set; }

        [StringLength(500)]
        [Display(Name = "Filepath")]
        public string FilePath { get; set; }

        [StringLength(64)]
        [Display(Name = "Filename")]
        public string FileName { get; set; }
    }

    [Table("TBL_APPLICANTS")]
    public class Applicants
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "Applicant Type")]
        [Required(ErrorMessage = "Applicant Type required")]
        public int ApplicantTypeId { get; set; }
        public ApplicantType ApplicantType { get; set; }

       

        [Display(Name = "Application Type")]
        [Required(ErrorMessage = "Application Type required")]
        public int ApplicationTypeId { get; set; }

        public ApplicationType ApplictionType { get; set; }


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
        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        [Required]
        public int MaritalStatusId { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

        [StringLength(300)]
        [Required]
        public string Address { get; set; }

        [Required]
        public int StatesId { get; set; }
        public States States { get; set; }

        [Required]
        public int LgaId { get; set; }
        public Lga Lga { get; set; }


        [Required]
        public int LkTradeId { get; set; }
        public LkTrade LkTrade { get; set; }

        [Required]
        public int DisabilityId { get; set; }
        public Disability Disability { get; set; }

        [Required]
        public int NumOfChildren { get; set; }

        [Required]
        public int AverageEarning { get; set; }


        [StringLength(36)]
        [Display(Name = "Created by")]
        public string CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "No Created date provided yet.")]
        public DateTime CreatedDate { get; set; }

        [StringLength(36)]
        [Display(Name = "Modified by")]
        public string ModifiedBy { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Modified Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "No Modified date provided yet.")]
        public DateTime ModifiedDate { get; set; }

        [StringLength(152)]
        public string FullName { get; set; }

        [Required]
        [StringLength(36)]
        public string RefKey { get; set; }


    }

    [Table("TBL_JWT_CREDENTIALS")]
    public partial class JWTUser
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
