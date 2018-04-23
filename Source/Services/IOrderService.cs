using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IOrderService : IBusinessService
    {
        IEnumerable<Order> GetAllOrders();
    }
}
