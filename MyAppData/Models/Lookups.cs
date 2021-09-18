using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyAppData.Models
{
    [Table("TBL_LK_TRAIL_ACTIONS")]
    public class TrailActions
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Trail action Name required.")]
        [StringLength(50)]
        [Display(Name = "Trail Action")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "No Name provided yet.")]
        public string Name { get; set; }
    }
    [Table("TBL_LK_STATES")]
    public class States
    {
        [Key]
        public int StatesId { get; set; }

        [Required(ErrorMessage = "State Name required.")]
        [StringLength(50)]
        [Display(Name = "State")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "No Name provided yet.")]
        public string StateName { get; set; }
    }

    [Table("TBL_LK_LGA")]
    public class Lga
    {
        [Key]
        public int LgaId { get; set; }

        public int StatesId { get; set; }

        [Required(ErrorMessage = "State required")]
        [Display(Name = "State")]
        public States States { get; set; }

        [Required(ErrorMessage = "LGA Name required.")]
        [StringLength(50)]
        [Display(Name = "LGA")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "No Name provided yet.")]
        public string LgaName { get; set; }
    }
    [Table("TBL_LK_GENDERS")]
    public class Gender
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "gender Name required.")]
        [StringLength(50)]
        [Display(Name = "gender")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "No Name provided yet.")]
        public string Name { get; set; }
    }

    [Table("TBL_LK_MARITAL_STATUS")]
    public class MaritalStatus
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "marital status required.")]
        [StringLength(50)]
        [Display(Name = "marital status")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "No Name provided yet.")]
        public string Name { get; set; }
    }

    [Table("TBL_LK_APPLICANT_TYPE")]
    public class ApplicantType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Applicant type required.")]
        [StringLength(50)]
        [Display(Name = "Applicant Type")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "No Name provided yet.")]
        public string Name { get; set; }
    }

    [Table("TBL_LK_APPLICATION_TYPE")]
    public class ApplicationType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Application type required.")]
        [StringLength(50)]
        [Display(Name = "Application Type")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "No Name provided yet.")]
        public string Name { get; set; }
    }

    [Table("TBL_LK_TRADE")]
    public class LkTrade
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Application type required.")]
        [StringLength(50)]
        [Display(Name = "Application Type")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "No Name provided yet.")]
        public string Name { get; set; }
    }

    [Table("TBL_LK_DISABILITY")]
    public class Disability
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Application type required.")]
        [StringLength(50)]
        [Display(Name = "Application Type")]
        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "No Name provided yet.")]
        public string Name { get; set; }
    }
}
