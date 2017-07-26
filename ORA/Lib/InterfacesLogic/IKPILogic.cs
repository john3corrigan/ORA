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
        void AddKPI(CreateKPIVM newKPI);
        CreateKPIVM AddKPI();
        void UpdateKPI(KPIVM updatedKPI);
    }
}
