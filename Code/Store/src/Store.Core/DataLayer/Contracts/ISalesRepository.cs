using System;
using System.Collections.Generic;
using Store.Core.EntityLayer.Sales;

namespace Store.Core.DataLayer.Contracts
{
    public interface ISalesRepository : IRepository
    {
        IEnumerable<Customer> GetCustomers(Int32 pageSize, Int32 pageNumber);

        Customer GetCustomer(Customer entity);

        void AddCustomer(Customer entity);

        void UpdateCustomer(Customer changes);

        void DeleteCustomer(Customer entity);

        IEnumerable<Order> GetOrders(Int32 pageSize, Int32 pageNumber);

        Order GetOrder(Order entity);

        void AddOrder(Order entity);

        void UpdateOrder(Order changes);

        void DeleteOrder(Order entity);

        OrderDetail GetOrderDetail(OrderDetail entity);

        void AddOrderDetail(OrderDetail entity);

        void UpdateOrderDetail(OrderDetail changes);

        void DeleteOrderDetail(OrderDetail entity);

        IEnumerable<Shipper> GetShippers(Int32 pageSize, Int32 pageNumber);

        Shipper GetShipper(Shipper entity);

        void AddShipper(Shipper entity);

        void UpdateShipper(Shipper changes);

        void DeleteShipper(Shipper entity);
    }
}
