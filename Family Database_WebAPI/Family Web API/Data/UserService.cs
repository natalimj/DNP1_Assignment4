using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Family_Web_API.Models;
using Family_Web_API.Persistence;
using Microsoft.EntityFrameworkCore;


namespace Family_Web_API.Data
{
    public class UserService: IUserService

    {
        
        
        public async Task AddUserAsync(User user)
        {

            IList<User> us = await GetUsersAsync();
            if (us.Where(u => u.UserName.Equals(user.UserName)).ToList().Any())
            {
                throw new Exception("Username is already taken");
            }
            
          user.UserType = "user";
          
            
            await using (FamilyContext ctx = new FamilyContext())
            {
                
                await ctx.Users.AddAsync(user);

                await ctx.SaveChangesAsync();
            }

        }

        public async Task<IList<User>> GetUsersAsync()
        {
            
           List<User> users;
            await using (FamilyContext ctx = new FamilyContext())
            {
                users = ctx.Users.ToList();
                await ctx.SaveChangesAsync();
            }
            return  users;
        }

        
        
        public async Task<IList<User>>GetBasicUsersAsync()
        {

            List<User> basicUsers;
            
            await using (FamilyContext ctx = new FamilyContext())
            {
                basicUsers = ctx.Users.Where(u=>u.UserType.Equals("user")).ToList();
                await ctx.SaveChangesAsync();
            }
            return basicUsers;
            
        }
        
        public async Task<User> RemoveUserAsync(string username)
        {
            using (FamilyContext ctx = new FamilyContext())
            {
                User user= await ctx.Users.FirstAsync(u =>
                    u.UserName.Equals(username));
                ctx.Users.Remove(user);
                await ctx.SaveChangesAsync();
                return user;
            }
        }
    }
}