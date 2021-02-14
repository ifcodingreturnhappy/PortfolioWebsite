﻿using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using PortfolioWebsite.BlazorUI.Models;
using System.Collections.Generic;
using System.IO;

namespace PortfolioWebsite.BlazorUI.Services
{
    public class NavigationController : INavigationController
    {
        private readonly IWebHostEnvironment _env;
        private readonly string navigationLinksFilePath = "/Data/NavigationLinks.json";
        public string JsonNavigationLinks { get; set; }
        public List<NavigationLinkModel> NavigationLinks { get; set; }


        public NavigationController(IWebHostEnvironment env)
        {
            NavigationLinks = new List<NavigationLinkModel>();
            _env = env;
        }

        public void InitializeLinks()
        {
            try
            {
                JsonNavigationLinks = File.ReadAllText($"{_env.WebRootPath}{navigationLinksFilePath}");
                NavigationLinks = JsonConvert.DeserializeObject<List<NavigationLinkModel>>(JsonNavigationLinks);
            }
            catch
            {
            }
        }


    }
}
