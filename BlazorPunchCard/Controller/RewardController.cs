using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorPunchCard.Controller
{
    public class RewardController
    {
        private readonly IRewardRepository _rewardRepository;
        private readonly ILogger<Reward> _logger;

        public RewardController(IRewardRepository rewardRepository, ILogger<Reward> logger)
        {
            _rewardRepository = rewardRepository;
            _logger = logger;
        }


        public async Task GetRewardByRedemptionCodeAsync(int redemptionCode)
        { 
            var reward = await _rewardRepository.GetRewardAsync(redemptionCode);
            if (reward == null)
            {
                _logger.LogInformation("Engångskod finns ej");
                return;
            }
            else
            {
                reward.IsActive = false;
                reward.RedemptionCode = 0;
                await _rewardRepository.Update(reward);
            }     


        }
    }
}
