using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lib.ViewModels;
using Lib.EFModels;

namespace Repository.Repositories {
    public class ClientRepository : BaseRespository<Client, ClientVM> {

        public ClientRepository() : base() { }

        public List<ClientVM> GetAllClients() {
            //TODO add includes
            return Mapper.Map<List<ClientVM>>(GetAll());
        }

        public ClientVM GetClientByID(int id) {
            return Mapper.Map<ClientVM>(GetByID(id));
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
