using Microsoft.AspNetCore.Mvc;
using Shoping.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCar.Controllers
{
    public class AdminController:Controller
    {
        private readonly DataManager dataManager;

        public AdminController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.ServiceItems.GetServiceItems());
        }

    }
}
