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
        KPIVM GetKPIByKPIID(int KPIID);
        void CreateKPI(KPIVM KPI);
        void UpdateKPI(KPIVM updatedKPI);
    }
}
