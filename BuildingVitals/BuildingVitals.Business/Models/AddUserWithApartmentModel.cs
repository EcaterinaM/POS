using System;

namespace BuildingVitals.BusinessContracts.Models
{
    public class AddUserWithApartmentModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public string Floor { get; set; }

        public int Number { get; set; }

        public Guid BuildingId { get; set; }
    }
}
