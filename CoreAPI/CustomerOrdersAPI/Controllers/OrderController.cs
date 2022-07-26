using CustomerOrdersAPI.EntityFramework;
using CustomerOrdersAPI.EntityFramework.Models;
using CustomerOrdersAPI.Library.Order;
using CustomerOrdersAPI.Models.Order.Add.Input;
using CustomerOrdersAPI.Models.Order.Add.Output;
using CustomerOrdersAPI.Models.Order.Get.Input;
using CustomerOrdersAPI.Models.Order.Get.Output;
using CustomerOrdersAPI.Models.Order.Update.Input;
using CustomerOrdersAPI.Models.Order.Update.Output;
using CustomerOrdersAPI.Models.OrderStatus.Get.Input;
using CustomerOrdersAPI.Models.OrderStatus.Get.Output;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrdersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private CustomerOrdersDbContext customerOrdersDbContext;

        private IOrderLibrary orderLibrary;

        public OrderController(CustomerOrdersDbContext customerOrdersDbContext, IOrderLibrary orderLibrary)
        {
            this.customerOrdersDbContext = customerOrdersDbContext; 
            this.orderLibrary = orderLibrary;
        }

        [HttpPost("AddOrders")]
        public AddOrderOutputModel AddOrders(AddOrderInputModel addOrderInput)
        {
            return orderLibrary.AddOrders(addOrderInput);
        }

        [HttpPost("AddOrdersAsync")]
        public AddOrderOutputModel AddOrdersAsync(AddOrderInputModel addOrderInput)
        {
            return new AddOrderOutputModel();
        }

        [HttpPost("UpdateOrder")]
        public UpdateOrderOutputModel UpdateOrder(UpdateOrderInputModel updateOrderInput)
        {
            return orderLibrary.UpdateOrder(updateOrderInput);
        }

        [HttpPost("UpdateOrderAsync")]
        public UpdateOrderOutputModel UpdateOrderAsync(UpdateOrderInputModel updateOrderInput)
        {
            return new UpdateOrderOutputModel();
        }

        [HttpGet("GetOrderStatus")]
        public GetOrderStatusOutputModel GetOrderStatus(GetOrderStatusInputModel getOrderStatusInput)
        {
            return orderLibrary.GetOrderStatus(getOrderStatusInput);
        }

        [HttpGet("GetAllOrders")]
        public GetAllOrdersOutputModel GetAllOrders(GetAllOrdersInputModel getAllOrdersInput)
        {
            return orderLibrary.GetAllOrders(getAllOrdersInput);
        }

        [HttpGet("GetAllOrderStatuses")]
        public GetAllOrderStatusesOutputModel GetAllOrderStatuses(GetAllOrderStatusesInputModel getAllOrderStatusesInputModel)
        {
            return orderLibrary.GetAllOrderStatuses(getAllOrderStatusesInputModel);
        }
    }
}
