using Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.InterfacesLogic
{
    public interface IClientLogic
    {
        List<ClientVM> GetAllClients();
        ClientVM GetClientByID(int ClientID);
        void AddClient(ClientVM client);
        void UpdateClient(ClientVM updatedClient);
        void RemoveClient(int clientID);
    }
}
