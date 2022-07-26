using CustomerOrdersAPI.Models.Base.Request;
using System.Collections.Generic;

namespace CustomerOrdersAPI.Models.Order.Get.Output
{
    /// <summary>
    /// Defines the <see cref="GetAllOrdersOutputModel" />.
    /// </summary>
    public class GetAllOrdersOutputModel : ServiceRequestBaseModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Orders.
        /// </summary>
        public List<OrderViewModel> Orders { get; set; }

        #endregion
    }
}
