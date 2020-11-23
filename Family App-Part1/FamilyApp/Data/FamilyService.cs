using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FamilyApp.Models;

namespace FamilyApp.Data
{
    public class 
        FamilyService :IFamilyService
    {
        
     private string uri = "https://localhost:5003";
       private readonly HttpClient client=new HttpClient();
        
        
        public IList<Family> Families { get;  set; }
        
        
        public async Task AddFamilyAsync(Family family)
        {
            string familyJson = JsonSerializer.Serialize(family);
            HttpContent content = new StringContent(familyJson, Encoding.UTF8,"application/json");
            HttpResponseMessage response=await client.PutAsync(uri+"/Families", content);
            Console.WriteLine(response.ToString());
        }

        public async Task  RemoveFamilyAsync(Family family)
        {
            HttpResponseMessage response=await client.DeleteAsync($"{uri}/Families?streetname={family.StreetName}&housenumber={family.HouseNumber}");
            Console.WriteLine(response.ToString());
            Console.Write(family.HouseNumber);
        }
        
        public async Task RemoveAdultFromFamilyAsync(Adult adult)
        {
            Families = await GetFamiliesAsync();
 
            foreach (var family in Families)
            {
                foreach (var ad in family.Adults.ToList())
                {
                    if (adult.Id == ad.Id)
                    {
                       await RemoveFamilyAsync(family);
                        family.Adults.Remove(adult);
                       await AddFamilyAsync(family);
                      
                    }
                }
            }
            
        }
     
        public async Task RemoveChildFromFamilyAsync(Child child)
        {
            Families = await GetFamiliesAsync();
            foreach (var family in Families)
            {
                foreach (var ch in family.Children.ToList())
                {
                    if (child.Id == ch.Id)
                    {
                       await RemoveFamilyAsync(family);
                        family.Children.Remove(child);
                        await AddFamilyAsync(family);
                    }
                }
            }
            
         
        }
        
        public async Task<IList<Family>> GetFamiliesAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri+"/Families");
            string message = await stringAsync;
            List<Family> result = JsonSerializer.Deserialize<List<Family>>(message);
            return result;
        }

        public async Task<Family> GetFamilyAsync(string street, int number)
        {
            Task<string> stringAsync = client.GetStringAsync(uri+"/Families");
            string message = await stringAsync;
            List<Family> result = JsonSerializer.Deserialize<List<Family>>(message);
            Family fam = null;

            foreach (var f in result)
            {
                if (f.StreetName.Equals(street, StringComparison.OrdinalIgnoreCase) && f.HouseNumber == number)
                {
                    fam = f;
                }
            }
           
            return fam;
        }
        
        
        public async Task UpdateFamily(Family family)
        {
           
            string familyAsJson = JsonSerializer.Serialize(family);
            HttpContent content = new StringContent(familyAsJson,Encoding.UTF8,   "application/json");
            await client.PatchAsync($"{uri}/Families?streetname={family.StreetName}&housenumber={family.HouseNumber}", content);

        }
        
        
    }
}