using Meinhardt.HSSE.Server.Services;
using Meinhardt.Models.Storage;
using Microsoft.AspNetCore.Components;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Meinhardt.HSSE.Server.Pages
{
    public partial class CountriesCom 
    {
        [Inject]
        public ICountryService? CountryService { get; set; }
        public IEnumerable<Country>? CountryList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (CountryService != null)
            {
                try
                {
                    CountryList = await CountryService.GetCountry();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }
    }
}