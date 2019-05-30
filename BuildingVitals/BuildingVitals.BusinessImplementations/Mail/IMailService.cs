using BuildingVitals.BusinessContracts.Models;

namespace BuildingVitals.BusinessImplementations.Mail
{
    /// <summary>
    /// Service interface that handles the sending emails functionality of the app.
    /// </summary>
    public interface IMailService
    {
        void NewTenantAdded(AddUserModel tenant);
    }
}
