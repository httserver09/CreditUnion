 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace union.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string generateToken(IdentityUser user);
        string generateToken(IdentityUser user, IList<string> roles);
        string generateToken(IdentityUser user, IList<string> roles, IList<Claim> claims);
    }
}
