using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderBDC.Interfaces
{
    public interface IOrderBDC
    {
        OrderDetailsDTO GetAllOrdersForUserById(int userId);
    }
}
