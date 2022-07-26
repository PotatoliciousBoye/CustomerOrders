using System;
using System.Collections.Generic;
using System.Text;
using CustomerOrdersAPI.Models.Base.Request;
using CustomerOrdersAPI.Models.Order.Add.Input;
using CustomerOrdersAPI.Models.Order.Update.Input;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace CustomerOrdersAPI.Library.Queue
{
    public class OrderQueueLibrary : IOrderQueueLibrary
    {

        public ServiceRequestBaseModel PublishAddOrdersToQueue(AddOrderInputModel addOrderInputModel)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "AddOrdersQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(addOrderInputModel));

                channel.BasicPublish(exchange: "",
                                     routingKey: "AddOrdersQueue",
                                     basicProperties: null,
                                     body: body);
            }

            return new ServiceRequestBaseModel();
        }

        public ServiceRequestBaseModel PublishUpdateOrderToQueue(UpdateOrderInputModel updateOrderInputModel)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "UpdateOrderQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(updateOrderInputModel));

                channel.BasicPublish(exchange: "",
                                     routingKey: "UpdateOrderQueue",
                                     basicProperties: null,
                                     body: body);
            }

            return new ServiceRequestBaseModel();
        }
    }
}
