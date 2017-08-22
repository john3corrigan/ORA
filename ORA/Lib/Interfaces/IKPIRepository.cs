using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces
{
    public interface IKPIRepository
    {
        List<KPIVM> GetAllKPIs();
        List<KPIVM> GetMyKPIs(int ID);
        KPIVM GetKPIByID(int id);
        CreateKPIVM GetCreateKPIByID(int id);
        void AddKPI(CreateKPIVM kpi);
        void UpdateKPI(KPIVM kpi);
        //void DeleteKPI(int id);
    }
}
