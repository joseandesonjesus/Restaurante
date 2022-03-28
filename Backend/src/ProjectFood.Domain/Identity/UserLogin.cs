using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProjectFood.Domain.Identity
{
    public class UserLogin : IdentityUserLogin<int>
    {
        // public string LoginProvider { get; set; }
        // public string ProviderKey { get; set; }
        // public string ProviderDisplayName { get; set; }
        // public int UserId { get; set; }
    }
}