using System.ComponentModel.DataAnnotations;

namespace MvcAppHelloWorld.QueryViewModel
{
    public class StudentQueryViewModel : UsersQueryViewModel
    {
        [Display(Name = "College name")]
        public string CollegeName { get; set; }

        [Range(1900, 2100)]
        public int Generation { get; set; }
    }
}