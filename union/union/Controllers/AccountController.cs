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
    public class AccountController : ControllerBase
    {
        private readonly IAccount _accRepository;
        private readonly ILogger<ClientController> _logger;

        public AccountController(IAccount accRepository,
                            ILogger<ClientController> logger)
        {
            _accRepository = accRepository;
            _logger = logger;
        }

        [Route("Get")]
        public JsonResult Get()
        {
            try
            {
                //_logger.LogInformation("Retrieving list of known businesses");

                IEnumerable<Account> accounts = _accRepository.GetAccounts();

                //_logger.LogInformation("business list retrieved");

                return new JsonResult(accounts);
            }
            catch (Exception ex)
            {
                //log error
                //_logger.LogError("Error while retrieving businesses list: " + ex.Message.ToString());

                return new JsonResult("Error retrieving account list", ex.Message.ToString());
            }
        }

        [Route("Get/{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                //_logger.LogInformation("Retrieving business with ID: " + Id.ToString());

                Account account = _accRepository.GetAccount(id);

                //_logger.LogInformation("Retrieving business with ID: " + Id.ToString());

                return new JsonResult(account);
            }
            catch (Exception ex)
            {
                //log error
                //_logger.LogError("Error while retrieving business with ID: " + ex.Message.ToString());

                // throw 
                return new JsonResult("Error retrieving account with ID " + id, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("Post")]
        [Route("Post/{account}")]
        public JsonResult Post([FromBody] Account account)
        {
            try
            {
                //_logger.LogInformation("Adding new business to the system");

                string msg = _accRepository.AddAccount(account);

                //_logger.LogInformation("Added Successfully !");

                return new JsonResult(msg);
            }
            catch (Exception ex)
            {
                //log 
                //_logger.LogError("Error while attempting to add new business. Error  Details: " + ex.Message.ToString());

                return new JsonResult("Error occurred while adding new business", ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("Put")]
        public JsonResult Put([FromBody] Account accountChanges)
        {
            try
            {
                //_logger.LogInformation("Updating business changes. Object: " + new JsonResult(detailChanges));

                string response = _accRepository.UpdateAccount(accountChanges);

                //_logger.LogInformation("Updated Successfully");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error while trying to update business details. Error Details: " + ex.Message.ToString());

                return new JsonResult("Error occurred while updating account" + ex.Message.ToString());
            }
        }


        [HttpDelete]
        [Route("Delete/{accountid}")]
        public JsonResult Delete(int accountid)
        {
            try
            {
                //_logger.LogInformation("Deleting business with ID: " + Id);

                string response = _accRepository.RemoveAccount(accountid);

                //_logger.LogInformation("Deleted Successfully !");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error while trying to delete business detail. Error details: " + ex.Message.ToString());

                return new JsonResult("Error while deleting account", ex.Message.ToString());
            }
        }
    }
}
