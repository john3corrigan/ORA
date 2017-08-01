using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib.ViewModels;
using Repository.Repositories;
using Repository.Context;
using ORA.AutoMapper;

namespace Testing {
    class Program {
        private static AssessmentVM assessment;
        private static CreateAssignmentVM assignment;
        private static CreateKPIVM kpi;
        private static CreateTeamVM team;
        private static RoleVM role;
        private static PositionVM position;
        private static EmployeeVM employee;
        private static ClientVM client;
        private static SprintVM sprint;
        private static StoryVM story;
        private static CreateProjectVM project;
        private static ProfileVM profile;

        static void Main(string[] args) {
            AutoMapperConfiguration.ConfigMaps();
            InitProp();
            //Seed();
            CreateDatabase();
        }

        private static void CreateDatabase() {
            RepositoryContext context = new RepositoryContext("ora");
            context.Database.Delete();
            context.Database.Create();
        }

        //private static void Seed() {
        //    var AssRepo = new AssessmentRepository();
        //    var AssignRepo = new AssignmentRepository();
        //    var KPI = new KPIRepository();
        //    var TeamRepo = new TeamRepository();
        //    var RoleRepo = new RoleRepository();
        //    var PosRepo = new PositionRepository();
        //    var EmpRepo = new EmployeeRepository();
        //    var CliRepo = new ClientRepository();
        //    var SprRepo = new SprintRepository();
        //    var ProjRepo = new ProjectRepository();
        //    var ProfRepo = new ProfileRepository();
        //    var StoryRepo = new StoryRepository();
        //    Console.WriteLine("Adding position");
        //    PosRepo.AddPosition(position);
        //    Console.WriteLine("Adding profile");
        //    ProfRepo.AddProfile(profile);
        //    Console.WriteLine("Adding client");
        //    CliRepo.AddClient(client);
        //    Console.WriteLine("Addign story");
        //    StoryRepo.AddStory(story);
        //    Console.WriteLine("Adding employee");
        //    EmpRepo.AddEmployee(employee);
        //    Console.WriteLine("Adding role");
        //    RoleRepo.AddRole(role);
        //    Console.WriteLine("Adding team");
        //    TeamRepo.AddTeam(team);
        //    Console.WriteLine("Adding assignment");
        //    AssignRepo.AddAssignment(assignment);
        //    Console.WriteLine("Adding assessment");
        //    AssRepo.AddAssessment(assessment);
        //    Console.WriteLine("Adding project");
        //    ProjRepo.AddProject(project);
        //    Console.WriteLine("Adding sprint");
        //    SprRepo.AddSprint(sprint);
        //    Console.WriteLine("Adding KPI");
        //    KPI.AddKPI(kpi);
        //    Console.WriteLine("Done adding entities");
        //    Console.ReadKey();
        //}

