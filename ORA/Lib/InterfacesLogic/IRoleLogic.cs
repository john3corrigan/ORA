using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.InterfacesLogic
{
    public interface IRoleLogic
    {
        List<RoleVM> GetAllRoles();
        RoleVM GetRoleByID(int id);
        void AddRole(RoleVM role);
        void UpdateRole(RoleVM role);
        void DeleteRole(int roleID);
    }
}
