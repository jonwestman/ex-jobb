using BlazorPunchCard.Data;
using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Repositories;
using BlazorPunchCard.Repositories.Interfaces;
using Shared.Models;

namespace BlazorPunchCard.Controller
{
    public class PictureController
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IApplicationUserRepository _userRepository;
        private readonly IUserPunchCardRepository _userPunchCardRepository;
        private readonly ILogger<Picture> _logger;

        public PictureController(IPictureRepository pictureRepository, IApplicationUserRepository userRepository, IUserPunchCardRepository userPunchCardRepository, ILogger<Picture> logger)
        {
            _pictureRepository = pictureRepository;
            _userRepository = userRepository;
            _userPunchCardRepository = userPunchCardRepository;
			_logger = logger;
        }

        public async Task <List<Picture?>> AddPictureAsync(string userId)
        {
            var user = await _userRepository.GetById(userId);

            List<Picture> userPicture = await _pictureRepository.GetUserPictureAsync(user.Id);

			if (userPicture == null || userPicture.Count == 0)
			{
				_logger?.LogInformation($"Inga bilder hittades för användaren med ID {userId}.");
			}

            return userPicture;
		}
    }
}
