using System.ComponentModel.DataAnnotations;
namespace HomeEnergyApi.Models
{
    public class UtilityProvider
    {
        [Key]
        public int Id { get; set; }
        public string OwnerLastName { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public HomeUsageData? HomeUsageData { get; set; }
        public ICollection<HomeUtilityProvider> HomeUtilityProviders {get; set;}

        public UtilityProvider(string ownerLastName, string? streetAddress, string? city)
        {
            OwnerLastName = ownerLastName;
            StreetAddress = streetAddress;
            City = city;
        }
    }
}