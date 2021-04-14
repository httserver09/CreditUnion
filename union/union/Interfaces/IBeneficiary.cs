using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using union.Models;

namespace union.Interfaces
{
    public interface IBeneficiary
    {
        IEnumerable<Beneficiary> GetBeneficiaries();
        IEnumerable<Beneficiary> GetBeneficiariesOfAnAccount(int accountId);
        Beneficiary GetBeneficiary(int id);
        string AddBeneficiary(Beneficiary beneficiary);
        string UpdateBeneficiary(Beneficiary beneficiaryChanges);
        string RemoveBeneficiary(int id);
    }
}
