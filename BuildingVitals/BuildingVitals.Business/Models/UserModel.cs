using BuildingVitals.BusinessContracts.Models.Base;

namespace BuildingVitals.BusinessContracts.Models
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
