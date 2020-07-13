using ECommerceApp.WebUI.Entity;
using ECommerceApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerceApp.WebUI.Repository.Abstract
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        List<Product> GetTop5Products();
        IEnumerable<Product> GetFeaturedProducts();
        ProductDetailsModel GetProductDetail(int id);
    }
}
