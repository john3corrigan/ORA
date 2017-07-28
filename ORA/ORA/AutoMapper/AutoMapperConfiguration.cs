using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Lib.EFModels;
using Lib.ViewModels;

namespace ORA.AutoMapper {
    public class AutoMapperConfiguration {
        public static void ConfigMaps() {
            Mapper.Initialize(c => {
                c.CreateMap<Assessment, AssessmentVM>().ReverseMap();
                c.CreateMap<Assignment, AssignmentVM>().ReverseMap();
                c.CreateMap<CreateAssignmentVM, Assignment>().ReverseMap();
                c.CreateMap<Client, ClientVM>().ReverseMap();
                c.CreateMap<Employee, EmployeeVM>().ReverseMap();
                c.CreateMap<KPI, KPIVM>().ReverseMap();
                c.CreateMap<CreateKPIVM, KPI>().ReverseMap();
                c.CreateMap<Position, PositionVM>().ReverseMap();
                c.CreateMap<Lib.EFModels.Profile, ProfileVM>().ReverseMap();
                c.CreateMap<Project, ProjectVM>().ReverseMap();
                c.CreateMap<Role, RoleVM>().ReverseMap();
                c.CreateMap<Sprint, SprintVM>().ReverseMap();
                c.CreateMap<Story, StoryVM>().ReverseMap();
                c.CreateMap<Team, TeamVM>().ReverseMap();
                c.CreateMap<CreateTeamVM, Team>().ReverseMap();
                c.CreateMap<CreateProjectVM, Project>().ReverseMap();
            });
        }
    }
}