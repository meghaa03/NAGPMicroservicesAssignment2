using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderBDC.Interfaces;
using Shared.DTO;

namespace OrderMicroservice.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBDC orderBDC;
        public OrderController(IOrderBDC orderBDC)
        {
            this.orderBDC = orderBDC;
        }

        [HttpGet("{userId}")]
        public OrderDetailsDTO Get([FromRoute]int userId)
        {
            return orderBDC.GetAllOrdersForUserById(userId);
        }

        
    }
}
