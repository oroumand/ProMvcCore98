using CQRS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRS.DAL
{
    public abstract class ProductContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Category> Category { get; set; }
    }

    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly CommandProductContext commandProductContext;

        public ProductCommandRepository(CommandProductContext commandProductContext)
        {
            this.commandProductContext = commandProductContext;
        }
        public void Add(Product product)
        {
            commandProductContext.Add(product);
            commandProductContext.SaveChanges();
        }
    }

    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly QueryProductContext queryProductContext;

        public ProductQueryRepository(QueryProductContext queryProductContext)
        {
            this.queryProductContext = queryProductContext;
        }
        public List<Product> GetAll()
        {
            return queryProductContext.products.ToList();
        }
    }
}
