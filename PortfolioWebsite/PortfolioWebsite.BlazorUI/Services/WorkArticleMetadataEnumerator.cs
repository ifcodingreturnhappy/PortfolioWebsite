using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PortfolioWebsite.BlazorUI.Models;

namespace PortfolioWebsite.BlazorUI.Services
{
    public class WorkArticleMetadataEnumerator : IPageEnumerator<WorkArticleMetadataModel>
    {
        private CancellationTokenSource tokenSource;
        private Task<List<WorkArticleMetadataModel>> currentDataFetch;
        public async Task<List<WorkArticleMetadataModel>> GetFilesMetadata(string path)
        {
            string[] metadataFiles = GetAllFiles(path);

            if(currentDataFetch != null)
            {
                tokenSource.Cancel();
            }
            
            tokenSource = new CancellationTokenSource();
            currentDataFetch = ReadMetadata(metadataFiles, tokenSource.Token);

            return await currentDataFetch;
        }

        private string[] GetAllFiles(string path)
        {
            try
            {
                return Directory.GetFiles(path);
            }
            catch (Exception)
            {
                return Array.Empty<string>();
            }
        }

        private async Task<List<WorkArticleMetadataModel>> ReadMetadata(string[] files, CancellationToken ct)
        {
            await Task.Delay(500, ct);

            List<WorkArticleMetadataModel> workArticlesMetadata = new List<WorkArticleMetadataModel>();

            foreach (var file in files)
            {
                string json = await File.ReadAllTextAsync(file, ct);

                try
                {
                    var articleMetadata = JsonConvert.DeserializeObject<WorkArticleMetadataModel>(json,
                        new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });

                    workArticlesMetadata.Add(articleMetadata);
                }
                catch (Exception)
                {
                    workArticlesMetadata.Add(new WorkArticleMetadataModel { Title = "_FAILED_DATA_READ" });
                }
            }

            return workArticlesMetadata;
        }
    }
}
