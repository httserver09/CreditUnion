using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using union.Interfaces;
using union.Models;

namespace union.Repositories
{
    public class SqlAccountRepository : IAccount
    {
        private readonly AppDbContext _context;

        public SqlAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public string AddAccount(Account account)
        {
            _context.Add(account);
            _context.SaveChanges();
            return "Account added successfully";
        }

        public Account GetAccount(int id)
        {
            //_logger.LogInformation("Attempting to retrieve business with ID: " + Id);

            return _context.accounts.Find(id);
        }

        public IEnumerable<Account> GetAccounts()
        {
            //_logger.LogInformation("Attempting to retrieve list of businesses");

            return _context.accounts;
        }

        public string RemoveAccount(int id)
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

        public string UpdateAccount(Account accountChanges)
        {
            //_logger.LogInformation("Attempting to update business changes");

            var tm = _context.accounts.Attach(accountChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return "Updated Successfully !";
        }
    }
}
