using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces {
    public interface ISprintRepository {
        List<SprintVM> GetAllSprints();
        SprintVM GetSprintByID(int id);
        void AddSprint(SprintVM sprint);
        void UpdateSprint(SprintVM sprint);
        void DeleteSprint(int id);
    }
}
