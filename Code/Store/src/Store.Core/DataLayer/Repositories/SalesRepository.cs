using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Store.Core.DataLayer.Contracts;
using Store.Core.EntityLayer.Sales;

namespace Store.Core.DataLayer.Repositories
{
    public class SalesRepository : Repository, ISalesRepository
    {
        public SalesRepository(IUserInfo userInfo, StoreDbContext dbContext)
            : base(userInfo, dbContext)
        {
        }

        public IEnumerable<Customer> GetCustomers(Int32 pageSize, Int32 pageNumber)
        {
            var query = DbContext.Set<Customer>().AsQueryable();

            return pageSize > 0 && pageNumber > 0 ? query.Skip((pageNumber - 1) * pageSize).Take(pageSize) : query;
        }

        public Customer GetCustomer(Customer entity)
        {
            return DbContext
                .Set<Customer>()
                .FirstOrDefault(item => item.CustomerID == entity.CustomerID);
        }

        public void AddCustomer(Customer entity)
        {
            DbContext.Set<Customer>().Add(entity);

            CommitChanges();
        }

        public void UpdateCustomer(Customer changes)
        {
            var entity = GetCustomer(changes);

            if (entity != null)
            {
                entity.CompanyName = changes.CompanyName;
                entity.ContactName = changes.ContactName;

                CommitChanges();
            }
        }

        public void DeleteCustomer(Customer entity)
        {
            DbContext.Set<Customer>().Remove(entity);

            CommitChanges();
        }

        public IEnumerable<Order> GetOrders(Int32 pageSize, Int32 pageNumber)
        {
            var query = DbContext.Set<Order>().AsQueryable();

            return pageSize > 0 && pageNumber > 0 ? query.Skip((pageNumber - 1) * pageSize).Take(pageSize) : query;
        }

        public Order GetOrder(Order entity)
        {
            return DbContext
                .Set<Order>()
                .Include(p => p.OrderDetails)
                .FirstOrDefault(item => item.OrderID == entity.OrderID);
        }

        public void AddOrder(Order entity)
        {
            DbContext.Set<Order>().Add(entity);

            Add(entity);

            CommitChanges();
        }

        public void UpdateOrder(Order changes)
        {
            var entity = GetOrder(changes);

            if (entity != null)
            {
                entity.OrderDate = changes.OrderDate;
                entity.CustomerID = changes.CustomerID;
                entity.EmployeeID = changes.EmployeeID;
                entity.ShipperID = changes.ShipperID;
                entity.Total = changes.Total;
                entity.Comments = changes.Comments;

                Update(entity);

                CommitChanges();
            }
        }

        public void DeleteOrder(Order entity)
        {
            DbContext.Set<Order>().Remove(entity);

            CommitChanges();
        }

        public OrderDetail GetOrderDetail(OrderDetail entity)
        {
            return DbContext
                .Set<OrderDetail>()
                .FirstOrDefault(item => item.OrderID == entity.OrderID && item.ProductID == entity.ProductID);
        }

        public void AddOrderDetail(OrderDetail entity)
        {
            DbContext.Set<OrderDetail>().Add(entity);

            CommitChanges();
        }

        public void UpdateOrderDetail(OrderDetail changes)
        {
            var entity = GetOrderDetail(changes);

            if (entity != null)
            {
                entity.ProductID = changes.ProductID;
                entity.ProductName = changes.ProductName;
                entity.UnitPrice = changes.UnitPrice;
                entity.Quantity = changes.Quantity;
                entity.Total = changes.Total;

                CommitChanges();
            }
        }

        public void DeleteOrderDetail(OrderDetail entity)
        {
            DbContext.Set<OrderDetail>().Remove(entity);

            CommitChanges();
        }

        public IEnumerable<Shipper> GetShippers(Int32 pageSize, Int32 pageNumber)
        {
            var query = DbContext.Set<Shipper>().AsQueryable();

            return pageSize > 0 && pageNumber > 0 ? query.Skip((pageNumber - 1) * pageSize).Take(pageSize) : query;
        }

        public Shipper GetShipper(Shipper entity)
        {
            return DbContext
                .Set<Shipper>()
                .FirstOrDefault(item => item.ShipperID == entity.ShipperID);
        }

        public void AddShipper(Shipper entity)
        {
            DbContext.Set<Shipper>().Add(entity);

            CommitChanges();
        }

        public void UpdateShipper(Shipper changes)
        {
            var entity = GetShipper(changes);

            if (entity != null)
            {
                entity.CompanyName = changes.CompanyName;
                entity.ContactName = changes.ContactName;

                CommitChanges();
            }
        }

        public void DeleteShipper(Shipper entity)
        {
            DbContext.Set<Shipper>().Remove(entity);

            CommitChanges();
        }
    }
}
