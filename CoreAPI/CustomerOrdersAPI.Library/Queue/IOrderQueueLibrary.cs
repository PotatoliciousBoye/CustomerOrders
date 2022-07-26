using CustomerOrdersAPI.Models.Base.Request;
using CustomerOrdersAPI.Models.Order.Add.Input;
using CustomerOrdersAPI.Models.Order.Update.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrdersAPI.Library.Queue
{
    public interface IOrderQueueLibrary
    {
        ServiceRequestBaseModel PublishAddOrdersToQueue(AddOrderInputModel addOrderInputModel);

        ServiceRequestBaseModel PublishUpdateOrderToQueue(UpdateOrderInputModel updateOrderInputModel);
    }
}
