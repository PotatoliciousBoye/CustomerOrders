using CustomerOrdersAPI.Models.Base.Request;

namespace CustomerOrdersAPI.Models.Order.Add.Output
{
    /// <summary>
    /// Defines the <see cref="AddOrderOutputModel" />.
    /// </summary>
    public class AddOrderOutputModel : ServiceRequestBaseModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CustomerOrderId.
        /// </summary>
        public string CustomerOrderId { get; set; }

        /// <summary>
        /// Gets or sets the OrderId.
        /// </summary>
        public int OrderId { get; set; }

        #endregion
    }
}
