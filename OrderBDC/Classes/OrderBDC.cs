using OrderBDC.Interfaces;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderBDC.Classes
{
    public class OrderBDC : IOrderBDC
    {
        public OrderDetailsDTO userOrders = new OrderDetailsDTO();

        public OrderBDC()
        {
            OrderDTO order1 = new OrderDTO
            {
                OrderId = 1,
                Amount = 250,
                Date = "14-Apr-2020"
            };

            OrderDTO order2 = new OrderDTO
            {
                OrderId = 2,
                Amount = 450,
                Date = "15-Apr-2020"
            };

            userOrders.Orders = new List<OrderDTO>() { order1 , order2};

        }

        public OrderDetailsDTO GetAllOrdersForUserById(int userId)
        {
            return userOrders;
        }
    }
}
