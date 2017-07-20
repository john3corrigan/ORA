using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces {
    public interface IKPIRepository {
        List<KPIVM> GetAllKPIs();
        KPIVM GetKPIByID(int id);
        void AddKPI(KPIVM kpi);
        void UpdateKPI(KPIVM kpi);
    }
}
