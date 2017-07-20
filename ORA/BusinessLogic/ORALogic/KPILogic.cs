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
    public class KPILogic
    {
        private IKPIRepository KPIs;

        public KPILogic(IKPIRepository kpi)
        {
            KPIs = kpi;
        }

        public KPIVM GetKPIByKPIID(int KPIID)
        {
            throw new NotImplementedException();
        }

        public List<KPIVM> GetAllKPIs()
        {
            throw new NotImplementedException();
        }

        public void UpdateKPI(KPIVM updatedKPI)
        {
            throw new NotImplementedException();
        }

        public void CreateKPI(KPIVM KPI)
        {
            throw new NotImplementedException();
        }
    }
}
