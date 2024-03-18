using BlazorPunchCard.Data.Models;
using BlazorPunchCard.Repositories.Interfaces;
using Shared.Models;

namespace BlazorPunchCard.Controller
{
    public class PunchController
    {
        private readonly IPunchRepository _punchRepository;
        private readonly IApplicationUserRepository _userRepository;
        private readonly IPunchCardRepository _punchCardRepository;
        private readonly IUserPunchCardRepository _userPunchCardRepository;
        private readonly IRewardRepository _rewardRepository;

        public PunchController(IPunchRepository repository, IApplicationUserRepository userRepository, IPunchCardRepository punchCardRepository, IUserPunchCardRepository userPunchCardRepository, IRewardRepository rewardRepository)
        {
            _punchRepository = repository;
            _userRepository = userRepository;
            _punchCardRepository = punchCardRepository;
            _userPunchCardRepository = userPunchCardRepository;
            _rewardRepository = rewardRepository;
        }

        private async Task<int> GenerateUniqueRedemptionCodeAsync()
        {
            var rnd = new Random();
            var uniqueCode = rnd.Next(1, 1000000);

            while (await _rewardRepository.CodeExists(uniqueCode))
            {
                uniqueCode = rnd.Next(1, 1000000);
            }

            return uniqueCode;
        }


        public async Task AddPunchAsync(string phoneNumber, int punchCardId)
        {
            var customer = await _userRepository.GetByPhoneNumber(phoneNumber);
            var punchCard = await _punchCardRepository.GetById(punchCardId);

            if (punchCard is null)
            {
                throw new Exception("Hittade inte stämpelkortet");
            }

            if (customer is null)
            {
                throw new Exception("Kunden kan inte hittas. Var god kontrollera att du har angett rätt telefonnnummer.");
            }

            List<UserPunchCard> userPunchCard = await _userPunchCardRepository.GetByIds(punchCard.PunchCardId, customer.Id);

            var elPunchCardo = userPunchCard.LastOrDefault();

            if (elPunchCardo == null)
            {
                var newUserPunchCard = new UserPunchCard
                {
                    FK_ApplicationUserId = customer.Id,
                    ApplicationUsers = customer,
                    FK_PunchCardId = punchCard.PunchCardId,
                    PunchCards = punchCard,
                    IsActive = true
                };

                await _userPunchCardRepository.Add(newUserPunchCard);

                var newPunch = new Punch
                {
                    FK_UserPunchCard = newUserPunchCard.UserPunchCardId
                };

                await _punchRepository.Add(newPunch);
            }
            else
            {
                var newPunch = new Punch
                {
                    FK_UserPunchCard = elPunchCardo.UserPunchCardId
                };

                await _punchRepository.Add(newPunch);

                
                if (elPunchCardo.Punches.Count == punchCard.PunchCardCount)
                {
                    elPunchCardo.IsActive = false;
                    await _userPunchCardRepository.Update(elPunchCardo);

                    var newUserPunchCard = new UserPunchCard
                    {
                        FK_ApplicationUserId = customer.Id,
                        ApplicationUsers = customer,
                        FK_PunchCardId = punchCard.PunchCardId,
                        PunchCards = punchCard,
                        IsActive = true,


                    };


                    await _userPunchCardRepository.Add(newUserPunchCard);

                    var reward = new Reward
                    {
                        TypeOfReward = punchCard.Reward,
                        IsActive = true,
                        FK_UserPunchCardId = elPunchCardo.UserPunchCardId,
                        RedemptionCode = await GenerateUniqueRedemptionCodeAsync(),
                        TimeRegistered = DateTime.Now
                    };

                    await _rewardRepository.Add(reward);
                }
            }
        }

    }
}