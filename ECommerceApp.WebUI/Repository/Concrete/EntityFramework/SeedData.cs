using ECommerceApp.WebUI.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceApp.WebUI.Repository.Concrete.EntityFramework
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<ECommerceAppContext>();

            context.Database.Migrate();
            if (!context.Products.Any())
            {
                var products = new List<Product>()
                {
                    new Product(){ ProductName="Photo Camera",Price=153, Image="product1.jpg",IsHome=true,IsApproved=true,IsFeatured=true,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sit amet est malesuada, sollicitudin enim id, faucibus tortor. Aenean maximus erat quis lorem laoreet, sit amet interdum tortor fermentum. Mauris nec orci dolor. Etiam ac dui id purus fermentum varius. Fusce ullamcorper nisl ante, et finibus ipsum scelerisque id.",HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sit amet est malesuada, sollicitudin enim id, faucibus tortor. Aenean maximus erat quis lorem laoreet, sit amet interdum tortor fermentum. Mauris nec orci dolor. Etiam ac dui id purus fermentum varius. Fusce ullamcorper nisl ante, <b>et finibus ipsum scelerisque id.</b>", DateAdded=DateTime.Now.AddDays(-10)},
                    new Product(){ ProductName="Wood Chair",Price=999, Image="product2.jpg",IsHome=false,IsApproved=true,IsFeatured=true,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sit amet est malesuada, sollicitudin enim id, faucibus tortor. Aenean maximus erat quis lorem laoreet, sit amet interdum tortor fermentum. Mauris nec orci dolor. Etiam ac dui id purus fermentum varius. Fusce ullamcorper nisl ante, et finibus ipsum scelerisque id.",HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sit amet est malesuada, sollicitudin enim id, faucibus tortor. Aenean maximus erat quis lorem laoreet, sit amet interdum tortor fermentum. Mauris nec orci dolor. Etiam ac dui id purus fermentum varius. Fusce ullamcorper nisl ante, <b>et finibus ipsum scelerisque id.</b>", DateAdded=DateTime.Now.AddDays(-20) },
                    new Product(){ ProductName="Comfortable Sofa",Price=526, Image="product3.jpg" ,IsHome=true,IsApproved=false,IsFeatured=true,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sit amet est malesuada, sollicitudin enim id, faucibus tortor. Aenean maximus erat quis lorem laoreet, sit amet interdum tortor fermentum. Mauris nec orci dolor. Etiam ac dui id purus fermentum varius. Fusce ullamcorper nisl ante, et finibus ipsum scelerisque id.",HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sit amet est malesuada, sollicitudin enim id, faucibus tortor. Aenean maximus erat quis lorem laoreet, sit amet interdum tortor fermentum. Mauris nec orci dolor. Etiam ac dui id purus fermentum varius. Fusce ullamcorper nisl ante, <b>et finibus ipsum scelerisque id.</b>", DateAdded=DateTime.Now.AddDays(-30)},
                    new Product(){ ProductName="Hand Bag",Price=125, Image="product4.jpg" ,IsHome=true,IsApproved=true,IsFeatured=true,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sit amet est malesuada, sollicitudin enim id, faucibus tortor. Aenean maximus erat quis lorem laoreet, sit amet interdum tortor fermentum. Mauris nec orci dolor. Etiam ac dui id purus fermentum varius. Fusce ullamcorper nisl ante, et finibus ipsum scelerisque id.",HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sit amet est malesuada, sollicitudin enim id, faucibus tortor. Aenean maximus erat quis lorem laoreet, sit amet interdum tortor fermentum. Mauris nec orci dolor. Etiam ac dui id purus fermentum varius. Fusce ullamcorper nisl ante, <b>et finibus ipsum scelerisque id.</b>", DateAdded=DateTime.Now.AddDays(-5)},
                    new Product(){ ProductName="Sofa",Price=250, Image="product3.jpg",IsHome=true,IsApproved=true,IsFeatured=true,Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sit amet est malesuada, sollicitudin enim id, faucibus tortor. Aenean maximus erat quis lorem laoreet, sit amet interdum tortor fermentum. Mauris nec orci dolor. Etiam ac dui id purus fermentum varius. Fusce ullamcorper nisl ante, et finibus ipsum scelerisque id." ,HtmlContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sit amet est malesuada, sollicitudin enim id, faucibus tortor. Aenean maximus erat quis lorem laoreet, sit amet interdum tortor fermentum. Mauris nec orci dolor. Etiam ac dui id purus fermentum varius. Fusce ullamcorper nisl ante, <b>et finibus ipsum scelerisque id.</b>", DateAdded=DateTime.Now.AddDays(-2)}
                };
                context.Products.AddRange(products);

                var categories = new List<Category>()
                {
                    new Category(){ CategoryName="Electronics" },
                    new Category(){ CategoryName="Accessories" },
                    new Category(){ CategoryName="Furniture" }
                };
                context.Categories.AddRange(categories);

                var productCategories = new List<ProductCategory>()
                {
                    new ProductCategory{ Product=products[0],Category=categories[0]},
                    new ProductCategory{ Product=products[1],Category=categories[0]},
                    new ProductCategory{ Product=products[3],Category=categories[2]},
                    new ProductCategory{ Product=products[2],Category=categories[1]}
                };
                context.AddRange(productCategories);

                var images = new List<Image>()
                {
                    new Image(){ ImageName="product1.jpg",Product=products[0] },
                    new Image(){ ImageName="product2.jpg",Product=products[0] },
                    new Image(){ ImageName="product3.jpg",Product=products[0] },
                    new Image(){ ImageName="product4.jpg",Product=products[0] },

                    new Image(){ ImageName="product1.jpg",Product=products[1] },
                    new Image(){ ImageName="product2.jpg",Product=products[1] },
                    new Image(){ ImageName="product3.jpg",Product=products[1] },
                    new Image(){ ImageName="product4.jpg",Product=products[1] },

                    new Image(){ ImageName="product1.jpg",Product=products[2] },
                    new Image(){ ImageName="product2.jpg",Product=products[2] },
                    new Image(){ ImageName="product3.jpg",Product=products[2] },
                    new Image(){ ImageName="product4.jpg",Product=products[2] },

                    new Image(){ ImageName="product1.jpg",Product=products[3] },
                    new Image(){ ImageName="product2.jpg",Product=products[3] },
                    new Image(){ ImageName="product3.jpg",Product=products[3] },
                    new Image(){ ImageName="product4.jpg",Product=products[3] },

                    new Image(){ ImageName="product1.jpg",Product=products[4] },
                    new Image(){ ImageName="product2.jpg",Product=products[4] },
                    new Image(){ ImageName="product3.jpg",Product=products[4] },
                    new Image(){ ImageName="product4.jpg",Product=products[4] },

                };
                context.Images.AddRange(images);

                var attributes = new List<ProductAttribute>()
                {
                    new ProductAttribute(){ Attribute="Display",Value="15.6",Product=products[0]},
                    new ProductAttribute(){ Attribute="Color",Value="Red",Product=products[0]},

                    new ProductAttribute(){ Attribute="Display",Value="14.8",Product=products[1]},
                    new ProductAttribute(){ Attribute="Color",Value="Blue",Product=products[1]},

                    new ProductAttribute(){ Attribute="Display",Value="15.2",Product=products[2]},
                    new ProductAttribute(){ Attribute="Color",Value="Black",Product=products[2]},

                    new ProductAttribute(){ Attribute="Display",Value="1.6",Product=products[3]},
                    new ProductAttribute(){ Attribute="Color",Value="White",Product=products[3]},

                    new ProductAttribute(){ Attribute="Display",Value="5.6",Product=products[4]},
                    new ProductAttribute(){ Attribute="Color",Value="Black",Product=products[4]},

                };
                context.Attributes.AddRange(attributes);

                context.SaveChanges();
            }
        }
    }
}
