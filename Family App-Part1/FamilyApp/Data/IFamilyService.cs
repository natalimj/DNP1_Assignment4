using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyApp.Models;

namespace FamilyApp.Data
{
    public interface IFamilyService
    {
        
        Task AddFamilyAsync(Family family);
        Task RemoveFamilyAsync(Family family); 
        Task RemoveAdultFromFamilyAsync(Adult adult);
        Task RemoveChildFromFamilyAsync(Child child);
        Task<IList<Family>> GetFamiliesAsync();
        Task<Family> GetFamilyAsync(string street, int number);
        Task UpdateFamily(Family family);
    }
}