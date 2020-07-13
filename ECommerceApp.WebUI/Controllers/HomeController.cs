using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.WebUI.Entity;
using ECommerceApp.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork uow;
        public HomeController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public IActionResult Index()
        {
            return View(uow.Products.GetAll().Where(i=>i.IsApproved && i.IsHome).ToList());
        }

        public IActionResult Details(int id)
        {
            return View(uow.Products.Get(id));
        }

        public IActionResult Create()
        {
            var prod = new Product() {ProductName="New Product",Price=1000 };
            uow.Products.Add(prod);
            uow.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}