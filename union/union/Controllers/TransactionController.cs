using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using union.Interfaces;

namespace union.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransaction _transaction;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ITransaction transaction,
                            ILogger<TransactionController> logger)
        {
            _transaction = transaction;
            _logger = logger;
        }

        [Route("Get")]
        public JsonResult Get()
        {
            try
            {
                //_logger.LogInformation("Retrieving list of known businesses");

                IEnumerable<Models.Transaction> accounts = _transaction.GetTransactions();

                //_logger.LogInformation("business list retrieved");

                return new JsonResult(accounts);
            }
            catch (Exception ex)
            {
                //log error
                //_logger.LogError("Error while retrieving businesses list: " + ex.Message.ToString());

                return new JsonResult("Error retrieving transactions list", ex.Message.ToString());
            }
        }

        [Route("Get/{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                //_logger.LogInformation("Retrieving business with ID: " + Id.ToString());

                Models.Transaction transaction = _transaction.GetTransaction(id);

                //_logger.LogInformation("Retrieving business with ID: " + Id.ToString());

                return new JsonResult(transaction);
            }
            catch (Exception ex)
            {
                //log error
                //_logger.LogError("Error while retrieving business with ID: " + ex.Message.ToString());

                // throw 
                return new JsonResult("Error retrieving transaction with ID " + id, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("Post")]
        [Route("Post/{account}")]
        public JsonResult Post([FromBody] Models.Transaction transaction)
        {
            try
            {
                //_logger.LogInformation("Adding new business to the system");

                string msg = _transaction.AddTransaction(transaction);

                //_logger.LogInformation("Added Successfully !");

                return new JsonResult(msg);
            }
            catch (Exception ex)
            {
                //log 
                //_logger.LogError("Error while attempting to add new business. Error  Details: " + ex.Message.ToString());

                return new JsonResult("Error occurred while adding new transaction", ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("Put")]
        public JsonResult Put([FromBody] Models.Transaction transactionChanges)
        {
            try
            {
                //_logger.LogInformation("Updating business changes. Object: " + new JsonResult(detailChanges));

                string response = _transaction.UpdateTransaction(transactionChanges);

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

                string response = _transaction.RemoveTransaction(accountid);

                //_logger.LogInformation("Deleted Successfully !");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error while trying to delete business detail. Error details: " + ex.Message.ToString());

                return new JsonResult("Error while deleting transaction", ex.Message.ToString());
            }
        }
    }
}
