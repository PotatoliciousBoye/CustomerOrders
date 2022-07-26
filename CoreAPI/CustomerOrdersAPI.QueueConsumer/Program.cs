using CustomerOrdersAPI.Models.Order.Add.Input;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace CustomerOrdersAPI.QueueConsumer
{
    /// <summary>
    /// Defines the <see cref="Program" />.
    /// </summary>
    internal class Program
    {
        #region Constants

        /// <summary>
        /// Defines the ADD_ORDERS_QUEUE_NAME.
        /// </summary>
        private const string ADD_ORDERS_QUEUE_NAME = "AddOrdersQueue";

        /// <summary>
        /// Defines the RABBITMQ_HOSTNAME.
        /// </summary>
        private const string RABBITMQ_HOSTNAME = "localhost";

        /// <summary>
        /// Defines the UPDATE_ORDER_QUEUE_NAME.
        /// </summary>
        private const string UPDATE_ORDER_QUEUE_NAME = "UpdateOrderQueue";

        #endregion

        #region Methods

        /// <summary>
        /// The Main.
        /// </summary>
        /// <param name="args">The args<see cref="string[]"/>.</param>
        internal static void Main(string[] args)
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

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    var input = JsonConvert.DeserializeObject<AddOrderInputModel>(message);
                };
                channel.BasicConsume(queue: ADD_ORDERS_QUEUE_NAME,
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        #endregion
    }
}
