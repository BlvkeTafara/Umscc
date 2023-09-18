namespace aspnet_boilerplate_mvc.Services.Notifications
{
    public interface IEmailService
    {
        Task<bool> AccountCreationEmail(string email, string name, string password);
        Task<bool> ResetPasswordEmail(string email,string name, string password);
        Task<bool> GeneralEmail(string email, string name, string subject, string body);

        Task SendEmail();
    }
}
