using BuildingVitals.BusinessContracts.Models.Base;

namespace BuildingVitals.BusinessContracts.Models
{
    public class GetApartmentModel : BaseModel
    {
        public string Floor { get; set; }

        public int Number { get; set; }

        public UserModel Owner { get; set; }
    }
}
