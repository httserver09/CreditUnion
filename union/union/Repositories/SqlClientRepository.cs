using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using union.Interfaces;
using union.Models;

namespace union.Repositories
{
    public class SqlClientRepository : IClient
    {
        private readonly AppDbContext _context;


        public SqlClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public string AddClient(Client client)
        {
            _context.Add(client);
            _context.SaveChanges();
            return "Client added successfully";
        }

        public Client GetClient(int id)
        {
            //_logger.LogInformation("Attempting to retrieve business with ID: " + Id);
            return _context.clients.Find(id);
        }

        public IEnumerable<Client> GetClients()
        {
            //_logger.LogInformation("Attempting to retrieve list of businesses");
            return _context.clients;
        }

        public string RemoveClient(int id)
        {
            //_logger.LogInformation("Deleting team detail of ID: " + softwareId);

            Client client = _context.clients.Find(id);

            if (client != null)
            {
                _context.Remove(client);
                _context.SaveChanges();
            }

            return "Client deleted Successfully !";
        }

        public string UpdateClient(Client clientChanges)
        {
            //_logger.LogInformation("Attempting to update business changes");

            var tm = _context.clients.Attach(clientChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return "Updated Successfully !";
        }
    }
}
