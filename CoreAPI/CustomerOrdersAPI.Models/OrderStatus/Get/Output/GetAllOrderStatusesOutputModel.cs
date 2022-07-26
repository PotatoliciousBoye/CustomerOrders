using CustomerOrdersAPI.Models.Base.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrdersAPI.Models.OrderStatus.Get.Output
{
    public class GetAllOrderStatusesOutputModel : ServiceRequestBaseModel
    {
        public List<OrderStatusViewModel> OrderStatuses { get; set; }
    }
}
