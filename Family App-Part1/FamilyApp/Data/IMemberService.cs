using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FamilyApp.Models;

namespace FamilyApp.Data
{
    public interface IMemberService
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task<IList<Child>> GetChildrenAsync();
        Task<IList<Pet>> GetPetsAsync();
        
        Task AddAdultAsync(Adult adult); 
        Task AddChildAsync(Child child);
        Task AddPetAsync(Pet pet);
        

        Task RemoveAdultAsync(Adult adult);
         Task RemoveChildAsync(Child child);
         Task RemovePetAsync(Pet pet);
       
        
        
        
        



    }
}