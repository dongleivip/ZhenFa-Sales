using System.Collections.Generic;
using Models;
using Repositories;

namespace Services
{
    public class OrderService: IOrderService
    {
        private IDataRepository<Order> _orderRepository;

        public OrderService(IDataRepository<Order> ordeRepository)
        {
            _orderRepository = ordeRepository;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }
    }
}
