using Microsoft.EntityFrameworkCore;

namespace HomeEnergyApi.Models
{
    public class HomeRepository : IReadRepository<int, UtilityProvider>, IWriteRepository<int, UtilityProvider>
    {
        private HomeDbContext context;

        public HomeRepository(HomeDbContext context)
        {
            this.context = context;
        }

        public UtilityProvider Save(UtilityProvider home)
        {
            if (home.HomeUsageData != null)
            {
                var usageData = home.HomeUsageData;
                usageData.Home = home;
                context.HomeUsageDatas.Add(usageData);
            }

            context.UtilityProviders.Add(home);
            context.SaveChanges();
            return home;
        }

        public UtilityProvider Update(int id, UtilityProvider home)
        {
            home.Id = id;
            context.UtilityProviders.Update(home);
            context.SaveChanges();
            return home;
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
            var home = context.UtilityProviders.Find(id);
            context.UtilityProviders.Remove(home);
            context.SaveChanges();
            return home;
        }

        public int Count()
        {
            return context.UtilityProviders.Count();
        }
    }
}