        private static void InitProp() {
            assessment = new AssessmentVM() {
                AssignmentID = 1,
                TDProblemSolving = 0,
                TDQualityOfWork = 0,
                TDProductivity = 0,
                TDProductKnowledge = 0,
                TDComments = "test",
                CSRProfessionalismTeamwork = 0,
                CSRVerbalSkills = 0,
                CSRWrittenSkills = 0,
                CSRListeningSkills = 0,
                CSRComments = "test",
                ADAttendence = 0,
                ADEthiclBehavior = 0,
                ADMeetsDeadlines = 0,
                ADOrganizeDetailedWork = 0,
                ADComments = "test",
                TMResourceUse = 0,
                TMFeedBack = 0,
                TMTechnicalMonitoring = 0,
                TMAskingQuestions = 0,
                TMComments = "test",
                MIAttitudeWork = 0,
                MIGroomingAppearence = 0,
                MIPersonalGrowth = 0,
                MIPotencialAdvancement = 0,
                MIComments = "test",
                ActiveFlag = true,
                AssessmentID = 1,
                Modified = DateTime.Now,
                Created = DateTime.Now,
                ModifiedBy = "test",
                CreatedBy = "test"
            };

            kpi = new CreateKPIVM() {
                Points = 0,
                TCCreated = 0,
                TCExcuted = 0,
                TCFailed = 0,
                TCPassed = 0,
                DefectsFound = 0,
                DefectsFixed = 0,
                DefectsAccepted = 0,
                DefectsRejected = 0,
                DefectsDeferred = 0,
                CriticalDefects = 0,
                TestHrsPlanned = 0,
                TestHrsActual = 0,
                BugsFoundProduction = 0,
                TotalHrsFixingBugs = 0,
                AssignmentID = 1,
                ProjectID = 1,
                SprintID = 1,
                StoryID = 1,
                Modified = DateTime.Now,
                Created = DateTime.Now,
                CreatedBy = "test",
                ModifiedBy = "test"
            };

            sprint = new SprintVM() {
                SprintID = 1,
                SprintNumber = 1,
                SprintName = "test",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Modified = DateTime.Now,
                Created = DateTime.Now,
                ModifiedBy = "test",
                CreatedBy = "test"
            };

            assignment = new CreateAssignmentVM() {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                ClientID = 1,
                EmployeeID = 1,
                PositionID = 1,
                RoleID = 1,
                TeamID = 1,
                Modified = DateTime.Now,
                Created = DateTime.Now,
                ModifiedBy = "test",
                CreatedBy = "test"
            };

            client = new ClientVM() {
                ClientName = "test",
                ClientAbbreviation = "tst",
                Story = new List<StoryVM>() { story },
                Modified = DateTime.Now,
                Created = DateTime.Now,
                ModifiedBy = "test",
                CreatedBy = "test"
            };

            story = new StoryVM() {
                StoryName = "test",
                StoryNumber = 0,
                StoryStartDate = DateTime.Now,
                StoryEndDate = DateTime.Now,
                ClientID = 1,
                Client = client,
                Modified = DateTime.Now,
                Created = DateTime.Now,
                ModifiedBy = "test",
                CreatedBy = "test"
            };

            project = new CreateProjectVM() {
                ProjectName = "test",
                ProjectNumber = 0,
                ProjectStartDate = DateTime.Now,
                ProjectEndDate = DateTime.Now,
                ClientID = 1,
                Modified = DateTime.Now,
                Created = DateTime.Now,
                ModifiedBy = "test",
                CreatedBy = "test"
            };

            profile = new ProfileVM() {
                FirstName = "test",
                LastName = "test",
                PositionID = 1,
                Position = position,
                Country = "test",
                Zip = 30415,
                Education = new List<string>() { "test" },
                Industry = "test",
                Summary = "test",
                Modified = DateTime.Now,
                Created = DateTime.Now,
                ModifiedBy = "test",
                CreatedBy = "test"
            };

            employee = new EmployeeVM() {
                EmployeeNumber = "test",
                Password = "test",
                Salt = new byte[] { 0, 0, 0, 0 },
                EmployeeName = "test test",
                EmployeeFirstName = "test",
                EmployeeLastName = "test",
                EmployeeMI = "t",
                Email = "test@test.com",
                ActiveFlag = true,
                ProfileID = 1,
                Profile = profile,
                Modified = DateTime.Now,
                Created = DateTime.Now,
                ModifiedBy = "test",
                CreatedBy = "test"
            };

            role = new RoleVM() {
                RoleName = "test",
                Description = "test",
                Modified = DateTime.Now,
                Created = DateTime.Now,
                ModifiedBy = "test",
                CreatedBy = "test"
            };

            position = new PositionVM() {
                Modified = DateTime.Now,
                Created = DateTime.Now,
                ModifiedBy = "test",
                CreatedBy = "test"
            };

            team = new CreateTeamVM() {
                TeamName = "test",
                ClientID = 1,
                Client = client,
                Modified = DateTime.Now,
                Created = DateTime.Now,
                ModifiedBy = "test",
                CreatedBy = "test"
            };


        }
    }
}
