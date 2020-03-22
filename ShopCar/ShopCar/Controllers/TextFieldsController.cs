using Shoping.BLL.Service;
using Microsoft.AspNetCore.Mvc;
using Shoping.DAL.EF;
using Shoping.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ShopCar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TextFieldsController : Controller
    {
        private readonly DataManager dataManager;
        public TextFieldsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Edit(string codeWord)
        {
            var entity = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if (ModelState.IsValid)
            {
                dataManager.TextFields.SaveTextField(model);
               return RedirectToAction(nameof(AdminController.Index), nameof(AdminController).CutController());
            }
            return View(model);
        }
    }
}
