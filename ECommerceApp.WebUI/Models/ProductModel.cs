using ECommerceApp.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.WebUI.Models
{
    public class ProductModel
    {
        public IEnumerable<Product> Products { get; set; }
        public int PaginationCount { get; set; }
        public string Category { get; set; }
        public int TotalCount { get; set; }
        public int SelectedPage { get; set; }
    }
}
