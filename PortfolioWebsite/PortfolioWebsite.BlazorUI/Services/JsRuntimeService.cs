using System.Threading.Tasks;
using Microsoft.JSInterop;
using PortfolioWebsite.BlazorUI.Abstractions;

namespace PortfolioWebsite.BlazorUI.Services
{
    public class JsRuntimeService : IJsRuntimeService
    {
        private readonly IJSRuntime js;
        private readonly IJsonSerializer serializer;

        private const string jsShowAppFunctionName = "showApp";
        private const string jsGetCssVariableFunctionName = "getCssVariable";
        private const string jsSetCssColorVariableFunctionName = "setColor";
        private const string jsSaveToLocalStorageFunctionName = "saveToLocalStorage";
        private const string jsReadFromLocalStorageFunctionName = "readFromLocalStorage";
        private const string jsRemoveFromLocalStorageFunctionName = "removeFromLocalStorage";

        public JsRuntimeService(IJSRuntime js, IJsonSerializer serializer)
        {
            this.js = js;
            this.serializer = serializer;
        }

        public async Task ShowAppAsync()
        {
            await this.js.InvokeVoidAsync(jsShowAppFunctionName);
        }

        public async Task<string> GetCssVariable(string cssVariableName)
        {
            var variableValue = await this.js.InvokeAsync<string>(jsGetCssVariableFunctionName, cssVariableName);
            return variableValue;
        }

        public async Task SetCssColorAsync(string cssVariableNameOfColor, string colorHex)
        {
            await this.js.InvokeVoidAsync(jsSetCssColorVariableFunctionName, cssVariableNameOfColor, colorHex);
        }

        public async Task SaveToLocalStorageAsync<T>(string key, T value)
        {
            var valueJson = this.serializer.Serialize(value);
            await this.js.InvokeVoidAsync(jsSaveToLocalStorageFunctionName, key, valueJson);
        }

        public async Task<T> ReadFromLocalStorageAsync<T>(string key)
        {
            try
            {
                var valueJson = await this.js.InvokeAsync<string>(jsReadFromLocalStorageFunctionName, key);

                if (valueJson is null)
                {
                    return default;
                }

                var value = this.serializer.Deserialize<T>(valueJson);
                return value;
            }
            catch (System.Exception)
            {
                await this.RemoveFromLocalStorageAsync(key);
                return default;
            }
        }

        public async Task RemoveFromLocalStorageAsync(string key)
        {
            await this.js.InvokeVoidAsync(jsRemoveFromLocalStorageFunctionName, key);
        }
    }
}
