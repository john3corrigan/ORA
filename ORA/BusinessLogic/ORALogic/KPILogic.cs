﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;
using Lib.Interfaces;
using Lib.InterfacesLogic;

namespace BusinessLogic.ORALogic
{
    public class KPILogic : IKPILogic
    {
        private IKPIRepository KPIs;
        private IAssignmentRepository Assignment;
        private IProjectRepository Project;
        private ISprintRepository Sprint;
        private IStoryRepository Story;

        public KPILogic(IKPIRepository kpi, 
            IAssignmentRepository assign, 
            IProjectRepository prjct, 
            ISprintRepository sprnt,
            IStoryRepository stry)
        {
            KPIs = kpi;
            Assignment = assign;
            Project = prjct;
            Sprint = sprnt;
            Story = stry;
        }

        public KPIVM GetKPIByID(int Id)
        {
            return KPIs.GetKPIByID(Id);
        }

        public List<KPIVM> GetAllKPIs()
        {
            return KPIs.GetAllKPIs();
        }

        public void UpdateKPI(KPIVM updatedKPI)
        {
            KPIs.UpdateKPI(updatedKPI);
        }
        public CreateKPIVM AddKPI()
        {
            CreateKPIVM create = new CreateKPIVM() {
                AssignmentList = Assignment.GetAllAssignments(),
                ProjectList = Project.GetAllProjects(),
                SprintList = Sprint.GetAllSprints(),
                StoryList = Story.GetAllStories()
            };
            return create;
        }
        public void AddKPI(CreateKPIVM newKPI)
        {
            KPIs.AddKPI(newKPI);
        }
    }
}
