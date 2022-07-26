using CustomerOrdersAPI.Models.Base.Request;
using CustomerOrdersAPI.Models.Order.Add.Input;
using CustomerOrdersAPI.Models.Order.Update.Input;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace CustomerOrdersAPI.Library.Queue
{
    /// <summary>
    /// Defines the <see cref="OrderQueueLibrary" />.
    /// </summary>
    public class OrderQueueLibrary : IOrderQueueLibrary
    {
        #region Methods

        private const string RABBITMQ_HOSTNAME = "localhost";

        private const string ADD_ORDERS_QUEUE_NAME = "AddOrdersQueue";

        private const string UPDATE_ORDER_QUEUE_NAME = "UpdateOrderQueue";

        /// <summary>
        /// The PublishAddOrdersToQueue.
        /// </summary>
        /// <param name="addOrderInputModel">The addOrderInputModel<see cref="AddOrderInputModel"/>.</param>
        /// <returns>The <see cref="ServiceRequestBaseModel"/>.</returns>
        public ServiceRequestBaseModel PublishAddOrdersToQueue(AddOrderInputModel addOrderInputModel)
        {
            var factory = new ConnectionFactory() { HostName = RABBITMQ_HOSTNAME };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: ADD_ORDERS_QUEUE_NAME,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(addOrderInputModel));

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: ADD_ORDERS_QUEUE_NAME,
                                     basicProperties: null,
                                     body: body);
            }

            return new ServiceRequestBaseModel();
        }

        /// <summary>
        /// The PublishUpdateOrderToQueue.
        /// </summary>
        /// <param name="updateOrderInputModel">The updateOrderInputModel<see cref="UpdateOrderInputModel"/>.</param>
        /// <returns>The <see cref="ServiceRequestBaseModel"/>.</returns>
        public ServiceRequestBaseModel PublishUpdateOrderToQueue(UpdateOrderInputModel updateOrderInputModel)
        {
            var factory = new ConnectionFactory() { HostName = RABBITMQ_HOSTNAME};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: UPDATE_ORDER_QUEUE_NAME,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(updateOrderInputModel));

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: UPDATE_ORDER_QUEUE_NAME,
                                     basicProperties: null,
                                     body: body);
            }

            return new ServiceRequestBaseModel();
        }

        #endregion
    }
}
