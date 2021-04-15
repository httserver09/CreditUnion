using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using union.Models;

namespace union.Interfaces
{
    public interface IAccount
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccount(int id);
        IEnumerable<Account> getAccountsOfClient(int clientId);
        string AddAccount(Account account);
        string UpdateAccount(Account accountChanges);
        string RemoveAccount(int id);
    }
}
