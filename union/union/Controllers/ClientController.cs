using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using union.Interfaces;
using union.Models;

namespace union.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClient _clientRepository;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IClient clientRepository,
                            ILogger<ClientController> logger)
        {
            _clientRepository = clientRepository;
            _logger = logger;
        }

        [Route("Get")]
        public JsonResult Get()
        {
            try
            {
                //_logger.LogInformation("Retrieving list of known businesses");

                IEnumerable<Client> clients = _clientRepository.GetClients();

                //_logger.LogInformation("business list retrieved");

                return new JsonResult(clients);
            }
            catch (Exception ex)
            {
                //log error
                //_logger.LogError("Error while retrieving businesses list: " + ex.Message.ToString());

                return new JsonResult("Error retrieving clients list", ex.Message.ToString());
            }
        }

        [Route("Get/{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                //_logger.LogInformation("Retrieving business with ID: " + Id.ToString());

                Client client = _clientRepository.GetClient(id);

                //_logger.LogInformation("Retrieving business with ID: " + Id.ToString());

                return new JsonResult(client);
            }
            catch (Exception ex)
            {
                //log error
                //_logger.LogError("Error while retrieving business with ID: " + ex.Message.ToString());

                // throw 
                return new JsonResult("Error retrieving client with ID " + id, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("Post")]
        [Route("Post/{account}")]
        public JsonResult Post([FromBody] Client client)
        {
            try
            {
                //_logger.LogInformation("Adding new business to the system");

                string msg = _clientRepository.AddClient(client);

                //_logger.LogInformation("Added Successfully !");

                return new JsonResult(msg);
            }
            catch (Exception ex)
            {
                //log 
                //_logger.LogError("Error while attempting to add new business. Error  Details: " + ex.Message.ToString());

                return new JsonResult("Error occurred while adding new client", ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("Put")]
        public JsonResult Put([FromBody] Client clientChanges)
        {
            try
            {
                //_logger.LogInformation("Updating business changes. Object: " + new JsonResult(detailChanges));

                string response = _clientRepository.UpdateClient(clientChanges);

                //_logger.LogInformation("Updated Successfully");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error while trying to update business details. Error Details: " + ex.Message.ToString());

                return new JsonResult("Error occurred while updating client" + ex.Message.ToString());
            }
        }


        [HttpDelete]
        [Route("Delete/{clientId}")]
        public JsonResult Delete(int clientId)
        {
            try
            {
                //_logger.LogInformation("Deleting business with ID: " + Id);

                string response = _clientRepository.RemoveClient(clientId);

                //_logger.LogInformation("Deleted Successfully !");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error while trying to delete business detail. Error details: " + ex.Message.ToString());

                return new JsonResult("Error while deleting client", ex.Message.ToString());
            }
        }
    }
}
