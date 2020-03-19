using Microsoft.AspNetCore.Mvc;
using Shoping.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoping.PL.ViewModels
{
    public class SidebarViewComponent:ViewComponent
    {
        private readonly DataManager dataManager;

        public SidebarViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("Default", dataManager.ServiceItems.GetServiceItems()));
        }
    }
}
