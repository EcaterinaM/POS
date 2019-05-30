using System;
using System.Collections.Generic;
using BuildingVitals.BusinessContracts.Models.Base;

namespace BuildingVitals.BusinessContracts.Models.Identity
{
    public class UserIdentityModel : BaseModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Guid SensorId { get; set; }

        public IList<string> Roles { get; set; }
    }
}
