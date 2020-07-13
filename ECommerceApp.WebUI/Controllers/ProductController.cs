using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.WebUI.Models;
using ECommerceApp.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public int pageSize = 2;
        private IProductRepository repository;
        public ProductController(IProductRepository _repository)
        {
            repository = _repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(repository.GetProductDetail(id));
        }

        public IActionResult List(string category, int page = 1)
        {
            var products = repository.GetAll();
            if (!string.IsNullOrEmpty(category))
            {
                products = products
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Category)
                    .Where(i => i.ProductCategories.Any(a => a.Category.CategoryName == category));
            }
            int count = products.Count();
            products = products.Skip((page - 1) * pageSize).Take(pageSize);



            return View(new ProductModel() {
                Products = products,
                PaginationCount = (int)Math.Ceiling((double)count / pageSize),
                Category=category,
                TotalCount=count,
                SelectedPage=page
            });
        }
    }
}