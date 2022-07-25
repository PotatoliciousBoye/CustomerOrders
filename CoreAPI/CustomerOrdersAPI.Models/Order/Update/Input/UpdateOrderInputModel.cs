using System;

namespace CustomerOrdersAPI.Models.Order.Update.Input
{
    /// <summary>
    /// Defines the <see cref="UpdateOrderInputModel" />.
    /// </summary>
    public class UpdateOrderInputModel
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

        /// <summary>
        /// Gets or sets the UpdateDate.
        /// </summary>
        public DateTime UpdateDate { get; set; }

        #endregion
    }
}
