using Lib.Interfaces;
using Lib.ViewModels;
using System;
using System.Collections.Generic;
using Lib.InterfacesLogic;

namespace BusinessLogic.ORALogic
{
    public class SprintLogic : ISprintLogic
    {
        private ISprintRepository Sprints;

        public SprintLogic(ISprintRepository sprnt)
        {
            Sprints = sprnt;
        }

        public SprintVM GetSprintByID(int sprintID)
        {
            return Sprints.GetSprintByID(sprintID);
        }

        public void UpdateSprint(SprintVM updatedSprint)
        {
            Sprints.UpdateSprint(updatedSprint);
        }

        public void DeleteSprint(int sprintID)
        {
            Sprints.DeleteSprint(sprintID);
        }

        public void AddSprint(SprintVM newSprint)
        {
            Sprints.AddSprint(newSprint);
        }

        public List<SprintVM> GetAllSprints()
        {
            return Sprints.GetAllSprints();
        }
    }
}
