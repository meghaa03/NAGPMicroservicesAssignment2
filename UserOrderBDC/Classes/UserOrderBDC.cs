using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserOrderBDC.Interfaces;

namespace UserOrderBDC.Classes
{
    public class UserOrderBDC : IUserOrderBDC
    {
        public static string userServicePath = Environment.GetEnvironmentVariable("USERSERVICE_PATH") != null ? Environment.GetEnvironmentVariable("USERSERVICE_PATH") : "http://user_service:80";

        public static string orderServicePath = Environment.GetEnvironmentVariable("ORDERSERVICE_PATH") != null ? Environment.GetEnvironmentVariable("ORDERSERVICE_PATH") : "http://order_service:80";

        UserOrderDTO userOrderDTO = new UserOrderDTO();
        public UserOrderBDC()
        {

        }

        async Task<UserDTO> GetDataFromUserService()
        {
            using (HttpClient client = new HttpClient())

            using (HttpResponseMessage res = await client.GetAsync(userServicePath+ "/api/user/1"))
            using (HttpContent content = res.Content)
            {
                UserDTO userDetailsDTOReceived = await content.ReadAsAsync<UserDTO>();

                return userDetailsDTOReceived;
            }
        }
        async Task<OrderDetailsDTO> GetDataFromOrderService()
        {
            using (HttpClient client = new HttpClient())
                            
            using (HttpResponseMessage res = await client.GetAsync(orderServicePath+ "/api/orders/1"))
            using (HttpContent content = res.Content)
            {
                OrderDetailsDTO orderDetailsDTOReceived = await content.ReadAsAsync<OrderDetailsDTO>();

                return orderDetailsDTOReceived;
            }
        }

        public UserOrderDTO GetUserOrdersAggregateDetails(int userId)
        {
            UserDTO userDetailsDTOReceived = GetDataFromUserService().GetAwaiter().GetResult();

            OrderDetailsDTO orderDetailsDTOReceived = GetDataFromOrderService().GetAwaiter().GetResult();

            if (userDetailsDTOReceived != null && orderDetailsDTOReceived != null)
            {
                userOrderDTO.UserDetails = userDetailsDTOReceived;
                userOrderDTO.Orders = orderDetailsDTOReceived.Orders;
            }

            return userOrderDTO;

        }
    }
}
