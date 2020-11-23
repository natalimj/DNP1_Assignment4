using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FamilyApp.Models
{
    public class User
    {   [Key]
        [Required(ErrorMessage = "Username is required")]
       [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [JsonPropertyName("password")]
        public string Password { get; set; }
       [JsonPropertyName("userType")]
       public string UserType{ get; set; }
      
        
    }
}