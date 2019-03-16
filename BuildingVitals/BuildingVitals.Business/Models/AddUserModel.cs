using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingVitals.BusinessContracts.Models
{
    public class AddUserModel
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }
    }
}
