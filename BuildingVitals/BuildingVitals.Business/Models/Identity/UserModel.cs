using System.Collections.Generic;
using BuildingVitals.BusinessContracts.Models.Base;

namespace BuildingVitals.BusinessContracts.Models.Identity
{
    public class UserModel : BaseModel
    {
        public string Name { get; set; }

        public string UserName { get; set; }

        public IList<string> Roles { get; set; }
    }
}
