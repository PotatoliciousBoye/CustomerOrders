using CustomerOrdersAPI.EntityFramework;
using CustomerOrdersAPI.Library.Order;
using CustomerOrdersAPI.Library.Queue;
using CustomerOrdersAPI.Models.Base.Request;
using CustomerOrdersAPI.Models.Order.Add.Input;
using CustomerOrdersAPI.Models.Order.Add.Output;
using CustomerOrdersAPI.Models.Order.Get.Input;
using CustomerOrdersAPI.Models.Order.Get.Output;
using CustomerOrdersAPI.Models.Order.Update.Input;
using CustomerOrdersAPI.Models.Order.Update.Output;
using CustomerOrdersAPI.Models.OrderStatus.Get.Input;
using CustomerOrdersAPI.Models.OrderStatus.Get.Output;
using Microsoft.AspNetCore.Mvc;

namespace CustomerOrdersAPI.Controllers
{
    /// <summary>
    /// Defines the <see cref="OrderController" />.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        #region Fields

        /// <summary>
        /// Defines the customerOrdersDbContext.
        /// </summary>
        private CustomerOrdersDbContext customerOrdersDbContext;

        /// <summary>
        /// Defines the orderLibrary.
        /// </summary>
        private IOrderLibrary orderLibrary;

        private IOrderQueueLibrary orderQueueLibrary;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="customerOrdersDbContext">The customerOrdersDbContext<see cref="CustomerOrdersDbContext"/>.</param>
        /// <param name="orderLibrary">The orderLibrary<see cref="IOrderLibrary"/>.</param>
        public OrderController(CustomerOrdersDbContext customerOrdersDbContext, IOrderLibrary orderLibrary, IOrderQueueLibrary orderQueueLibrary)
        {
            this.customerOrdersDbContext = customerOrdersDbContext;
            this.orderLibrary = orderLibrary;
            this.orderQueueLibrary = orderQueueLibrary;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The AddOrders.
        /// </summary>
        /// <param name="addOrderInput">The addOrderInput<see cref="AddOrderInputModel"/>.</param>
        /// <returns>The <see cref="AddOrderOutputModel"/>.</returns>
        [HttpPost("AddOrders")]
        public AddOrderOutputModel AddOrders(AddOrderInputModel addOrderInput)
        {
            return orderLibrary.AddOrders(addOrderInput);
        }

        /// <summary>
        /// The AddOrdersAsync.
        /// </summary>
        /// <param name="addOrderInput">The addOrderInput<see cref="AddOrderInputModel"/>.</param>
        /// <returns>The <see cref="AddOrderOutputModel"/>.</returns>
        [HttpPost("AddOrdersAsync")]
        public ServiceRequestBaseModel AddOrdersAsync(AddOrderInputModel addOrderInput)
        {
            return orderQueueLibrary.PublishAddOrdersToQueue(addOrderInput);
        }

        /// <summary>
        /// The GetAllOrders.
        /// </summary>
        /// <param name="getAllOrdersInput">The getAllOrdersInput<see cref="GetAllOrdersInputModel"/>.</param>
        /// <returns>The <see cref="GetAllOrdersOutputModel"/>.</returns>
        [HttpGet("GetAllOrders")]
        public GetAllOrdersOutputModel GetAllOrders([FromForm]GetAllOrdersInputModel getAllOrdersInput)
        {
            return orderLibrary.GetAllOrders(getAllOrdersInput);
        }

        /// <summary>
        /// The GetAllOrderStatuses.
        /// </summary>
        /// <param name="getAllOrderStatusesInputModel">The getAllOrderStatusesInputModel<see cref="GetAllOrderStatusesInputModel"/>.</param>
        /// <returns>The <see cref="GetAllOrderStatusesOutputModel"/>.</returns>
        [HttpGet("GetAllOrderStatuses")]
        public GetAllOrderStatusesOutputModel GetAllOrderStatuses([FromForm]GetAllOrderStatusesInputModel getAllOrderStatusesInputModel)
        {
            return orderLibrary.GetAllOrderStatuses(getAllOrderStatusesInputModel);
        }

        /// <summary>
        /// The GetOrderStatus.
        /// </summary>
        /// <param name="getOrderStatusInput">The getOrderStatusInput<see cref="GetOrderStatusInputModel"/>.</param>
        /// <returns>The <see cref="GetOrderStatusOutputModel"/>.</returns>
        [HttpPost("GetOrderStatus")]
        public GetOrderStatusOutputModel GetOrderStatus(GetOrderStatusInputModel getOrderStatusInput)
        {
            return orderLibrary.GetOrderStatus(getOrderStatusInput);
        }

        /// <summary>
        /// The UpdateOrder.
        /// </summary>
        /// <param name="updateOrderInput">The updateOrderInput<see cref="UpdateOrderInputModel"/>.</param>
        /// <returns>The <see cref="UpdateOrderOutputModel"/>.</returns>
        [HttpPost("UpdateOrder")]
        public UpdateOrderOutputModel UpdateOrder(UpdateOrderInputModel updateOrderInput)
        {
            return orderLibrary.UpdateOrder(updateOrderInput);
        }

        /// <summary>
        /// The UpdateOrderAsync.
        /// </summary>
        /// <param name="updateOrderInput">The updateOrderInput<see cref="UpdateOrderInputModel"/>.</param>
        /// <returns>The <see cref="UpdateOrderOutputModel"/>.</returns>
        [HttpPost("UpdateOrderAsync")]
        public ServiceRequestBaseModel UpdateOrderAsync(UpdateOrderInputModel updateOrderInput)
        {
            return orderQueueLibrary.PublishUpdateOrderToQueue(updateOrderInput);
        }

        #endregion
    }
}
