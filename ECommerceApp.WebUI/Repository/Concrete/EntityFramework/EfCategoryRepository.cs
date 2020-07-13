using ECommerceApp.WebUI.Entity;
using ECommerceApp.WebUI.Models;
using ECommerceApp.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerceApp.WebUI.Repository.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(ECommerceAppContext context):base(context)
        {

        }
        public ECommerceAppContext Context
        {
            get { return context as ECommerceAppContext; }
        }

        public IEnumerable<CategoryModel> GetAllWithProductCount()
        {
            return GetAll().Select(i => new CategoryModel()
            {
                CategoryId=i.CategoryId,
                CategoryName=i.CategoryName,
                Count=i.ProductCategories.Count()
            });
        }

        public Category GetByName(string name)
        {
            return Context.Categories.Where(x=>x.CategoryName==name).FirstOrDefault();
        }
    }
}
