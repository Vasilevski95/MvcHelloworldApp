using System;
using System.ComponentModel.DataAnnotations;

namespace MvcAppHelloWorld.QueryViewModel
{
    public class HighSchoolQueryViewModel : UsersQueryViewModel
    {
        [Display(Name = "School name")]
        public string SchoolName { get; set; }

        [Display(Name = "Date of entry")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateOfEntry { get; set; }
    }
}