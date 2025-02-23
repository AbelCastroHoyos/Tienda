﻿using Microsoft.AspNetCore.Components;
using Tienda.Frontend.Repositories;
using Tienda.Shared.Entities;


namespace Tienda.Frontend.Pages.Countries
{
    public partial class CountriesIndex
    {
        [Inject] private IRepository Repository { get; set; } = null!;
        public List<Country>? Countries { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            var responseHttp = await Repository.GetAsync<List<Country>>("api/countries");
            Countries = responseHttp.Response;
        }
    }
}
