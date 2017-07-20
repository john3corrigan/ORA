using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;
using Lib.Interfaces;

namespace BusinessLogic.ORALogic
{
    public class RoleLogic
    {
        private IRoleRepository Roles;

        public RoleLogic(IRoleRepository rls)
        {
            Roles = rls;
        }

    }
}
