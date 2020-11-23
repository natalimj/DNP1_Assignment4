using System.Collections.Generic;
using System.Threading.Tasks;
using Family_Web_API.Models;

namespace Family_Web_API.Data
{
    public interface IFamilyService
    {

        Task AddFamilyAsync(Family family);
        Task RemoveFamilyAsync(string streetName, int houseNumber);
        Task<IList<Family>> GetFamiliesAsync();
        Task<Family>  GetFamilyAsync(string street, int number);
        Task UpdateFamily(Family family);
    }
}