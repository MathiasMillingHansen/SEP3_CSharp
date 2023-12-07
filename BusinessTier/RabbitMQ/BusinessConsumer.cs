using System.Text.Json;
using Shared.DTOs;

namespace RabbitMQ;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

public static class BusinessConsumer
{
    private const string QUEUE_NAME = "UserInfoQueue";
    private const string EXCHANGE_NAME = "UserInfoExchange";
    private const string ROUTING_KEY1 = "UserInfoRouting";
    private const string ROUTING_KEY2 = "AnotherRouting";

    public static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.ExchangeDeclare(exchange: EXCHANGE_NAME, type: "direct");
            channel.QueueDeclare(queue: QUEUE_NAME, durable: false, exclusive: false, autoDelete: false, arguments: null);

            channel.QueueBind(queue: QUEUE_NAME, exchange: EXCHANGE_NAME, routingKey: ROUTING_KEY1);
            channel.QueueBind(queue: QUEUE_NAME, exchange: EXCHANGE_NAME, routingKey: ROUTING_KEY2);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                UserInfoDto message = deserializeUserInfoDto(body);

                if (ea.RoutingKey == ROUTING_KEY1)
                {
                    // Perform action for ROUTING_KEY1
                    Console.WriteLine(" [x] Received from {0}: {1}", ROUTING_KEY1, message.username + " " + message.email + " " + message.phoneNumber);
                }
                else if (ea.RoutingKey == ROUTING_KEY2)
                {
                    // Perform action for ROUTING_KEY2
                    Console.WriteLine(" [x] Received from {0}: {1}", ROUTING_KEY2, message.username + " " + message.email + " " + message.phoneNumber);
                }
            };

            channel.BasicConsume(queue: QUEUE_NAME, autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }

    private static UserInfoDto deserializeUserInfoDto(byte[] body)
    {
        String message = Encoding.UTF8.GetString(body);
        return JsonSerializer.Deserialize<UserInfoDto>(message)!;
    }
}
