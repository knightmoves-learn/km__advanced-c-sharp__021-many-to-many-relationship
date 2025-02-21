using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace HomeEnergyApi.Models
{
    public class HomeUtilityProviderRepository : IWriteRepository<int, HomeUtilityProvider>, IReadRepository<int, HomeUtilityProvider>
    {
        private HomeDbContext context;

        public HomeUtilityProviderRepository(HomeDbContext context)
        {
            this.context = context;
        }
    
        public HomeUtilityProvider Save(HomeUtilityProvider homeUtilityProvider)
        {
            context.HomeUtilityProviders.Add(homeUtilityProvider);
            context.SaveChanges();
            return homeUtilityProvider;
        }

        public HomeUtilityProvider Update(int id, HomeUtilityProvider homeUtilityProvider)
        {
            homeUtilityProvider.Id = id;
            context.HomeUtilityProviders.Update(homeUtilityProvider);
            context.SaveChanges();
            return homeUtilityProvider;
        }

        public List<HomeUtilityProvider> FindAll()
        {
            return context.HomeUtilityProviders
            .ToList();
        }

        public HomeUtilityProvider FindById(int id)
        {
            return context.HomeUtilityProviders.Find(id);
        }

        public HomeUtilityProvider RemoveById(int id)
        {
            var provider = context.HomeUtilityProviders.Find(id);
            context.HomeUtilityProviders.Remove(provider);
            context.SaveChanges();
            return provider;
        }

        public int Count()
        {
            return context.HomeUtilityProviders.Count();
        }
    }
}