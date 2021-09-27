using Joystick_API_Azure_SpecFlow_MSTest.Domain.Models.Joystick;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joystick_API_Azure_SpecFlow_MSTest.Helpers.Joystick
{
    public static class RabbitMQRequests
    {
        public static void SendRequest(string HostName, string UserName, string Password, string Message, string PublishExchange, string PublishRoutingKey)
        {
            //TODO: Need to add RabbitMQ to APIResponse and add Port as parameter
            var apiResponse = new APIResponse();
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = HostName,
                    Port = 5672,
                    VirtualHost = "/",
                    UserName = UserName,
                    Password = Password
                };
                using (IConnection conn = factory.CreateConnection())
                {
                    var channel = conn.CreateModel();
                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = false;
                    var bytes = Encoding.UTF8.GetBytes(Message);
                    channel.BasicPublish(PublishExchange, PublishRoutingKey, properties, bytes);
                    channel.Close();
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
