using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace _4_BusinessObjectModel
{
    [Table("t_userroles")]
    public class UserRole
    {
        public Guid UserId { get; set; }
        public User User { get; set; }  

        public Guid RoleId { get; set; }
        public Role Role { get; set; }  
    }
}