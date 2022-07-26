﻿using CustomerOrdersAPI.EntityFramework;
using CustomerOrdersAPI.Models.Order;
using CustomerOrdersAPI.Models.Order.Add.Input;
using CustomerOrdersAPI.Models.Order.Add.Output;
using CustomerOrdersAPI.Models.Order.Get.Input;
using CustomerOrdersAPI.Models.Order.Get.Output;
using CustomerOrdersAPI.Models.Order.Update.Input;
using CustomerOrdersAPI.Models.Order.Update.Output;
using CustomerOrdersAPI.Models.OrderStatus;
using CustomerOrdersAPI.Models.OrderStatus.Get.Input;
using CustomerOrdersAPI.Models.OrderStatus.Get.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using EntityModels = CustomerOrdersAPI.EntityFramework.Models;

namespace CustomerOrdersAPI.Library.Order
{
    /// <summary>
    /// Defines the <see cref="OrderLibrary" />.
    /// </summary>
    public class OrderLibrary : IOrderLibrary
    {
        #region Constants

        /// <summary>
        /// Defines the API_NAME.
        /// </summary>
        private const string API_NAME = "CoreAPI";

        /// <summary>
        /// Defines the DEFAULT_ORDER_STATUS_ID.
        /// </summary>
        private const int DEFAULT_ORDER_STATUS_ID = 1;

        /// <summary>
        /// Defines the EXISTING_VALUE_ERROR_DESCRIPTION.
        /// </summary>
        private const string EXISTING_VALUE_ERROR_DESCRIPTION = "Girilen müşteri sipariş numarası daha önceden kullanılmış.";

        #endregion

        #region Fields

