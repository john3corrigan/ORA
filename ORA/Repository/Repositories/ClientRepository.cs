using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lib.ViewModels;
using Lib.EFModels;
using Lib.Interfaces;

namespace Repository.Repositories {
    public class ClientRepository : BaseRespository<Client, ClientVM>, IClientRepository {

        public ClientRepository() : base() { }

        public List<ClientVM> GetAllClients() {
            return Mapper.Map<List<ClientVM>>(dbset.Include("Metadata")
                                                   .Include("Assignment")
                                                   .Include("Story")
                                                   .Include("Project")
                                                   .Include("Team"));
        }

        public ClientVM GetClientByID(int id) {
            var client = GetAllClients().Where(c => c.ClientID == id).FirstOrDefault();
            return Mapper.Map<ClientVM>(client);
        }

        public void AddClient(ClientVM client) {
            Add(Mapper.Map<Client>(client));
            Save();
        }

        public void UpdateClient(ClientVM client) {
            Update(Mapper.Map<Client>(client));
            Save();
        }

        public void RemoveClient(ClientVM client) {
            Delete(client.ClientID);
            Save();
        }
    }
}
