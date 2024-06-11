using System.ComponentModel.DataAnnotations;

namespace _4_BusinessObjectModel
{
    public class StudentLearner : User
    {
        [Display(Name = "College name")]
        public string CollegeName { get; set; }

        [Range(1900, 2100)]
        public int Generation { get; set; }
    }
}