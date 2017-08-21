using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.InterfacesLogic
{
    public interface IKPILogic
    {
        List<KPIVM> GetAllKPIs();
        List<KPIVM> GetKPIByDate();
        List<KPIVM> GetMyKPIs(int ID);
        KPIVM GetKPIByID(int KPIID);
        CreateKPIVM GetCreateKPIByID(int KPIID);
        void AddKPI(CreateKPIVM newKPI);
        CreateKPIVM AddKPI(DateTime created);
        void UpdateKPI(KPIVM updatedKPI);
        List<KPIVM> GetKPIBySprintID(int SprintID);
        List<KPIVM> GetKPIByAssignmentID(int SprintID);
        List<KPIVM> GetKPIsForManager(int empID);
        List<KPIVM> GetKPIsForLead(int empID);
        List<KPIVM> GetIndividualKPIs(DateTime startDate, DateTime endDate);
        List<KPIVM> GetTeamsKPIs(DateTime startDate, DateTime endDate, int teamID);
        List<KPIVM> GetClientKPIs(DateTime startDate, DateTime endDate, int clientID);
        //void RemoveKPI(int KPIIDS);
    }
}
