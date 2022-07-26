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

        public List<OrderOutputModel> SucceededAdditions { get; set; }
        public List<OrderOutputModel> FailedAdditions { get; set; }

        #endregion
    }
}
