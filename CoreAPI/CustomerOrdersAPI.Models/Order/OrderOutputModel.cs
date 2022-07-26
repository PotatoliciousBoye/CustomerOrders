namespace CustomerOrdersAPI.Models.Order
{
    /// <summary>
    /// Defines the <see cref="OrderOutputModel" />.
    /// </summary>
    public class OrderOutputModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the CustomerOrderId.
        /// </summary>
        public string CustomerOrderId { get; set; }

        /// <summary>
        /// Gets or sets the ErrorDescription.
        /// </summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Gets or sets the OrderId.
        /// </summary>
        public int? OrderId { get; set; }

        #endregion
    }
}
