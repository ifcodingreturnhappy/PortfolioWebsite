using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PortfolioWebsite.BlazorUI.Abstractions
{
    public interface IJsRuntimeService
    {
        public Task ShowAppAsync();
        public Task<string> RegisterOutsideClickAsync<T>(ElementReference containerElement, DotNetObjectReference<T> dotNetRef)
            where T : class;
        public Task UnregisterOutsideClickAsync(string outsideClickId);
        public Task HighlightCodeAsync(ElementReference codeBlockElement);
        public Task<string> GetCssVariable(string cssVariableName);
        public Task SetCssColorAsync(string cssVariableNameOfColor, string colorHex);
        public Task SaveToLocalStorageAsync<T>(string key, T value);
        public Task<T> ReadFromLocalStorageAsync<T>(string key);
        public Task RemoveFromLocalStorageAsync(string key);
    }
}
