using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _4_BusinessObjectModel;

namespace _3_DataAccess.QueryModels
{
    public class UserQueryModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}