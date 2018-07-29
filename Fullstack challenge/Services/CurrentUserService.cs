using System;
using Fullstack.Challenge.Data;
using Fullstack.Challenge.Models;

namespace Fullstack.Challenge.Services
{
	public class CurrentUserService
	{
		private readonly UserRepository _userRepository;
		private readonly AuthenticationService _authenticationService;

		public CurrentUserService(
			UserRepository userRepository,
			AuthenticationService authenticationService)
		{
			_userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
			_authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
		}

		public int GetBalance()
		{
			int userId = _authenticationService.GetCurrentUserId();
			User user = _userRepository.GetUserById(userId);
			return user.Balance;
		}
		public User GetUser()
		{
			int userId = _authenticationService.GetCurrentUserId();
			User user = _userRepository.GetUserById(userId);
			return user;
		}

		public string GetUserName()
		{
			int userId = _authenticationService.GetCurrentUserId();
			User user = _userRepository.GetUserById(userId);
			return user.Login;
		}
		public int GetUserId()
		{
			int userId = _authenticationService.GetCurrentUserId();
			return userId;
		}
		public bool UpdateUser(User _user)
		{
			return _userRepository.UserUpdate(_user);
		}
	}
}