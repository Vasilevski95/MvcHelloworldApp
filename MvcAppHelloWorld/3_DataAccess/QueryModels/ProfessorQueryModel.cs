using System.ComponentModel.DataAnnotations;

namespace _3_DataAccess.QueryModels
{
    public class ProfessorQueryModel : UserQueryModel
    {
        [Display(Name = "Class subject")]
        public string ClassSubject { get; set; }

        [Display(Name = "Cabinet")]
        public string Cabinet { get; set; }
    }
}