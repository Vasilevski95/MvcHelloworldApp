using System;
using System.ComponentModel.DataAnnotations;

namespace _4_BusinessObjectModel
{
    public class HighSchoolLearner : User
    {
        [Display(Name = "School name")]
        public string SchoolName { get; set; }

        [Required]
        [Display(Name = "Date of entry")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateOfEntry { get; set; }
    }
}