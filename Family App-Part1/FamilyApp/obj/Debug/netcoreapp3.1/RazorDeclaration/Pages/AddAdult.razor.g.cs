#pragma checksum "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\Pages\AddAdult.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ef25d587d2bf92504c4ace6a58299cb99b7ed6d"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace FamilyApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\_Imports.razor"
using FamilyApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\_Imports.razor"
using FamilyApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\_Imports.razor"
using Syncfusion.Blazor.Calendars;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\Pages\AddAdult.razor"
using FamilyApp.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\Pages\AddAdult.razor"
using FamilyApp.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/AddAdult")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/AddAdult/{StreetNameF}/{HouseNumberF:int}")]
    public partial class AddAdult : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 89 "C:\Users\natal\Desktop\DNP1-Assignment2\FamilyApp\Pages\AddAdult.razor"
       
    
    [Parameter]
    public string StreetNameF { get; set; }
    [Parameter]
    public int HouseNumberF { get; set; }
    public Family Family { get; set; }
    Adult newAdult=new Adult();
        
    protected override async Task OnInitializedAsync() {
        Family = await FamilyService.GetFamilyAsync(StreetNameF, HouseNumberF);
    }
    
    public void AddNewAdult()
    {
        Family.Adults.Add(newAdult);
        FamilyService.UpdateFamily(Family);
       // MemberService.AddAdultAsync(newAdult);
        
        NavigationManager.NavigateTo("/");
    }
    
    List<String> validHairs= new[] {"Blond", "Red", "Brown", "Black",
        "White", "Grey", "Blue", "Green", "Leverpostej"}.ToList();
   
    List<string> validEyes = new[] {"Brown", "Grey", "Green", "Blue",
        "Amber", "Hazel"}.ToList();

    List<string> genders = new[] {"M", "F"}.ToList();

    List<string> jobs = new[]
    {
        "Teacher", "Engineer", "Garbage Collector", "Shepherd", "Pilot", "Police Officer", "Pirate", "Fireman", "Astronaut",
        "Captain", "Soldier", "Pizza Chef", "Chef", "Ninja", "Doctor", "Janitor", "Factory Worker",
        "Chauffeur", "Waitress", "Nurse", "Chemist", "Caretaker", "Gardener", "Mascot", "Athlete", "Unemployed", "None"
    }.ToList();


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IFamilyService FamilyService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IMemberService MemberService { get; set; }
    }
}
#pragma warning restore 1591
