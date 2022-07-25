using CustomerOrdersAPI.Models.Base.Request;

namespace CustomerOrdersAPI.Models.Order.Get.Output
{
    /// <summary>
    /// Defines the <see cref="GetOrderStatusOutputModel" />.
    /// </summary>
    public class GetOrderStatusOutputModel : ServiceRequestBaseModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CustomerOrderId.
        /// </summary>
        public string CustomerOrderId { get; set; }

        /// <summary>
        /// Gets or sets the OrderStatus.
        /// </summary>
        public int OrderStatus { get; set; }

        #endregion
    }
}
