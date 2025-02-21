using System.Diagnostics;

namespace HomeEnergyApi.Models
{
    public class HomeUtilityProviderRepository : IWriteRepository<int, UtilityProvider>, IReadRepository<int, UtilityProvider>
    {
        private HomeDbContext context;

        public HomeUtilityProviderRepository(HomeDbContext context)
        {
            this.context = context;
        }
        //The following needs to be refactored from Home to UtilityProvider
        public UtilityProvider Save(UtilityProvider utilityProvider)
        {
            context.UtilityProviders.Add(utilityProvider);
            context.SaveChanges();
            return utilityProvider;
        }

        public UtilityProvider Update(int id, UtilityProvider utilityProvider)
        {
            utilityProvider.Id = id;
            context.HomeUtilityProviders.Update(utilityProvider);
            context.SaveChanges();
            return utilityProvider;
        }

        public List<UtilityProvider> FindAll()
        {
            return context.UtilityProviders
            .Include(h => h.HomeUsageData)
            .ToList();
        }

        public UtilityProvider FindById(int id)
        {
            return context.UtilityProviders.Find(id);
        }

        public UtilityProvider RemoveById(int id)
        {
            var provider = context.UtilityProviders.Find(id);
            context.UtilityProviders.Remove(provider);
            context.SaveChanges();
            return provider;
        }

        public int Count()
        {
            return context.UtilityProviders.Count();
        }
    }

}