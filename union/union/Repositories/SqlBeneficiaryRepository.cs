using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using union.Interfaces;
using union.Models;

namespace union.Repositories
{
    public class SqlBeneficiaryRepository : IBeneficiary
    {
        private readonly AppDbContext _context;
        private readonly IAccount _account;

        public SqlBeneficiaryRepository(AppDbContext context,
                                        IAccount account)
        {
            _context = context;
            _account = account;
        }

        public string AddBeneficiary(Beneficiary beneficiary)
        {
            _context.Add(beneficiary);
            _context.SaveChanges();
            return "Beneficiary added successfully";
        }

        public IEnumerable<Beneficiary> GetBeneficiaries()
        {
            return _context.beneficiaries;
        }

        public IEnumerable<Beneficiary> GetBeneficiariesOfAnAccount(int accountId)
        {
            if(_account.GetAccount(accountId) != null) //an account exists indeed for the acc id provided
            {
                return _context.beneficiaries.Where(x => x.accountId == accountId);
            }
            else
            {
                throw new Exception("Account does not exist");
            }
        }


        public Beneficiary GetBeneficiary(int id)
        {
            return _context.beneficiaries.Find(id);
        }

        public string RemoveBeneficiary(int id)
        {
            Beneficiary beneficiary = _context.beneficiaries.Find(id);

            if (beneficiary != null)
            {
                _context.Remove(beneficiary);
                _context.SaveChanges();
            }

            return "Beneficiary deleted Successfully !";
        }

        public string UpdateBeneficiary(Beneficiary beneficiaryChanges)
        {
            var tm = _context.beneficiaries.Attach(beneficiaryChanges);
            tm.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return "Updated Successfully !";
        }
    }
}
