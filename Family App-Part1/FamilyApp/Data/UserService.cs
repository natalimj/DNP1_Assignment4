using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FamilyApp.Models;


namespace FamilyApp.Data
{
    public class UserService: IUserService

    {
        private string uri = "https://localhost:5003";

        private readonly HttpClient client=new HttpClient();
      
      
        public async Task<User> ValidateUser(string userName, string password)
        {
            IList<User> users = await GetUsersAsync();
            User first=new User();
            foreach (var user in users)
            {
                if (user.UserName.Equals(userName))
                {
                    first = user;
                }
            }

            Console.Write("here");
            
            
                if (first == null) {
                    throw new Exception("User not found");
                }

                if (!first.Password.Equals(password)) {
                    throw new Exception("Incorrect password");
                }
                 
                return first;
                
        }

        public async Task AddUserAsync(User user)
        {

            IList<User> users = await GetUsersAsync();
            if (users.Where(u => u.UserName.Equals(user.UserName)).ToList().Any())
            {
                throw new Exception("Username is already taken");
            }
            
            string userJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userJson, Encoding.UTF8,"application/json");
            HttpResponseMessage response=await client.PutAsync(uri+"/Users", content);
            Console.WriteLine(response.ToString());
            
                
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri+"/Users");
            string message = await stringAsync;
            List<User> result = JsonSerializer.Deserialize<List<User>>(message);
            return result;
        }

        public async Task<IList<User>> GetBasicUsersAsync()
        {
            return (await GetUsersAsync()).Where(user => user.UserType.Equals("user")).ToList();
        }
        
        
        public async Task RemoveUserAsync(User user)
        {
            HttpResponseMessage response=await client.DeleteAsync($"{uri}/Users?username={user.UserName}");
            Console.WriteLine(response.ToString());
        }
    }
    }
