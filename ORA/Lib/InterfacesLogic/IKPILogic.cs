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
        CreateKPIVM GetCreateKPIByID(int KPIID);
        void AddKPI(CreateKPIVM newKPI);
        CreateKPIVM AddKPI(DateTime created);
        void UpdateKPI(KPIVM updatedKPI);
        //void RemoveKPI(int KPIIDS);
    }
}
