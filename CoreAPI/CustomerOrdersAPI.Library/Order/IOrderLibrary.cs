using CustomerOrdersAPI.Models.Order.Add.Input;
using CustomerOrdersAPI.Models.Order.Add.Output;
using CustomerOrdersAPI.Models.Order.Get.Input;
using CustomerOrdersAPI.Models.Order.Get.Output;
using CustomerOrdersAPI.Models.Order.Update.Input;
using CustomerOrdersAPI.Models.Order.Update.Output;
using CustomerOrdersAPI.Models.OrderStatus.Get.Input;
using CustomerOrdersAPI.Models.OrderStatus.Get.Output;

namespace CustomerOrdersAPI.Library.Order
{
    /// <summary>
    /// Defines the <see cref="IOrderLibrary" />.
    /// </summary>
    public interface IOrderLibrary
    {
        #region Methods

        /// <summary>
        /// The AddOrders.
        /// </summary>
        /// <param name="addOrderInputModel">The addOrderInputModel<see cref="AddOrderInputModel"/>.</param>
        /// <returns>The <see cref="AddOrderOutputModel"/>.</returns>
        AddOrderOutputModel AddOrders(AddOrderInputModel addOrderInputModel);

        /// <summary>
        /// The GetAllOrders.
        /// </summary>
        /// <param name="getAllOrdersInputModel">The getAllOrdersInputModel<see cref="GetAllOrdersInputModel"/>.</param>
        /// <returns>The <see cref="GetAllOrdersOutputModel"/>.</returns>
        GetAllOrdersOutputModel GetAllOrders(GetAllOrdersInputModel getAllOrdersInputModel);

        /// <summary>
        /// The GetAllOrderStatuses.
        /// </summary>
        /// <param name="getAllOrderStatusesInputModel">The getAllOrderStatusesInputModel<see cref="GetAllOrderStatusesInputModel"/>.</param>
        /// <returns>The <see cref="GetAllOrderStatusesOutputModel"/>.</returns>
        GetAllOrderStatusesOutputModel GetAllOrderStatuses(GetAllOrderStatusesInputModel getAllOrderStatusesInputModel);

        /// <summary>
        /// The GetOrderStatus.
        /// </summary>
        /// <param name="getOrderStatusInputModel">The getOrderStatusInputModel<see cref="GetOrderStatusInputModel"/>.</param>
        /// <returns>The <see cref="GetOrderStatusOutputModel"/>.</returns>
        GetOrderStatusOutputModel GetOrderStatus(GetOrderStatusInputModel getOrderStatusInputModel);

        /// <summary>
        /// The UpdateOrder.
        /// </summary>
        /// <param name="updateOrderInputModel">The updateOrderInputModel<see cref="UpdateOrderInputModel"/>.</param>
        /// <returns>The <see cref="UpdateOrderOutputModel"/>.</returns>
        UpdateOrderOutputModel UpdateOrder(UpdateOrderInputModel updateOrderInputModel);

        #endregion
    }
}
