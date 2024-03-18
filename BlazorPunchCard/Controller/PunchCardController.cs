using BlazorPunchCard.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace BlazorPunchCard.Controller
{
    public class PunchCardController
    {
        private readonly IApplicationUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IPunchCardRepository _punchCardRepository;

        public PunchCardController(IApplicationUserRepository userRepository, ICompanyRepository companyRepository, IPunchCardRepository punchCardRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _punchCardRepository = punchCardRepository;
        }

        public async Task AddPunchCardAsync(string userId, PunchCard punchCard)
        {
            try
            {
                var company = await _companyRepository.GetCompanyByUserId(userId);

                if (company != null)
                {
                    punchCard.FK_CompanyId = company.CompanyId;

                    await _punchCardRepository.Add(punchCard);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid skapande av stämpelkort: {ex.Message}");
            }
        }

    }
}
