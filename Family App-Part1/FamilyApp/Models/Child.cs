using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace FamilyApp.Models {
public class Child : Person {
    [JsonPropertyName("childInterests")]
  public List<ChildInterest> ChildInterests { get; set; }
  [JsonPropertyName("pets")]
    public List<Pet> Pets { get; set; }

    public Child()
    {
        ChildInterests=new List<ChildInterest>();
        Pets=new List<Pet>();
    }
}
}