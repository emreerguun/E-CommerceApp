using ECommerceApp.WebUI.Entity;
using ECommerceApp.WebUI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerceApp.WebUI.Repository.Concrete.EntityFramework
{
    public class EfOrderRepository : IOrderRepository
    {
        private ECommerceAppContext context;
        public EfOrderRepository(ECommerceAppContext appContext)
        {
            context = appContext;
        }

        public void Add(Order entity)
        {
            context.Orders.Add(entity);
        }

        public void Delete(Order entity)
        {
            context.Orders.Remove(entity);
        }

        public void Edit(Order entity)
        {
            context.Entry<Order>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public IQueryable<Order> Find(Expression<Func<Order, bool>> predicate)
        {
            return context.Orders.Where(predicate);
        }

        public Order Get(int id)
        {
            return context.Orders.Where(x=>x.OrderId==id).FirstOrDefault();
        }

        public IQueryable<Order> GetAll()
        {
            return context.Orders;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
