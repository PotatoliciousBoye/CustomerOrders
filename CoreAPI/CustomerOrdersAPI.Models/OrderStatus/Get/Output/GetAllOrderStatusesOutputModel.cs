using CustomerOrdersAPI.Models.Base.Request;
using System.Collections.Generic;

namespace CustomerOrdersAPI.Models.OrderStatus.Get.Output
{
    /// <summary>
    /// Defines the <see cref="GetAllOrderStatusesOutputModel" />.
    /// </summary>
    public class GetAllOrderStatusesOutputModel : ServiceRequestBaseModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the OrderStatuses.
        /// </summary>
        public List<OrderStatusViewModel> OrderStatuses { get; set; }

        #endregion
    }
}
