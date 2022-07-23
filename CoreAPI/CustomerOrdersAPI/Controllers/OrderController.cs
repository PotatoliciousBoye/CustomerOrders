using CustomerOrdersAPI.Models.Order.Add.Input;
using CustomerOrdersAPI.Models.Order.Add.Output;
using CustomerOrdersAPI.Models.Order.Get.Input;
using CustomerOrdersAPI.Models.Order.Get.Output;
using CustomerOrdersAPI.Models.Order.Update.Input;
using CustomerOrdersAPI.Models.Order.Update.Output;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrdersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        public AddOrderOutputModel AddOrder(AddOrderInputModel addOrderInput)
        {
            return new AddOrderOutputModel();
        }
        public AddOrderOutputModel AddOrderAsync(AddOrderInputModel addOrderInput)
        {
            return new AddOrderOutputModel();
        }
        public UpdateOrderOutputModel UpdateOrder(UpdateOrderInputModel updateOrderInput)
        {
            return new UpdateOrderOutputModel();
        }
        public UpdateOrderOutputModel UpdateOrderAsync(UpdateOrderInputModel updateOrderInput)
        {
            return new UpdateOrderOutputModel();
        }
        public GetOrderStatusOutputModel GetOrderStatus(GetOrderStatusInputModel getOrderStatusInput)
        {
            return new GetOrderStatusOutputModel();
        }
        public GetAllOrdersOutputModel GetAllOrders(GetAllOrdersInputModel getAllOrdersInput)
        {
            return new GetAllOrdersOutputModel();
        }
    }
}
