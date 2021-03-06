﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lib.EFModels;
using Lib.ViewModels;
using Lib.Interfaces;
using Repository.Context;

namespace Repository.Repositories {
    public class KPIRepository : BaseRespository<KPI>, IKPIRepository {
        public KPIRepository() : base(new RepositoryContext("ora")) {
        }

        public List<KPIVM> GetAllKPIs()
        {
            return Mapper.Map<List<KPIVM>>(GetAll().ToList());
        }

        public List<KPIVM> GetKPIByDate()
        {
            return Mapper.Map<List<KPIVM>>(GetAll().ToList());
        }

        public List<KPIVM> GetMyKPIs(int ID)
        {
            var kpi = GetAllKPIs().Where(k => k.AssignmentID == ID).FirstOrDefault();
            return Mapper.Map<List<KPIVM>>(kpi);
        }

        public KPIVM GetKPIByID(int id) {
            var kpi = GetAllKPIs().Where(k => k.KPIID == id).FirstOrDefault();
            return Mapper.Map<KPIVM>(kpi);
        }
        public CreateKPIVM GetCreateKPIByID(int id)
        {
            var kpi = GetAllKPIs().Where(k => k.KPIID == id).FirstOrDefault();
            return Mapper.Map<CreateKPIVM>(kpi);
        }

        public void AddKPI(CreateKPIVM kpi) {
            Add(Mapper.Map<KPI>(kpi));
            Save();
        }

        public void UpdateKPI(KPIVM kpi) {
            Update(Mapper.Map<KPI>(kpi));
            Save();
        }

        public void DeleteKPI(int id) {
            Delete(id);
            Save();
        }
    }
}
