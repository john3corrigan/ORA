using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.InterfacesLogic
{
     public interface ISprintLogic
    {
        List<SprintVM> GetAllSprints();
        SprintVM GetSprintByID(int SprintID);
        void AddSprint(SprintVM sprint);
        void UpdateSprint(SprintVM updatedSprint);
        void DeleteSprint(int sprintID);
    }
}
