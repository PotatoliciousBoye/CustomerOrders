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

        /// <summary>
        /// Defines the orderQueueLibrary.
        /// </summary>
        private IOrderQueueLibrary orderQueueLibrary;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="customerOrdersDbContext">The customerOrdersDbContext<see cref="CustomerOrdersDbContext"/>.</param>
        /// <param name="orderLibrary">The orderLibrary<see cref="IOrderLibrary"/>.</param>
        /// <param name="orderQueueLibrary">The orderQueueLibrary<see cref="IOrderQueueLibrary"/>.</param>
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
            try
            {
                return orderLibrary.AddOrders(addOrderInput);
            }
            catch (System.Exception ex)
            {
                return new AddOrderOutputModel() { ResultStatusCode = 1, ErrorDescription = ex.Message };
            }
        }

        /// <summary>
        /// The AddOrdersAsync.
        /// </summary>
        /// <param name="addOrderInput">The addOrderInput<see cref="AddOrderInputModel"/>.</param>
        /// <returns>The <see cref="AddOrderOutputModel"/>.</returns>
        [HttpPost("AddOrdersAsync")]
        public ServiceRequestBaseModel AddOrdersAsync(AddOrderInputModel addOrderInput)
        {
            try
            {
                return orderQueueLibrary.PublishAddOrdersToQueue(addOrderInput);
            }
            catch (System.Exception ex)
            {

                return new ServiceRequestBaseModel() { ResultStatusCode = 1, ErrorDescription = ex.Message };
            }
        }

        /// <summary>
        /// The GetAllOrders.
        /// </summary>
        /// <param name="getAllOrdersInput">The getAllOrdersInput<see cref="GetAllOrdersInputModel"/>.</param>
        /// <returns>The <see cref="GetAllOrdersOutputModel"/>.</returns>
        [HttpGet("GetAllOrders")]
        public GetAllOrdersOutputModel GetAllOrders([FromForm] GetAllOrdersInputModel getAllOrdersInput)
        {
            try
            {
                return orderLibrary.GetAllOrders(getAllOrdersInput);
            }
            catch (System.Exception ex)
            {
                return new GetAllOrdersOutputModel() { ResultStatusCode = 1, ErrorDescription = ex.Message };
            }
        }

        /// <summary>
        /// The GetAllOrderStatuses.
        /// </summary>
        /// <param name="getAllOrderStatusesInputModel">The getAllOrderStatusesInputModel<see cref="GetAllOrderStatusesInputModel"/>.</param>
        /// <returns>The <see cref="GetAllOrderStatusesOutputModel"/>.</returns>
        [HttpGet("GetAllOrderStatuses")]
        public GetAllOrderStatusesOutputModel GetAllOrderStatuses([FromForm] GetAllOrderStatusesInputModel getAllOrderStatusesInputModel)
        {
            try
            {
                return orderLibrary.GetAllOrderStatuses(getAllOrderStatusesInputModel);
            }
            catch (System.Exception ex)
            {

                return new GetAllOrderStatusesOutputModel() { ResultStatusCode = 1, ErrorDescription = ex.Message };
            }
        }

        /// <summary>
        /// The GetOrderStatus.
        /// </summary>
        /// <param name="getOrderStatusInput">The getOrderStatusInput<see cref="GetOrderStatusInputModel"/>.</param>
        /// <returns>The <see cref="GetOrderStatusOutputModel"/>.</returns>
        [HttpPost("GetOrderStatus")]
        public GetOrderStatusOutputModel GetOrderStatus(GetOrderStatusInputModel getOrderStatusInput)
        {
            try
            {
                return orderLibrary.GetOrderStatus(getOrderStatusInput);

            }
            catch (System.Exception ex)
            {

                return new GetOrderStatusOutputModel() { ResultStatusCode = 1, ErrorDescription = ex.Message };
            }
        }

        /// <summary>
        /// The UpdateOrder.
        /// </summary>
        /// <param name="updateOrderInput">The updateOrderInput<see cref="UpdateOrderInputModel"/>.</param>
        /// <returns>The <see cref="UpdateOrderOutputModel"/>.</returns>
        [HttpPost("UpdateOrder")]
        public UpdateOrderOutputModel UpdateOrder(UpdateOrderInputModel updateOrderInput)
        {
            try
            {

                return orderLibrary.UpdateOrder(updateOrderInput);
            }
            catch (System.Exception ex)
            {

                return new UpdateOrderOutputModel() { ResultStatusCode = 1, ErrorDescription = ex.Message };
            }
        }

        /// <summary>
        /// The UpdateOrderAsync.
        /// </summary>
        /// <param name="updateOrderInput">The updateOrderInput<see cref="UpdateOrderInputModel"/>.</param>
        /// <returns>The <see cref="UpdateOrderOutputModel"/>.</returns>
        [HttpPost("UpdateOrderAsync")]
        public ServiceRequestBaseModel UpdateOrderAsync(UpdateOrderInputModel updateOrderInput)
        {
            try
            {
                return orderQueueLibrary.PublishUpdateOrderToQueue(updateOrderInput);

            }
            catch (System.Exception ex)
            {

                return new ServiceRequestBaseModel() { ResultStatusCode = 1, ErrorDescription = ex.Message };
            }
        }

        #endregion
    }
}
