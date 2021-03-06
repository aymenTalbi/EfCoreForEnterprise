using System;
using System.Collections.Generic;
using Store.Core.EntityLayer.Production;

namespace Store.Core.DataLayer.Contracts
{
    public interface IProductionRepository : IRepository
    {
		IEnumerable<Product> GetProducts(Int32 pageSize, Int32 pageNumber);

		Product GetProduct(Product entity);

        Product GetProductByName(String productName);

        void AddProduct(Product entity);

		void UpdateProduct(Product changes);

		void DeleteProduct(Product entity);

        IEnumerable<ProductCategory> GetProductCategories();

        ProductCategory GetProductCategory(ProductCategory entity);

        void AddProductCategory(ProductCategory entity);

        void UpdateProductCategory(ProductCategory changes);

        void DeleteProductCategory(ProductCategory entity);

        IEnumerable<ProductInventory> GetProductInventories();

        ProductInventory GetProductInventory(ProductInventory entity);

        void AddProductInventory(ProductInventory entity);

        void UpdateProductInventory(ProductInventory changes);

        void DeleteProductInventory(ProductInventory entity);
    }
}
