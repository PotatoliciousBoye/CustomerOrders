using CustomerOrdersAPI.Models.Base.Request;
using System.Collections.Generic;

namespace CustomerOrdersAPI.Models.Order.Add.Output
{
    /// <summary>
    /// Defines the <see cref="AddOrderOutputModel" />.
    /// </summary>
    public class AddOrderOutputModel : ServiceRequestBaseModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets the FailedAdditions.
        /// </summary>
        public List<OrderOutputModel> FailedAdditions { get; set; }

        /// <summary>
        /// Gets or sets the SucceededAdditions.
        /// </summary>
        public List<OrderOutputModel> SucceededAdditions { get; set; }

        #endregion
    }
}
