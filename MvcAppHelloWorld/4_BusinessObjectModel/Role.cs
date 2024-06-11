using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4_BusinessObjectModel
{
    [Table("t_roles")]
    public class Role
    {
        public Guid RoleId { get; set; }
        
        public string RoleName { get; set; }
        
        public ICollection<User> User { get; set; }  
        public ICollection<UserRole> UserRoles { get; set; }  
    }
}