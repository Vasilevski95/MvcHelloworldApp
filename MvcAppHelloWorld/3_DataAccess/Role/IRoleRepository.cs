using System;
using System.Collections.Generic;
using _4_BusinessObjectModel;

namespace _3_DataAccess
{
    public interface IRoleRepository
    {
        List<Role> GetAll();
        Role GetByName(string roleName);
    }
}