        /// <summary>
        /// Defines the customerOrdersDbContext.
        /// </summary>
        private CustomerOrdersDbContext customerOrdersDbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderLibrary"/> class.
        /// </summary>
        /// <param name="customerOrdersDbContext">The customerOrdersDbContext<see cref="CustomerOrdersDbContext"/>.</param>
        public OrderLibrary(CustomerOrdersDbContext customerOrdersDbContext)
        {
            this.customerOrdersDbContext = customerOrdersDbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The AddOrders.
        /// </summary>
        /// <param name="addOrderInputModel">The addOrderInputModel<see cref="AddOrderInputModel"/>.</param>
        /// <returns>The <see cref="AddOrderOutputModel"/>.</returns>
        public AddOrderOutputModel AddOrders(AddOrderInputModel addOrderInputModel)
        {
            var materialList = from orderInput in addOrderInputModel.Orders
                               where !(from existingMaterial in customerOrdersDbContext.Materials
                                       select existingMaterial.MaterialId).Contains(orderInput.MaterialId)
                               select new EntityModels.Material
                               {
                                   MaterialId = orderInput.MaterialId,
                                   MaterialName = orderInput.MaterialName,
                                   CreatedBy = API_NAME,
                                   CreateDate = DateTime.Now
                               };

            customerOrdersDbContext.AddRange(materialList);

            var failedOrderList = (from order in addOrderInputModel.Orders
                                   where (from existingOrder in customerOrdersDbContext.Orders
                                          select existingOrder.CustomerOrderId).Contains(order.CustomerOrderId)
                                   select new OrderOutputModel
                                   {
                                       CustomerOrderId = order.CustomerOrderId,
                                       ErrorDescription = EXISTING_VALUE_ERROR_DESCRIPTION
                                   }).ToList();

            var orderList = (from order in addOrderInputModel.Orders
                             where !(from existingOrder in customerOrdersDbContext.Orders
                                     select existingOrder.CustomerOrderId).Contains(order.CustomerOrderId)
                             select new EntityModels.Order
                             {
                                 CustomerOrderId = order.CustomerOrderId,
                                 OriginAddress = order.OriginAddress,
                                 DestinationAddress = order.DestinationAddress,
                                 MaterialQuantity = order.MaterialQuantity,
                                 QuantityUnit = order.QuantityUnit,
                                 TotalWeight = order.TotalWeight,
                                 WeightUnit = order.WeightUnit,
                                 MaterialId = order.MaterialId,
                                 Note = order.Note,
                                 CreateDate = DateTime.Now,
                                 CreatedBy = API_NAME,
                                 OrderStatusId = DEFAULT_ORDER_STATUS_ID
                             }).ToList();

            var succeededOrderList = (from order in orderList
                                      select new OrderOutputModel
                                      {
                                          CustomerOrderId = order.CustomerOrderId,
                                          OrderId = order.OrderId
                                      }).ToList();

            customerOrdersDbContext.AddRange(orderList);

            customerOrdersDbContext.SaveChanges();

            return new AddOrderOutputModel() { SucceededAdditions = succeededOrderList, FailedAdditions = failedOrderList };
        }

        /// <summary>
        /// The GetAllOrders.
        /// </summary>
        /// <param name="getAllOrdersInputModel">The getAllOrdersInputModel<see cref="GetAllOrdersInputModel"/>.</param>
        /// <returns>The <see cref="GetAllOrdersOutputModel"/>.</returns>
        public GetAllOrdersOutputModel GetAllOrders(GetAllOrdersInputModel getAllOrdersInputModel)
        {
            var orders = (from existingOrders in customerOrdersDbContext.Orders
                          join materials in customerOrdersDbContext.Materials
                             on existingOrders.MaterialId equals materials.MaterialId
                          join orderStatuses in customerOrdersDbContext.OrderStatuses
                             on existingOrders.OrderStatusId equals orderStatuses.OrderStatusId
                          select new OrderViewModel
                          {
                              CustomerOrderId = existingOrders.CustomerOrderId,
                              OrderStatus = orderStatuses.OrderStatusDescription,
                              DestinationAddress = existingOrders.DestinationAddress,
                              OriginAddress = existingOrders.OriginAddress,
                              MaterialId = materials.MaterialId,
                              MaterialName = materials.MaterialName,
                              MaterialQuantity = existingOrders.MaterialQuantity,
                              QuantityUnit = existingOrders.QuantityUnit,
                              Note = existingOrders.Note,
                              TotalWeight = existingOrders.TotalWeight,
                              WeightUnit = existingOrders.WeightUnit
                          }).ToList();

            return new GetAllOrdersOutputModel() { Orders = orders };
        }

        /// <summary>
        /// The GetAllOrderStatuses.
        /// </summary>
        /// <param name="getAllOrderStatusesInputModel">The getAllOrderStatusesInputModel<see cref="GetAllOrderStatusesInputModel"/>.</param>
        /// <returns>The <see cref="GetAllOrderStatusesOutputModel"/>.</returns>
        public GetAllOrderStatusesOutputModel GetAllOrderStatuses(GetAllOrderStatusesInputModel getAllOrderStatusesInputModel)
        {
            var orderStatuses = (from orderStatus in customerOrdersDbContext.OrderStatuses
                                 select new OrderStatusViewModel
                                 {
                                     OrderStatusId = orderStatus.OrderStatusId,
                                     OrderStatusName = orderStatus.OrderStatusDescription
                                 }).ToList();

            return new GetAllOrderStatusesOutputModel() { OrderStatuses = orderStatuses };
        }

        /// <summary>
        /// The GetOrderStatus.
        /// </summary>
        /// <param name="getOrderStatusInputModel">The getOrderStatusInputModel<see cref="GetOrderStatusInputModel"/>.</param>
        /// <returns>The <see cref="GetOrderStatusOutputModel"/>.</returns>
        public GetOrderStatusOutputModel GetOrderStatus(GetOrderStatusInputModel getOrderStatusInputModel)
        {
            var selectedOrder = customerOrdersDbContext.Orders.SingleOrDefault(order => order.CustomerOrderId == getOrderStatusInputModel.CustomerOrderId);

            return new GetOrderStatusOutputModel() { CustomerOrderId = selectedOrder.CustomerOrderId, OrderStatusId = selectedOrder.OrderStatusId };
        }

        /// <summary>
        /// The UpdateOrder.
        /// </summary>
        /// <param name="updateOrderInputModel">The updateOrderInputModel<see cref="UpdateOrderInputModel"/>.</param>
        /// <returns>The <see cref="UpdateOrderOutputModel"/>.</returns>
        public UpdateOrderOutputModel UpdateOrder(UpdateOrderInputModel updateOrderInputModel)
        {
            var orderToUpdate = customerOrdersDbContext.Orders.SingleOrDefault(order => order.CustomerOrderId == updateOrderInputModel.CustomerOrderId);
            orderToUpdate.OrderStatusId = updateOrderInputModel.OrderStatusId;
            orderToUpdate.UpdateDate = updateOrderInputModel.UpdateDate;
            orderToUpdate.UpdatedBy = API_NAME;

            customerOrdersDbContext.SaveChanges();

            return new UpdateOrderOutputModel();
        }

        #endregion
    }
}
