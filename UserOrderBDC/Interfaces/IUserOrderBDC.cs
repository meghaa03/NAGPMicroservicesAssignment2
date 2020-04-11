using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserOrderBDC.Interfaces
{
    public interface IUserOrderBDC
    {
        UserOrderDTO GetUserOrdersAggregateDetails(int userId);
    }
}
