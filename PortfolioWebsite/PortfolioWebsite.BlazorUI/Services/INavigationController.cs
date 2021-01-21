﻿using PortfolioWebsite.BlazorUI.Models;
using PortfolioWebsite.BlazorUI.Shared;
using System.Collections.Generic;

namespace PortfolioWebsite.BlazorUI.Services
{
    interface INavigationController
    {
        public List<NavigationLinkModel> NavigationLinks { get; set; }
        public void InitializeLinks();
    }
}
