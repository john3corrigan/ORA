using System;
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

        public KPILogic(IKPIRepository kpi)
        {
            KPIs = kpi;
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
        public void AddKPI()
        {
            KPIs.AddKPI(newKPI);
        }
        public void AddKPI(CreateKPI newKPI)
        {
            KPIs.AddKPI(newKPI);
        }
    }
}
