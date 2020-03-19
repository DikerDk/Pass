using Microsoft.AspNetCore.Mvc;
using Shoping.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCar.Controllers
{
    public class ServicesController:Controller
    {
        private readonly DataManager dataManager;

        public ServicesController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(int id)
        {
            if (id != default)
            {
                return View("Show", dataManager.ServiceItems.GetServiceItemById(id));
            }

            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
            return View(dataManager.ServiceItems.GetServiceItems());
        }

    }
}
