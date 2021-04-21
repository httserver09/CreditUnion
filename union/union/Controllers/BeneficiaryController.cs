using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using union.Interfaces;
using union.Models;

namespace union.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator,Customer")]
    public class BeneficiaryController : ControllerBase
    {
        private readonly IBeneficiary _beneficiary;
        private readonly ILogger<BeneficiaryController> _logger;

        public BeneficiaryController(IBeneficiary beneficiary,
                            ILogger<BeneficiaryController> logger)
        {
            _beneficiary = beneficiary;
            _logger = logger;
        }

        [Route("Get")]
        public JsonResult Get()
        {
            try
            {
                //_logger.LogInformation("Retrieving list of known beneficiaries");

                IEnumerable<Beneficiary> beneficiaries = _beneficiary.GetBeneficiaries();

                //_logger.LogInformation("beneficiaries list retrieved");

                return new JsonResult(beneficiaries);
            }
            catch (Exception ex)
            {
                //log error
                //_logger.LogError("Error while retrieving businesses list: " + ex.Message.ToString());

                return new JsonResult("Error retrieving beneficiaries list", ex.Message.ToString());
            }
        }

        [Route("GetBeneficiariesOfAnAccount/{accountId}")]
        public JsonResult GetBeneficiariesOfAnAccount(int accountId)
        {
            try
            {
                //_logger.LogInformation("Retrieving list of known beneficiaries");

                IEnumerable<Beneficiary> beneficiaries = _beneficiary.GetBeneficiariesOfAnAccount(accountId);

                //_logger.LogInformation("beneficiaries list retrieved");

                return new JsonResult(beneficiaries);
            }
            catch (Exception ex)
            {
                //log error
                //_logger.LogError("Error while retrieving businesses list: " + ex.Message.ToString());

                return new JsonResult("Error retrieving beneficiaries list", ex.Message.ToString());
            }
        }

        [Route("Get/{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                //_logger.LogInformation("Retrieving business with ID: " + Id.ToString());

                Beneficiary beneficiary = _beneficiary.GetBeneficiary(id);

                //_logger.LogInformation("Retrieving business with ID: " + Id.ToString());

                return new JsonResult(beneficiary);
            }
            catch (Exception ex)
            {
                //log error
                //_logger.LogError("Error while retrieving business with ID: " + ex.Message.ToString());

                // throw 
                return new JsonResult("Error retrieving beneficiary with ID " + id, ex.Message.ToString());
            }
        }

        [HttpPost]
        [Route("Post")]
        [Route("Post/{beneficiary}")]
        public JsonResult Post([FromBody] Beneficiary beneficiary)
        {
            try
            {
                //_logger.LogInformation("Adding new business to the system");

                string msg = _beneficiary.AddBeneficiary(beneficiary);

                //_logger.LogInformation("Added Successfully !");

                return new JsonResult(msg);
            }
            catch (Exception ex)
            {
                //log 
                //_logger.LogError("Error while attempting to add new business. Error  Details: " + ex.Message.ToString());

                return new JsonResult("Error occurred while adding new beneficiary", ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("Put")]
        public JsonResult Put([FromBody] Beneficiary beneficiaryChanges)
        {
            try
            {
                //_logger.LogInformation("Updating business changes. Object: " + new JsonResult(detailChanges));

                string response = _beneficiary.UpdateBeneficiary(beneficiaryChanges);

                //_logger.LogInformation("Updated Successfully");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error while trying to update business details. Error Details: " + ex.Message.ToString());

                return new JsonResult("Error occurred while updating beneficiary Changes" + ex.Message.ToString());
            }
        }


        [HttpDelete]
        [Route("Delete/{beneficiaryId}")]
        public JsonResult Delete(int beneficiaryId)
        {
            try
            {
                //_logger.LogInformation("Deleting business with ID: " + Id);

                string response = _beneficiary.RemoveBeneficiary(beneficiaryId);

                //_logger.LogInformation("Deleted Successfully !");

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error while trying to delete business detail. Error details: " + ex.Message.ToString());

                return new JsonResult("Error while deleting beneficiary", ex.Message.ToString());
            }
        }
    }
}
