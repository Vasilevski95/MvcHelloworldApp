using System;
using System.ComponentModel.DataAnnotations;

namespace MvcAppHelloWorld.ViewModels
{
    public class HighSchoolViewModel : UserViewModel
    {
        [Display(Name = "School name")]
        public string SchoolName { get; set; }
        [Required]
        [Display(Name = "Date of entry")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateOfEntry { get; set; }
    }
}