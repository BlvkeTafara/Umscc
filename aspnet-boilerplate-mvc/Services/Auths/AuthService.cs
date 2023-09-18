using aspnet_boilerplate_mvc.Entities;
using aspnet_boilerplate_mvc.Repositories;
using Microsoft.AspNetCore.Identity;

namespace aspnet_boilerplate_mvc.Services.Auths
{
	public class AuthService : IAuthService
	{
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(SignInManager<User> signInManager, IUnitOfWork unitOfWork)
        {
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
        }

        public Task<string> GeneratePassword()
		{
		 Random randon = new Random();
			var salt = randon.Next(1000);
			var Year = DateTime.Now.Year;
			var password = $"Temp@{salt}{Year}";
			return Task.FromResult(password);
		}

        
    }
}
