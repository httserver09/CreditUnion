using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using union.Models;

namespace union.Interfaces
{
    public interface IClient
    {
        IEnumerable<Client> GetClients();
        Client GetClient(int id);
        string AddClient(Client client);
        string UpdateClient(Client clientChanges);
        string RemoveClient(int id);
    }
}
