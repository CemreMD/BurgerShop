﻿using Burger.DATA.Concrete;
using Burger.DATA.Enums;
using Burger.SERVICE.Services.ByProductService;
using Burger.WEBUI.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Burger.WEBUI.Areas.Admin.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [Area("Admin")]
    public class CrudByProductsFriesController : Controller
    {

        private readonly IByProductSERVICE byProductSERVICE;
        private readonly IWebHostEnvironment webHostEnvironment;
        public CrudByProductsFriesController(IByProductSERVICE byProductService, IWebHostEnvironment webHostEnvironment)
        {
            this.byProductSERVICE = byProductService;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var result = await byProductSERVICE.GetAllAsync();
            ViewBag.controller = "CrudByProductsFries";
            ViewBag.baslik = "Çıtır";
            ViewBag.type = ByProductType.Fries;
            if (result.Count > 0)
            {
                return View(result);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            ViewBag.baslik = "Ekle";
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUpdateByProductVM vm, IFormFile file)
        {
            ByProduct byProduct = new ByProduct() { Name = vm.Name, Price = vm.Price, Description = vm.Description, ByProductType = ByProductType.Fries };
            if (file != null && file.Length>0)
            {
                byProduct.Photo = HelperClass.Helper.AddPhoto(file, webHostEnvironment);
            }
            byProductSERVICE.Add(byProduct);
            return RedirectToAction("Index", "CrudByProductsFries");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var result = await byProductSERVICE.GetByIdAsync(id);
            CreateUpdateByProductVM vm = new CreateUpdateByProductVM() { Id = id, Name = result.Name, Description = result.Description, Price = result.Price };
            ViewBag.Title = "Update";
            ViewBag.baslik = "Güncelle";
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CreateUpdateByProductVM vm, IFormFile file)
        {
            ByProduct byProduct = await byProductSERVICE.GetByIdAsync(vm.Id);
            byProduct.Name = vm.Name;
            byProduct.Price = vm.Price;
            byProduct.Description = vm.Description;
            if (file != null && file.Length > 0)
            {
                byProduct.Photo = HelperClass.Helper.AddPhoto(file, webHostEnvironment);
            }
            byProductSERVICE.Update(byProduct);
            return RedirectToAction("Index", "CrudByProductsFries");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            ByProduct byProduct = await byProductSERVICE.GetByIdAsync(id);
            byProductSERVICE.Delete(byProduct);
            return RedirectToAction("Index", "CrudByProductsFries");
        }
    }
}
