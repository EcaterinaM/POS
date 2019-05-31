using System.Net;
using System.Net.Mail;
using BuildingVitals.BusinessContracts.Models;
using Microsoft.Extensions.Configuration;

namespace BuildingVitals.BusinessImplementations.Mail
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private void SendMailAsync(string to, string subject, string body)
        {
            var from = "buildingVitals@bd.com";

            var fromAddress = new MailAddress(from, "Building vitals");
            var toAddress = new MailAddress(to, "Tenant");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                IsBodyHtml = true,
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }


        public void NewTenantAdded(AddUserModel tenant)
        {
            var messageBody = $"<h1> Welcome new tenant,{tenant.Name}!" +
                              $"<p>Your new apartment was added in our application.</p> " +
                              $"<p>Your credential are username {tenant.UserName} and password {tenant.Password}</p>" +
                              $"<p>Please change your password and after that login in our application! Have a nice day! </p>";
            SendMailAsync(tenant.Email,"Building Vitals", messageBody);
        }
    }
}
