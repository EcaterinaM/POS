using System;
using Microsoft.AspNetCore.Identity;

namespace BuildingVitals.DataAccessContracts.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
