using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.BaseModels;
using Models.BaseModels.Diary;
using Services.Interfaces;
using System;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class DiaryOptionController : Controller
    {
        private readonly IDiaryOption DiaryOptionService;

        public DiaryOptionController(IDiaryOption DiaryOptionService)
        {
            this.DiaryOptionService = DiaryOptionService;
        }

        [HttpGet]
        public IActionResult Manage()
        {
            DiaryOption model = DiaryOptionService.LoadDefaultValue();
            if(model.DiaryOptionId == Guid.Empty)
            {
                model = new();
                model.DiaryOptionId = Guid.NewGuid();
                DiaryOptionService.CreateRecord(model);
                DiaryOptionService.SaveChanges();
            }
            else
            {
                model = DiaryOptionService.ReturnSingleRecord(model.DiaryOptionId);
            }    

            return View(model);
        }

        [HttpPost]
        public IActionResult Manage(DiaryOption DiaryOption)
        {
            DiaryOptionService.UpdateRecord(DiaryOption);
            DiaryOptionService.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
    }
}
