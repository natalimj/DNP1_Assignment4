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
    public class MemberService : IMemberService
    {
       
        private string uri = "https://localhost:5003";

        private readonly HttpClient client=new HttpClient();

        public IList<Adult> Adults { get; private set; }
        public IList<Child> Children { get; private set; }
        public IList<Pet> Pets { get; private set; }
      
        
        
        public async Task AddAdultAsync(Adult adult)
        {
            string adultJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultJson, Encoding.UTF8,"application/json");
            HttpResponseMessage response=await client.PutAsync(uri+"/Adults", content);
            Console.WriteLine(response.ToString());
           
        }

        public async Task AddChildAsync(Child child)
        {
           
            string childJson = JsonSerializer.Serialize(child);
            HttpContent content = new StringContent(childJson, Encoding.UTF8,"application/json");
            HttpResponseMessage response=await client.PutAsync(uri+"/Children", content);
            Console.WriteLine(response.ToString());
        }

        public async Task AddPetAsync(Pet pet)
        {
        
            string petJson = JsonSerializer.Serialize(pet);
            HttpContent content = new StringContent(petJson, Encoding.UTF8,"application/json");
            HttpResponseMessage response=await client.PutAsync(uri+"/Pets", content);
            Console.WriteLine(response.ToString());
        }

        public async Task RemoveAdultAsync(Adult adult)
        {
            Adults.Remove(adult);
            HttpResponseMessage response=await client.DeleteAsync($"{uri}/Adults/{adult.Id}");
            Console.WriteLine(response.ToString());
        }
 
        public async Task RemoveChildAsync(Child child)
        {
            
            foreach (var pet in child.Pets.ToList())
            {
                HttpResponseMessage response1=await client.DeleteAsync($"{uri}/Pets/{pet.Id}");
                Console.WriteLine(response1.ToString());
            }
            
            HttpResponseMessage response=await client.DeleteAsync($"{uri}/Children/{child.Id}");
            Console.WriteLine(response.ToString());
           
        }
        
        
        public async Task RemovePetAsync(Pet pet)
        {
            Pets.Remove(pet);
            HttpResponseMessage response=await client.DeleteAsync($"{uri}/Pets/{pet.Id}");
            Console.WriteLine(response.ToString());
        }
        

        
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri+"/Adults");
            string message = await stringAsync;
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
           return result;
        }

        public async Task<IList<Child>> GetChildrenAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri+"/Children");
            string message = await stringAsync;
            List<Child> result = JsonSerializer.Deserialize<List<Child>>(message);
            return result;
        }

        public async Task<IList<Pet>> GetPetsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri+"/Pets");
            string message = await stringAsync;
            List<Pet> result = JsonSerializer.Deserialize<List<Pet>>(message);
            return result;
        }
    }
}