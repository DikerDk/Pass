using Microsoft.AspNetCore.Hosting;
using Shoping.BLL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoping.DAL.EF;
using Shoping.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCar.Controllers
{
    public class ServiceItemsController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public ServiceItemsController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Edit(int id)
        {
            var entity = id == default ? new ServiceItem() : dataManager.ServiceItems.GetServiceItemById(id);
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(ServiceItem model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                dataManager.ServiceItems.SaveServiceItem(model);
                return RedirectToAction(nameof(AdminController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            dataManager.ServiceItems.DeleteServiceItem(id);
            return RedirectToAction(nameof(AdminController.Index), nameof(HomeController).CutController());
        }

    }
}
