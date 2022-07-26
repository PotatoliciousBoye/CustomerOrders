using System.Collections.Generic;

namespace CustomerOrdersAPI.Models.Order.Add.Input
{
    /// <summary>
    /// Defines the <see cref="AddOrderInputModel" />.
    /// </summary>
    public class AddOrderInputModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Orders.
        /// </summary>
        public List<OrderInputModel> Orders { get; set; }

        #endregion
    }
}
