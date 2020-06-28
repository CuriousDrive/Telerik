#pragma checksum "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\Pages\Authors.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb0fb5aa9f7105462bced357b2d58cbb34b6f908"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BookStores.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\_Imports.razor"
using BookStores.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\_Imports.razor"
using BookStores.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\_Imports.razor"
using Telerik.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\_Imports.razor"
using Telerik.Blazor.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\Pages\Authors.razor"
using BookStores.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\Pages\Authors.razor"
using BookStores.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Authors : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 158 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\Pages\Authors.razor"
       

    //properties

    public Author author { get; set; }
    public List<Author> authorList { get; set; }

    public List<BookType> BookTypes = new List<BookType>();
    public List<City> Cities { get; set; } = new List<City>();
    public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public string[] States { get; set; } =
        new string[] { "NY", "CA", "IL", "AZ", "PA", "OH", "NC", "IN", "WA", "CO", "TX", "FL" };

    public string TextBoxValue { get; set; }
    public string DropDownListValue { get; set; }

    Telerik.Blazor.StringFilterOperator StringFilterOperator { get; set; } = StringFilterOperator.Contains;

    public List<int> SelectedBookTypeIds { get; set; } = new List<int>();

    public string Message { get; set; }
    public int Count { get; set; }

    public bool SelectAll
    {
        get
        {
            return Subscriptions.All(sub => sub.Selected);
        }
        set
        {
            Subscriptions.ForEach(sub => sub.Selected = value);
        }
    }

    public bool SelectAllInderminate
    {
        get
        {
            return !SelectAll && Subscriptions.Any(sub => sub.Selected);
        }
    }

    private void MultiSelectEventHandler(object value)
    {
        List<int> selectedIds = (List<int>)value;
        SelectedBookTypeIds = selectedIds;

        if (selectedIds.Count() > 3)
            Message = "more than 3 book types have been selected.";
        else
            Message = "";
    }

    private bool SetTextBoxAccess()
    {
        return true;
    }

    private void TextBoxEventHandler(string value)
    {
        author.FirstName = value;
        TextBoxValue = value;
    }

    private void DropDownListEventHandler(object value)
    {
        DropDownListValue = (string)value;
        //string selectedCity = Cities.Where(ct => ct.Id == DropDownListValue).FirstOrDefault().CityName;
        author.State = GetStateFromCity(DropDownListValue);
        //author.City = selectedCity;
    }

    protected override async Task OnInitializedAsync()
    {
        author = new Author();
        authorList = new List<Author>();
        await LoadAuthors();

        //loading cities
        LoadCities();

        //loading booktypes
        //LoadBookTypes();

        //loading subscriptions
        LoadSubscriptions();

        await base.OnInitializedAsync();
    }

    private async Task LoadAuthors()
    {
        authorList = await bookStoresService.GetAllAsync("authors/GetAuthors");

        if (authorList != null)
            authorList = authorList.OrderByDescending(auth => auth.AuthorId).ToList();

        StateHasChanged();
    }

    private void LoadCities()
    {
        Cities.Add(new City { Id = "1", CityName = "New York City" });
        Cities.Add(new City { Id = "2", CityName = "Los Angeles" });
        Cities.Add(new City { Id = "3", CityName = "Chicago" });
        Cities.Add(new City { Id = "4", CityName = "Houston" });
        Cities.Add(new City { Id = "5", CityName = "Phoenix" });
        Cities.Add(new City { Id = "6", CityName = "Philadelphia" });
        Cities.Add(new City { Id = "7", CityName = "San Antonio" });
        Cities.Add(new City { Id = "8", CityName = "San Diego" });
        Cities.Add(new City { Id = "9", CityName = "Dallas" });
        Cities.Add(new City { Id = "10", CityName = "San Jose" });
        Cities.Add(new City { Id = "11", CityName = "Austin" });
        Cities.Add(new City { Id = "12", CityName = "Jacksonville" });
        Cities.Add(new City { Id = "13", CityName = "Fort Worth" });
        Cities.Add(new City { Id = "14", CityName = "Columbus" });
        Cities.Add(new City { Id = "15", CityName = "San Francisco" });
        Cities.Add(new City { Id = "16", CityName = "Charlotte" });
        Cities.Add(new City { Id = "17", CityName = "Indianapolis" });
        Cities.Add(new City { Id = "18", CityName = "Seattle" });
        Cities.Add(new City { Id = "19", CityName = "Denver" });
    }

    private void LoadBookTypes(MultiSelectReadEventArgs multiSelectReadEventArgs)
    {
        Count++;

        //loading book types
        BookTypes.Add(new BookType { Id = 1, Type = "Adventure" });
        BookTypes.Add(new BookType { Id = 2, Type = "Romance" });
        BookTypes.Add(new BookType { Id = 3, Type = "Mystery" });
        BookTypes.Add(new BookType { Id = 4, Type = "Horror" });
        BookTypes.Add(new BookType { Id = 5, Type = "Thriller" });
        BookTypes.Add(new BookType { Id = 6, Type = "Science Fiction" });
        BookTypes.Add(new BookType { Id = 7, Type = "Cooking" });
        BookTypes.Add(new BookType { Id = 8, Type = "Development" });
        BookTypes.Add(new BookType { Id = 9, Type = "Motivational" });
    }

    private void LoadSubscriptions()
    {
        Subscriptions.Add(new Subscription { Id = 1, SubscriptionName = "Gold" });
        Subscriptions.Add(new Subscription { Id = 2, SubscriptionName = "Silver" });
        Subscriptions.Add(new Subscription { Id = 3, SubscriptionName = "Bronze" });
    }

    private async Task CreateAuthor()
    {
        if (author.AuthorId == 0)
            await bookStoresService.SaveAsync("authors/CreateAuthor", author);

        await LoadAuthors();

        author = new Author();
    }

    private async Task UpdateAuthor()
    {
        if (author.AuthorId != 0)
            await bookStoresService.UpdateAsync("authors/UpdateAuthor", author.AuthorId, author);

        await LoadAuthors();

        author = new Author();
    }

    private async Task DeleteAuthor(int authorId)
    {
        await bookStoresService.DeleteAsync("authors/DeleteAuthor/", authorId);
        await LoadAuthors();
    }

    private string GetStateFromCity(string city)
    {
        if (city == "New York City")
            return "NY";
        if (city == "Los Angeles" || city == "San Diego" || city == "San Jose" || city == "San Francisco")
            return "CA";
        if (city == "San Antonio" || city == "Houston" || city == "Dallas" || city == "Austin" || city == "Fort Worth")
            return "TX";
        if (city == "Chicago")
            return "IL";
        if (city == "Phoenix")
            return "AZ";
        if (city == "Philadelphia")
            return "PA";
        if (city == "Jacksonville")
            return "FL";
        if (city == "Columbus")
            return "OH";
        if (city == "Charlotte")
            return "NC";
        if (city == "Indianapolis")
            return "IN";
        if (city == "Seattle")
            return "WA";
        if (city == "Denver")
            return "CO";

        return "";
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IBookStoresService<Author> bookStoresService { get; set; }
    }
}
#pragma warning restore 1591
