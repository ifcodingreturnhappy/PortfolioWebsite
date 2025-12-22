using System.Threading.Tasks;

namespace PortfolioWebsite.BlazorUI.Abstractions
{
    public interface IJsRuntimeService
    {
        public Task ShowAppAsync();
        public Task<string> GetCssVariable(string cssVariableName);
        public Task SetCssColorAsync(string cssVariableNameOfColor, string colorHex);
        public Task SaveToLocalStorageAsync<T>(string key, T value);
        public Task<T> ReadFromLocalStorageAsync<T>(string key);
        public Task RemoveFromLocalStorageAsync(string key);
    }
}
