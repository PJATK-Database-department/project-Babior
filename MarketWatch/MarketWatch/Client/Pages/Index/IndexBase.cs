using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace MarketWatch.Client.Pages.Index
{
    public class IndexBase : ComponentBase
    {
        [CascadingParameter] private Task<AuthenticationState> _authState { get; set; }
        public AuthenticationState authState;

        protected override async Task OnInitializedAsync()
        {
            authState = await _authState;
        }
    }
}