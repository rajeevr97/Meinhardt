using Meinhardt.HSSE.Server.Services;
using Meinhardt.Models.Storage;
using Microsoft.AspNetCore.Components;

namespace Meinhardt.HSSE.Server.Pages
{
    public partial class EditCountry
    {
        [Inject]
        public ICountryService? CountryService { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        public Country? Country { get; set; } = new Country();

        [Parameter]
        public string? Id { get; set; }

        public string? PageHeaderText { get; set; }
        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int CountryId);
            if (CountryService != null && CountryId > 0)
            {
                try
                {
                    Country = await CountryService.GetCountry(CountryId);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
            else
            {
                Country = new Country();
            }
        }

        protected async Task HandleValidSubmit()
        {
            if (CountryService != null && Country != null)
            {
                Country? result = null;

                if (Country.Id > 0)
                {
                    result = await CountryService.UpdateCountry(Country);
                }
                else
                {
                    result = await CountryService.AddCountry(Country);
                }
                if (result != null)
                {
                    NavigationManager?.NavigateTo("/Countries");
                }
            }

        }

    }
}
