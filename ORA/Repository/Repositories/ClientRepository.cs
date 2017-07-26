using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lib.ViewModels;
using Lib.EFModels;
using Lib.Interfaces;
using Repository.Context;

namespace Repository.Repositories {
    public class ClientRepository : BaseRespository<Client>, IClientRepository {

        public ClientRepository() : base(new RepositoryContext("ora")) {
            InitMap();
        }

        private void InitMap() {
            config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Client, ClientVM>().ReverseMap();
                cfg.CreateMap<Assignment, AssignmentVM>().ReverseMap();
                cfg.CreateMap<Story, StoryVM>().ReverseMap();
                cfg.CreateMap<Project, ProjectVM>().ReverseMap();
                cfg.CreateMap<Team, TeamVM>().ReverseMap();
            });
        }

        public List<ClientVM> GetAllClients() {
            var mapper = config.CreateMapper();
            return mapper.Map<List<ClientVM>>(DbSet.Include("Assignment")
                                                   .Include("Story")
                                                   .Include("Project")
                                                   .Include("Team"));
        }

        public ClientVM GetClientByID(int id) {
            var mapper = config.CreateMapper();
            var client = GetAllClients().Where(c => c.ClientID == id).FirstOrDefault();
            return mapper.Map<ClientVM>(client);
        }

        public void AddClient(ClientVM client) {
            var mapper = config.CreateMapper();
            Add(mapper.Map<Client>(client));
            Save();
        }

        public void UpdateClient(ClientVM client) {
            var mapper = config.CreateMapper();
            Update(mapper.Map<Client>(client));
            Save();
        }

        public void RemoveClient(ClientVM client) {
            var mapper = config.CreateMapper();
            Delete(client.ClientID);
            Save();
        }
    }
}
