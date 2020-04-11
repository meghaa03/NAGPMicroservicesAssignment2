using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using UserOrderBDC.Interfaces;

namespace UserOrderMicroservice.Controllers
{
    [Route("api/orderdetails")]
    [ApiController]
    public class UserOrderController : ControllerBase
    {
        IUserOrderBDC userOrderBDC;
        public UserOrderController(IUserOrderBDC userOrderBDC)
        {
            this.userOrderBDC = userOrderBDC;
        }
        
        [HttpGet("{userId}")]
        public UserOrderDTO Get([FromRoute]int userId)
        {
            return userOrderBDC.GetUserOrdersAggregateDetails(userId);
        }
    }
}
