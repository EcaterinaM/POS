namespace BuildingVitals.BusinessContracts.Models
{
    public class AddUserModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public AddUserModel()
        {}

        public AddUserModel(AddUserWithApartmentModel addUserWithApartmentModel)
        {
            Name = addUserWithApartmentModel.Name;
            Surname = addUserWithApartmentModel.Surname;
            UserName = addUserWithApartmentModel.UserName;
            Email = addUserWithApartmentModel.Email;
            Password = addUserWithApartmentModel.Password;
            PhoneNumber = addUserWithApartmentModel.PhoneNumber;
        }
    }
}
