using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4_BusinessObjectModel
{
    [Table("t_users")]
    public class User
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

        public List<Role> Role { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public string Password { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}