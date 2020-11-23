using System.Text.Json.Serialization;


namespace FamilyApp.Models {
public class ChildInterest {
   
    [JsonPropertyName("childId")]
    public int ChildId { get; set; }
   
    [JsonPropertyName("interestId")]
    public string InterestId { get; set; }
    
}
}