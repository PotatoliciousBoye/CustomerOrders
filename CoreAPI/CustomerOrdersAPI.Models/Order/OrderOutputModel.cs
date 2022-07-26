using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrdersAPI.Models.Order
{
    public class OrderOutputModel
    {
        /// <summary>
        /// Gets or sets the CustomerOrderId.
        /// </summary>
        public string CustomerOrderId { get; set; }

        /// <summary>
        /// Gets or sets the OrderId.
        /// </summary>
        public int? OrderId { get; set; }

        public string ErrorDescription { get; set; }
    }
}
