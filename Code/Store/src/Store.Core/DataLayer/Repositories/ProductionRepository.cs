using System;
using System.Collections.Generic;
using System.Linq;
using Store.Core.DataLayer.Contracts;
using Store.Core.EntityLayer.Production;

namespace Store.Core.DataLayer.Repositories
{
    public class ProductionRepository : Repository, IProductionRepository
    {
        public ProductionRepository(IUserInfo userInfo, StoreDbContext dbContext)
            : base(userInfo, dbContext)
        {
        }

        public IEnumerable<Product> GetProducts(Int32 pageSize, Int32 pageNumber)
        {
            var query = DbContext.Set<Product>().AsQueryable();

            return pageSize > 0 && pageNumber > 0 ? query.Skip((pageNumber - 1) * pageSize).Take(pageSize) : query;
        }

        public Product GetProduct(Product entity)
        {
            return DbContext.Set<Product>().FirstOrDefault(item => item.ProductID == entity.ProductID);
        }

        public Product GetProductByName(String productName)
        {
            return DbContext.Set<Product>().FirstOrDefault(item => item.ProductName == productName);
        }

        public void AddProduct(Product entity)
        {
            DbContext.Set<Product>().Add(entity);

            CommitChanges();
        }

        public void UpdateProduct(Product changes)
        {
            var entity = GetProduct(changes);

            if (entity != null)
            {
                entity.ProductName = changes.ProductName;
                entity.ProductCategoryID = changes.ProductCategoryID;
                entity.UnitPrice = changes.UnitPrice;
                entity.Discontinued = changes.Discontinued;
                entity.Description = changes.Description;

                CommitChanges();
            }
        }

        public void DeleteProduct(Product entity)
        {
            DbContext.Set<Product>().Remove(entity);

            CommitChanges();
        }

        public IEnumerable<ProductCategory> GetProductCategories()
        {
            return DbContext.Set<ProductCategory>();
        }

        public ProductCategory GetProductCategory(ProductCategory entity)
        {
            return DbContext.Set<ProductCategory>().FirstOrDefault(item => item.ProductCategoryID == entity.ProductCategoryID);
        }

        public void AddProductCategory(ProductCategory entity)
        {
            DbContext.Set<ProductCategory>().Add(entity);

            CommitChanges();
        }

        public void UpdateProductCategory(ProductCategory changes)
        {
            var entity = GetProductCategory(changes);

            if (entity != null)
            {
                entity.ProductCategoryName = changes.ProductCategoryName;

                CommitChanges();
            }
        }

        public void DeleteProductCategory(ProductCategory entity)
        {
            DbContext.Set<ProductCategory>().Remove(entity);

            CommitChanges();
        }

        public IEnumerable<ProductInventory> GetProductInventories()
        {
            return DbContext.Set<ProductInventory>();
        }

        public ProductInventory GetProductInventory(ProductInventory entity)
        {
            return DbContext.Set<ProductInventory>().FirstOrDefault(item => item.ProductInventoryID == entity.ProductInventoryID);
        }

        public void AddProductInventory(ProductInventory entity)
        {
            DbContext.Set<ProductInventory>().Add(entity);

            CommitChanges();
        }

        public void UpdateProductInventory(ProductInventory changes)
        {
            var entity = GetProductInventory(changes);

            if (entity != null)
            {
                entity.ProductID = changes.ProductID;
                entity.EntryDate = changes.EntryDate;
                entity.Quantity = changes.Quantity;

                CommitChanges();
            }
        }

        public void DeleteProductInventory(ProductInventory entity)
        {
            DbContext.Set<ProductInventory>().Remove(entity);

            CommitChanges();
        }
    }
}
