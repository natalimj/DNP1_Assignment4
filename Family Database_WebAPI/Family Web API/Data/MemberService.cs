using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Family_Web_API.Models;
using Family_Web_API.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Family_Web_API.Data
{
    public class MemberService : IMemberService
    {
        
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            
            List<Adult> adults;
            using (FamilyContext ctx = new FamilyContext())
            {
                adults = ctx.Adults.ToList();
                await ctx.SaveChangesAsync();
            }
            return adults;
        }

        public async Task<IList<Child>> GetChildrenAsync()
        {
            List<Child> children;
            await using (FamilyContext ctx = new FamilyContext())
            {
                children = ctx.Children.Include(c => c.Pets)
                    .Include(c => c.ChildInterests).ToList();
                await ctx.SaveChangesAsync();
            }
            return children;
        }

        public async Task<IList<Pet>> GetPetsAsync()
        {
            List<Pet> pets;
            await using (FamilyContext ctx = new FamilyContext())
            {
                pets = ctx.Pets.ToList();
                await ctx.SaveChangesAsync();
            }
            return pets;
        }
        
        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            await using (FamilyContext ctx = new FamilyContext())
            {
                await ctx.Adults.AddAsync(adult);
                await ctx.SaveChangesAsync();
            }

            return adult;
          
        }

        public async Task<Child> AddChildAsync(Child child)
        {
            
           await using (FamilyContext ctx = new FamilyContext())
            {
                await ctx.Children.AddAsync(child);
                await ctx.SaveChangesAsync();
            }
            return child;
        }

        public async Task<Pet> AddPetAsync(Pet pet)
        {
          await  using (FamilyContext ctx = new FamilyContext())
            {
                await ctx.Pets.AddAsync(pet);
                await ctx.SaveChangesAsync();
            }
            return pet;
        }

        public async Task<Pet> RemovePetAsync(int id)
        {
            using (FamilyContext ctx = new FamilyContext())
            {
                Pet pet = await ctx.Pets.FirstAsync(p =>
                   p.Id==id);
                ctx.Pets.Remove(pet);
                await ctx.SaveChangesAsync();
                return pet;
            }
            
        }

        public async Task<Child> RemoveChildAsync(int id)
        {
            using (FamilyContext ctx = new FamilyContext())
            {
                Child child= await ctx.Children.FirstAsync(c =>
                    c.Id==id);
                ctx.Children.Remove(child);
                await ctx.SaveChangesAsync();
                return child;
            }
   
        }

        public async Task<Adult> RemoveAdultAsync(int id)
        {
            using (FamilyContext ctx = new FamilyContext())
            {
                Adult adult= await ctx.Adults.FirstAsync(a =>
                    a.Id==id);
                ctx.Adults.Remove(adult);
                await ctx.SaveChangesAsync();
                return adult;
            }
        }

        public async Task RemoveAllFamilyMembersAsync(Family family)
        {
            foreach (var adult in family.Adults)
            {
                RemoveAdultAsync(adult.Id);
            }

            foreach (var child in family.Children)
            {
                RemoveChildAsync(child.Id);
            }

            foreach (var pet in family.Pets)
            {
                RemovePetAsync(pet.Id);
            }
        }
    }
}