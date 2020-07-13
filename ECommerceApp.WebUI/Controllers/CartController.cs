using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceApp.WebUI.Models;
using ECommerceApp.WebUI.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        public CartController(IProductRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            return View(GetCart());
        }

        public IActionResult AddToCart(int productId,int quantity=1)
        {
            var product = repository.Get(productId);
            if (product!=null)
            {
                var cart = GetCart();
                cart.AddProduct(product, quantity);
                SaveCart(cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var product = repository.Get(productId);
            if (product!=null)
            {
                var cart = GetCart();
                cart.RemoveProduct(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }


        private void SaveCart(Cart cart)
        {
            throw new NotImplementedException();
        }

        private Cart GetCart()
        {
            throw new NotImplementedException();
        }
    }
}