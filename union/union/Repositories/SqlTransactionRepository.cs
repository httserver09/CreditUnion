using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using union.Interfaces;
using union.Models;

namespace union.Repositories
{
    public class SqlTransactionRepository : ITransaction
    {
        private readonly AppDbContext _context;

        public SqlTransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public string AddTransaction(Models.Transaction transaction)
        {
            _context.Add(transaction);
            _context.SaveChanges();
            return "Transaction added successfully";
        }


        public Models.Transaction GetTransaction(int id)
        {
            //_logger.LogInformation("Attempting to retrieve business with ID: " + Id);
            return _context.transactions.Find(id);
        }

        public IEnumerable<Models.Transaction> GetTransactions()
        {
            //_logger.LogInformation("Attempting to retrieve list of businesses");
            return _context.transactions;
        }

        public IEnumerable<Models.Transaction> GetTransactionsOnAnaccount(int accountId)
        {
            //_logger.LogInformation("Attempting to retrieve list of businesses");
            return _context.transactions.Where(x => x.accountId == accountId);
        }

        public string RemoveTransaction(int id)
        {
            //_logger.LogInformation("Deleting team detail of ID: " + softwareId);

            Models.Transaction transaction = _context.transactions.Find(id);

            if (transaction != null)
            {
                _context.Remove(transaction);
                _context.SaveChanges();
            }

            return "Transaction deleted Successfully !";
        }

        public string UpdateTransaction(Models.Transaction transactionChanges)
        {
            //_logger.LogInformation("Attempting to update business changes");

            var tm = _context.transactions.Attach(transactionChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return "Updated Successfully !";
        }


    }
}
