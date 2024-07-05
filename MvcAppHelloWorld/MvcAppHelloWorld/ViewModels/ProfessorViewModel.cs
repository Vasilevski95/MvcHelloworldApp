using System.ComponentModel.DataAnnotations;

namespace MvcAppHelloWorld.ViewModels
{
    public class ProfessorViewModel : UserViewModel
    {
        [Display(Name = "Class subject")]
        public string ClassSubject { get; set; }

        [Display(Name = "Cabinet")]
        public string Cabinet { get; set; }
    }
}
