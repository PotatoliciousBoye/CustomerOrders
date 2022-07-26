using CustomerOrdersAPI.Models.Order.Add.Input;
using CustomerOrdersAPI.Models.Order.Add.Output;
using CustomerOrdersAPI.Models.Order.Get.Input;
using CustomerOrdersAPI.Models.Order.Get.Output;
using CustomerOrdersAPI.Models.Order.Update.Input;
using CustomerOrdersAPI.Models.Order.Update.Output;
using CustomerOrdersAPI.Models.OrderStatus.Get.Input;
using CustomerOrdersAPI.Models.OrderStatus.Get.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrdersAPI.Library.Order
{
    public interface IOrderLibrary
    {
        AddOrderOutputModel AddOrders(AddOrderInputModel addOrderInputModel);

        UpdateOrderOutputModel UpdateOrder(UpdateOrderInputModel updateOrderInputModel);

        GetOrderStatusOutputModel GetOrderStatus(GetOrderStatusInputModel getOrderStatusInputModel);

        GetAllOrdersOutputModel GetAllOrders(GetAllOrdersInputModel getAllOrdersInputModel);

        GetAllOrderStatusesOutputModel GetAllOrderStatuses(GetAllOrderStatusesInputModel getAllOrderStatusesInputModel);
    }
}
