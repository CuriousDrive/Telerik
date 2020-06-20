#pragma checksum "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\Pages\Authors.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89546c2d1f8b75c110b63d3cf5a1797753a61746"
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
#line 132 "C:\Data\CuriousDrive\GitHub Repos\Telerik\Episode 1\BookStores\Client\Pages\Authors.razor"
       

    public Author author { get; set; }
    public List<Author> authorList { get; set; }
    public string SelectedState { get; set; }

    public string[] Cities { get; set; } =
        new string[] { "New York City", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia",
                    "San Antonio", "San Diego", "Dallas", "San Jose", "Austin", "Jacksonville",
                    "Fort Worth", "Columbus", "San Francisco", "Charlotte", "Indianapolis", "Seattle",
                    "Denver" };

    public string[] States { get; set; } =
        new string[] { "NY", "CA", "IL", "AZ", "PA", "OH", "NC", "IN", "WA", "CO", "TX", "FL" };

    public string[] BookTypes { get; set; } =
        new string[] { "Fiction", "Nonfiction" };

    protected override async Task OnInitializedAsync()
    {
        author = new Author();
        authorList = new List<Author>();
        await LoadAuthors();

        await base.OnInitializedAsync();
    }

    private async Task LoadAuthors()
    {
        authorList = await bookStoresService.GetAllAsync("authors/GetAuthors");

        if (authorList != null)
            authorList = authorList.OrderByDescending(auth => auth.AuthorId).ToList();

        StateHasChanged();
    }

    private async Task SaveAuthor()
    {

        if (author.AuthorId == 0)
            await bookStoresService.SaveAsync("authors/CreateAuthor", author);
        else
            await bookStoresService.UpdateAsync("authors/UpdateAuthor", author.AuthorId, author);

        await LoadAuthors();

        author = new Author();
    }

    private async Task DeleteAuthor(int authorId)
    {
        await bookStoresService.DeleteAsync("authors/DeleteAuthor/", authorId);
        await LoadAuthors();
    }

    private void EditAuthor(Author argAuthor)
    {
        author = argAuthor;
    }

    private void OnSelectCity(string city)
    {
        author.City = city;
        SelectedState = GetStateFromCity(city);
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
