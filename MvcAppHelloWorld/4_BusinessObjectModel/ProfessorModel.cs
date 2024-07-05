using System.ComponentModel.DataAnnotations;

namespace _4_BusinessObjectModel
{
    public class ProfessorModel : User
    {
        [Display(Name = "Class subject")]
        public string ClassSubject { get; set; }

        [Display(Name = "Cabinet")]
        public string Cabinet { get; set; }
    }
}
