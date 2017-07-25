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
        KPIVM GetKPIByID(int KPIID);
        void AddKPI(KPIVM KPI);
        void UpdateKPI(KPIVM updatedKPI);
    }
}
