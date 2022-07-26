using System.Collections.Generic;

namespace CustomerOrdersAPI.Models.Order.Add.Input
{
    /// <summary>
    /// Defines the <see cref="AddOrderInputModel" />.
    /// </summary>
    public class AddOrderInputModel
    {
        #region Properties

        public List<OrderInputModel> Orders { get; set; }

        #endregion
    }
}
