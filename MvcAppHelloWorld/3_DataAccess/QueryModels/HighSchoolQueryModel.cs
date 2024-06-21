using System;
using System.ComponentModel.DataAnnotations;

namespace _3_DataAccess.QueryModels
{
    public class HighSchoolQueryModel : UserQueryModel
    {
        [Display(Name = "School name")]
        public string SchoolName { get; set; }

        [Display(Name = "Date of entry")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateOfEntry { get; set; }
    }
}