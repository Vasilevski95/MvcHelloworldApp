using System.ComponentModel.DataAnnotations;

namespace _3_DataAccess.QueryModels
{
    public class StudentQueryModel : UserQueryModel
    {
        [Display(Name = "College name")]
        public string CollegeName { get; set; }

        [Range(1900, 2100)]
        public int Generation { get; set; }
    }
}