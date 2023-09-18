using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace aspnet_boilerplate_mvc.Services.Notifications
{
    public class EmailService:IEmailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public EmailService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<bool> AccountCreationEmail(string email, string name, string password)
        {
            var contacts = _configuration.GetSection("SUPPORTCONTACT").Value;
            string subject = "Portal Login Details";
            var message = $"<h4>Good day: {name}</h4>"
                   + "<p>An Account for you to access our  portal has been created you can use the follow details to access your account</p>"
                   + $"<p>Username: {email}</p>"
                   + $"<p>Temporary Password: {password}</p>"
                   + "<p>If you face any challenges using our platform please contact us on the following contact information: </p>"
                   + $"<p>{contacts}</p>";
            Emailqueue emailqueue = new Emailqueue();
            emailqueue.Email = email;
            emailqueue.Name = name;
            emailqueue.BodyHtml = message;
            emailqueue.Subject = subject;
            emailqueue.Url = "/";
            emailqueue.Status = "PENDING";
            _unitOfWork.emailqueueRepository.Add(emailqueue);
            var response = await _unitOfWork.Save();
            return response > 0 ? true : false;

        }

        public async Task<bool> GeneralEmail(string email, string subject, string name, string body)
        {
            var contacts = _configuration.GetSection("SUPPORTCONTACT").Value;

            Emailqueue emailqueue = new Emailqueue();
            emailqueue.Email = email;
            emailqueue.Name = name;
            emailqueue.BodyHtml = body;
            emailqueue.Subject = subject;
            emailqueue.Url = "/";
            emailqueue.Status = "PENDING";
            _unitOfWork.emailqueueRepository.Add(emailqueue);
            var response = await _unitOfWork.Save();
            return response > 0 ? true : false;
        }

    

        public async Task<bool> ResetPasswordEmail(string email,string name,string password)
        {
            var contacts = _configuration.GetSection("SUPPORTCONTACT").Value;
            string subject = "Portal Login Details";
            var message = $"<h4>Good day: {name}</h4>"
                   + "<p>A password reset to access our portal has been processed you can use the follow details to access your account</p>"
                   + $"<p>Username: {email}</p>"
                   + $"<p>Temporary Password: {password}</p>"
                   + "<p>If you face any challenges using our platform please contact us on the following contact information: </p>"
                   + $"<p>{contacts}</p>";
            Emailqueue emailqueue = new Emailqueue();
            emailqueue.Email = email;
            emailqueue.Name = name;
            emailqueue.BodyHtml = message;
            emailqueue.Subject = subject;
            emailqueue.Url = "/";
            emailqueue.Status = "PENDING";
            _unitOfWork.emailqueueRepository.Add(emailqueue);
            var response = await _unitOfWork.Save();
            return response > 0 ? true : false;
        }

        public async Task SendEmail()
        {
            var emails = await _unitOfWork.emailqueueRepository.GetPending();
            if (emails.Count() > 0)
            {
                foreach (var item in emails)
                {
                    var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;
                    var from_email = _configuration.GetSection("FROM_MAIL").Value;
                    var from_name = _configuration.GetSection("FROM_NAME").Value;
                    var client = new SendGridClient(apiKey);
                    var from = new EmailAddress(from_email, from_name);
                    var to = new EmailAddress(item.Email, item.Email);

                    var msg = MailHelper.CreateSingleEmail(from, to, item.Subject, item.BodyHtml, item.BodyHtml);
                    var response = await client.SendEmailAsync(msg);
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        _unitOfWork.emailqueueRepository.Remove(item);
                        await _unitOfWork.Save();
                    }
                }
            }
        }
    }
}
