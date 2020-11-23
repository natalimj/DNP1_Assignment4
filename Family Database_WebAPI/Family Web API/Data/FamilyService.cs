
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Family_Web_API.Models;
using Family_Web_API.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Family_Web_API.Data
{
    public class FamilyService : IFamilyService
    {
        
        public IList<Family> Families { get; set; }
        

        public async Task<IList<Family>> GetFamiliesAsync()
        {
            List<Family> families;
            
            using (FamilyContext ctx = new FamilyContext())
            {
                families = ctx.Families.Include(f => f.Adults)
                    .Include(f => f.Children).ThenInclude(c=>c.ChildInterests)
                    .Include(f => f.Children).ThenInclude(c=>c.Pets)
                    .Include(f => f.Pets).ToList();
                
                await ctx.SaveChangesAsync();
            }

            return families;
        }

        public async Task<Family> GetFamilyAsync(string street, int number)
        {

            Family family;
         
            using (FamilyContext ctx = new FamilyContext())
            {
                family =  ctx.Families.Include(f => f.Adults)
                    .Include(f => f.Children)
                    .Include(f => f.Pets).ToList().First(f => f.StreetName.Equals(street) && f.HouseNumber == number);
                await ctx.SaveChangesAsync();
            }

            return family;
        }
        
        
        public async Task AddFamilyAsync(Family family)
        {
           await using (FamilyContext ctx = new FamilyContext())
            {
                await ctx.Families.AddAsync(family);

                await ctx.SaveChangesAsync();
            }
        }

        public async Task RemoveFamilyAsync(string streetName, int houseNumber)
        {
            await  using (FamilyContext ctx = new FamilyContext())
            {
                Family family =  await ctx.Families.FirstOrDefaultAsync(f =>
                    f.StreetName.Equals(streetName) && f.HouseNumber == houseNumber);
                if(family!=null)
                    ctx.Families.Remove(family);
                await ctx.SaveChangesAsync();
            }

        }
        

        public async Task UpdateFamily(Family family)
        {
            await using (FamilyContext ctx = new FamilyContext())
            {
   
                ctx.Update(family);
                Console.WriteLine("updated");
                await ctx.SaveChangesAsync();

            }
        }

    }
}