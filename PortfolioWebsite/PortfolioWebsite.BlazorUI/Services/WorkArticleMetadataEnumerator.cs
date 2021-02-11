﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PortfolioWebsite.BlazorUI.Models;

namespace PortfolioWebsite.BlazorUI.Services
{
    public class WorkArticleMetadataEnumerator : IPageEnumerator<WorkArticleMetadataModel>
    {
        private CancellationTokenSource tokenSource;
        private Task<List<WorkArticleMetadataModel>> currentDataFetch;
        public async Task<List<WorkArticleMetadataModel>> GetFilesMetadata(string path)
        {
            string[] files = GetFiles(path);

            //await Task.Delay(2000, ct);
            if(currentDataFetch != null)
            {
                tokenSource.Cancel();
            }
            
            tokenSource = new CancellationTokenSource();

            // Task.Delay(2000, tokenSource.Token);
            currentDataFetch = GetMetadata(files, tokenSource.Token);

            return await currentDataFetch;
        }

        private string[] GetFiles(string path)
        {
            try
            {
                return Directory.GetFiles(path);
            }
            catch (Exception)
            {
                throw new Exception("There were no articles found.");
            }
        }


        private async Task<List<WorkArticleMetadataModel>> GetMetadata(string[] files, CancellationToken ct)
        {
            await Task.Delay(500, ct);

            List<WorkArticleMetadataModel> workArticlesMetadata = new List<WorkArticleMetadataModel>();

            foreach (var file in files)
            {
                string[] fileContent = await File.ReadAllLinesAsync(file, ct);

                var rawMetadata = fileContent.Where(x => x.Contains("_display") || x.Contains("@page")).ToArray();

                try
                {
                    WorkArticleMetadataModel workArticleMetadata = ConvertFromRawMetadataToMetadataModel(rawMetadata);
                    workArticlesMetadata.Add(workArticleMetadata);
                }
                catch (Exception)
                {
                    //Do logging
                }
            }

            workArticlesMetadata.OrderByDescending(x => x.PublishDate).ToList();

            return workArticlesMetadata;
        }

        private WorkArticleMetadataModel ConvertFromRawMetadataToMetadataModel(string[] rawMetadata)
        {
            try
            {
                WorkArticleMetadataModel workArticleMetadata = new WorkArticleMetadataModel();

                workArticleMetadata.PageRef = GetSubstringBetween(rawMetadata[0], "\"", "\"");
                workArticleMetadata.Title = GetSubstringBetween(rawMetadata[1], "\"", "\"");
                workArticleMetadata.ImagePath = GetSubstringBetween(rawMetadata[2], "\"", "\"");
                workArticleMetadata.Description = GetSubstringBetween(rawMetadata[3], "\"", "\"");
                workArticleMetadata.PublishDate = Convert.ToDateTime(GetSubstringBetween(rawMetadata[4], "\"", "\""));
                workArticleMetadata.Tags = GetSubstringBetween(rawMetadata[5], "\"", "\"").Split(",").ToList();

                return workArticleMetadata;
            }
            catch (Exception)
            {
                throw;
            }
        }


        private string GetSubstringBetween(string mainString, string from, string to)
        {
            try
            {
                int positionFrom = mainString.IndexOf(from) + from.Length;
                int positionTo = mainString.LastIndexOf(to);

                return mainString.Substring(positionFrom, positionTo - positionFrom);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}