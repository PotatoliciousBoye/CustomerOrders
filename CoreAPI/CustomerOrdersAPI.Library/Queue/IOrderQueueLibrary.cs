using CustomerOrdersAPI.Models.Base.Request;
using CustomerOrdersAPI.Models.Order.Add.Input;
using CustomerOrdersAPI.Models.Order.Update.Input;

namespace CustomerOrdersAPI.Library.Queue
{
    /// <summary>
    /// Defines the <see cref="IOrderQueueLibrary" />.
    /// </summary>
    public interface IOrderQueueLibrary
    {
        #region Methods

        /// <summary>
        /// The PublishAddOrdersToQueue.
        /// </summary>
        /// <param name="addOrderInputModel">The addOrderInputModel<see cref="AddOrderInputModel"/>.</param>
        /// <returns>The <see cref="ServiceRequestBaseModel"/>.</returns>
        ServiceRequestBaseModel PublishAddOrdersToQueue(AddOrderInputModel addOrderInputModel);

        /// <summary>
        /// The PublishUpdateOrderToQueue.
        /// </summary>
        /// <param name="updateOrderInputModel">The updateOrderInputModel<see cref="UpdateOrderInputModel"/>.</param>
        /// <returns>The <see cref="ServiceRequestBaseModel"/>.</returns>
        ServiceRequestBaseModel PublishUpdateOrderToQueue(UpdateOrderInputModel updateOrderInputModel);

        #endregion
    }
}
