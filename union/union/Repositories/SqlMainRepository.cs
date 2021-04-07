using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using union.Interfaces;
using union.Models;

namespace union.Repositories
{
    public class SqlMainRepository : IMain
    {
        private readonly AppDbContext _context;

        public SqlMainRepository(AppDbContext context)
        {
            _context = context;
        }

        public string AddAccount(Account account)
        {
            try
            {
                _context.Add(account);
                _context.SaveChanges();
                return "Account added successfully";
            }
            catch (Exception ex)
            {
                //log error
                return "Error occurred while adding business !";
            }
        }

        public Account GetAccount(int id)
        {
            try
            {
                //_logger.LogInformation("Attempting to retrieve business with ID: " + Id);

                return _context.accounts.Find(id);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error while trying to get business with ID: " + Id + " - " + ex.Message.ToString());

                throw;
            }
        }

        public IEnumerable<Account> GetAccounts()
        {
            try
            {
                //_logger.LogInformation("Attempting to retrieve list of businesses");

                return _context.accounts;
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error occured while attempting to get the list of businesses:" + ex.Message.ToString());

                throw;
            }
        }

        public string RemoveAccount(int id)
        {
            try
            {
                //_logger.LogInformation("Deleting team detail of ID: " + softwareId);

                Account account = _context.accounts.Find(id);

                if (account != null)
                {
                    _context.Remove(account);
                    _context.SaveChanges();
                }

                return "Account deleted Successfully !";
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error occured while attempting to delete team. Detail: " + ex.Message.ToString());

                return "Account deletion not successful";
            }
        }

        public string UpdateAccount(Account accountChanges)
        {
            try
            {
                //_logger.LogInformation("Attempting to update business changes");

                var tm = _context.accounts.Attach(accountChanges);
                tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();

                return "Updated Successfully !";
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error occured while attempting to update member: " + ex.Message.ToString());

                return "Error occured while attempting to update account !";
            }
        }
    }
}
