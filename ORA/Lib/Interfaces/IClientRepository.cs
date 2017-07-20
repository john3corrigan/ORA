using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Interfaces {
    public interface IClientRepository {
        List<ClientVM> GetAllClients();
        ClientVM GetClientByID(int id);
        void AddClient(ClientVM client);
        void UpdateClient(ClientVM client);
        void RemoveClient(ClientVM client);
    }
}
