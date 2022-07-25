using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrdersAPI.EntityFramework.Models
{
    public class OrderStatus
    {
        public int OrderStatusId { get; set; }

        public string OrderStatusDescription { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
