using System;
using System.ComponentModel.DataAnnotations;

namespace MvcAppHelloWorld.ViewModels
{
    public class  UserViewModel
    {
        [Key]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}