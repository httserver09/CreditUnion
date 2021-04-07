using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using union.Models;

namespace union.Interfaces
{
    public interface IMain
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccount(int id);
        string AddAccount(Account account);
        string UpdateAccount(Account accountChanges);
        string RemoveAccount(int id);
    }
}
