using ECommerceApp.WebUI.Entity;
using ECommerceApp.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerceApp.WebUI.Models;

namespace ECommerceApp.WebUI.Repository.Concrete.EntityFramework
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductRepository
    {
        public EfProductRepository(ECommerceAppContext context) : base(context)
        {

        }

        public ECommerceAppContext Context
        {
            get { return (ECommerceAppContext)context; }
        }

        public IEnumerable<Product> GetFeaturedProducts()
        {
            return GetAll().Where(i=>i.IsFeatured && i.IsApproved );
        }

        public ProductDetailsModel GetProductDetail(int id)
        {
            return GetAll()
                .Where(i => i.ProductId == id)
                .Include(i => i.Images)
                .Include(i => i.Attributes)
                .Include(i => i.ProductCategories)
                .ThenInclude(i => i.Category)
                .Select(i => new ProductDetailsModel()
                {
                    Product = i,
                    ProductImages = i.Images,
                    ProductAttributes = i.Attributes,
                    Categories = i.ProductCategories.Select(a => a.Category).ToList()
                }).FirstOrDefault();
        }

        public List<Product> GetTop5Products()
        {
            return Context.Products.OrderByDescending(x => x.ProductId).Take(5).ToList();
        }
    }
}
