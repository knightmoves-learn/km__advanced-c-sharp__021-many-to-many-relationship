using Microsoft.EntityFrameworkCore;

namespace HomeEnergyApi.Models
{
    public class UtilityProviderRepository : IWriteRepository<int, UtilityProvider>, IReadRepository<int, UtilityProvider>
    {
        private HomeDbContext context;

        public UtilityProviderRepository(HomeDbContext context)
        {
            this.context = context;
        }
    
        public UtilityProvider Save(UtilityProvider utilityProvider)
        {
            context.UtilityProviders.Add(utilityProvider);
            context.SaveChanges();
            return utilityProvider;
        }

        public UtilityProvider Update(int id, UtilityProvider utilityProvider)
        {
            utilityProvider.Id = id;
            context.UtilityProviders.Update(utilityProvider);
            context.SaveChanges();
            return utilityProvider;
        }

        public List<UtilityProvider> FindAll()
        {
            return context.UtilityProviders
            .Include(h => h.HomeUtilityProviders)
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