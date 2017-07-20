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
    public class SprintLogic
    {
        private ISprintRepository Sprints;

        public SprintLogic(ISprintRepository sprnt)
        {
            Sprints = sprnt;
        }

        public SprintVM GetSprintBySprintID(int SprintID)
        {
            throw new NotImplementedException();
        }

        public void UpdateSprint(SprintVM updatedSprint)
        {
            throw new NotImplementedException();
        }

        public void DeleteSprint(int sprintID)
        {
            throw new NotImplementedException();
        }

        public void CreateSprint(SprintVM sprint)
        {
            throw new NotImplementedException();
        }

        public List<SprintVM> GetAllSprints()
        {
            throw new NotImplementedException();
        }
    }
}
