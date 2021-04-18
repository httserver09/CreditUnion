using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace union.Interfaces
{
    public interface ITransaction
    {
        IEnumerable<Models.Transaction> GetTransactions();
        Models.Transaction GetTransaction(int id);

        IEnumerable<Models.Transaction>  GetTransactionsOnAnaccount(int accountId);
        string AddTransaction(Models.Transaction transaction);
        string UpdateTransaction(Models.Transaction transactionChanges);
        string RemoveTransaction(int id);
    }
}
