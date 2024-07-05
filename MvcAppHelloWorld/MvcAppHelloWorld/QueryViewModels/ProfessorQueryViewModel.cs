using System.ComponentModel.DataAnnotations;

namespace MvcAppHelloWorld.QueryViewModel
{
    public class ProfessorQueryViewModel : UsersQueryViewModel
    {
        [Display(Name = "Class subject")]
        public string ClassSubject { get; set; }

        [Display(Name = "Cabinet")]
        public string Cabinet { get; set; }
    }
}
