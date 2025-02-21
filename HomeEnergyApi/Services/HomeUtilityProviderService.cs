using System.ComponentModel.DataAnnotations;
using HomeEnergyApi.Models;

namespace HomeEnergyApi.Services
{
    public class HomeUtilityProviderService
    {
        public IReadRepository<int, UtilityProvider> utilityProviderRepository { get; set; }
        public IWriteRepository<int, HomeUtilityProvider> homeUtilityRepository { get; set; }

        HomeUtilityProviderService(IReadRepository<int, UtilityProvider> utilityProviderRepository,
            IWriteRepository<int, HomeUtilityProvider> homeUtilityRepository)
        {
            this.utilityProviderRepository = utilityProviderRepository;
            this.homeUtilityRepository = homeUtilityRepository;
        }

        public UtilityProvider Associate(Home home, ICollection<int> utilityProviderIds)
        {
            if(utilityProviderIds != null)
            {
                foreach(var utilityProviderId in utilityProviderIds)
                {
                    UtilityProvider utilityProvider = utilityProviderRepository.FindById(utilityProviderId);
                    HomeUtilityProvider homeUtilityProvider = new();
                    homeUtilityProvider.UtilityProvider = utilityProvider;
                    homeUtilityProvider.Id = utilityProviderId;
                    homeUtilityProvider.HomeId = home.Id;
                    homeUtilityProvider.Home = home;

                    homeUtilityRepository.Save(homeUtilityProvider);
                }
            }
        }

    }
}