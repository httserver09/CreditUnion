using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using union.Interfaces;
using union.Models;

namespace union.Repositories
{
    public class SqlClient_Repository : IClient
    {
        private readonly AppDbContext _context;


        public SqlClient_Repository(AppDbContext context)
        {
            _context = context;
        }

        public string AddClient(Client client)
        {

            try
            {
                _context.Add(client);
                _context.SaveChanges();
                return "Client added successfully";
            }
            catch (Exception ex)
            {
                //log error
                return "Error occurred while adding client !";
            }
        }

        public Client GetClient(int id)
        {
            try
            {
                //_logger.LogInformation("Attempting to retrieve business with ID: " + Id);

                return _context.clients.Find(id);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error while trying to get business with ID: " + Id + " - " + ex.Message.ToString());

                throw;
            }
        }

        public IEnumerable<Client> GetClients()
        {
            try
            {
                //_logger.LogInformation("Attempting to retrieve list of businesses");

                return _context.clients;
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error occured while attempting to get the list of businesses:" + ex.Message.ToString());

                throw;
            }
        }

        public string RemoveClient(int id)
        {
            try
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
            catch (Exception ex)
            {
                //_logger.LogError("Error occured while attempting to delete team. Detail: " + ex.Message.ToString());

                return "Client deletion not successful";
            }
        }

        public string UpdateClient(Client clientChanges)
        {
            try
            {
                //_logger.LogInformation("Attempting to update business changes");

                var tm = _context.clients.Attach(clientChanges) ;
                tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                return "Updated Successfully !";
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error occured while attempting to update member: " + ex.Message.ToString());

                return "Error occured while attempting to update clients !";
            }
        }
    }
}
