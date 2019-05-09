using System;
using BuildingVitals.BusinessContracts.Models.Base;

namespace BuildingVitals.BusinessContracts.Models
{
    public class ApartmentModel : BaseModel
    {
        public string Floor { get; set; }

        public int Number { get; set; }

        public Guid OwnerId { get; set; }

        public Guid BuildingId { get; set; }

        public ApartmentModel(){}

        public ApartmentModel(AddUserWithApartmentModel addUserWithApartmentModel, Guid ownerId)
        {
            Floor = addUserWithApartmentModel.Floor;
            Number = addUserWithApartmentModel.Number;
            OwnerId = ownerId;
            BuildingId = addUserWithApartmentModel.BuildingId;
        }
    }
}
