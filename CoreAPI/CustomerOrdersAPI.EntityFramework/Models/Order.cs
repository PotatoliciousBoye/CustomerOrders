using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrdersAPI.EntityFramework.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string CustomerOrderId { get; set; }

        public string OriginAddress { get; set; }

        public string DestinationAddress { get; set; }

        public int MaterialQuantity { get; set; }

        public string QuantityUnit { get; set; }

        public int TotalWeight { get; set; }

        public string WeightUnit { get; set; }

        public string MaterialId { get; set; }

        public int OrderStatusId { get; set; }

        public string Note { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
