using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioWebsite.BlazorUI.Services
{
    interface IPageEnumerator<T>
    {
        public Task<List<T>> GetFilesMetadata(string path);
    }
}
