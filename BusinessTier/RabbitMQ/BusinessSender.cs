using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
namespace RabbitMQ;

public static class BusinessSender
{
    private const string QUEUE_NAME = "UserInfoQueue";
    private const string EXCHANGE_NAME = "UserInfoExchange";
    private const string ROUTING_KEY = "UserInfoRouting";

    public static async Task<string> SendMessage(string username)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        
        string usernameToReturn = "NotValidUser";

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
            
        {
            channel.ExchangeDeclare(exchange: EXCHANGE_NAME, type: "direct");
            channel.QueueDeclare(queue: QUEUE_NAME, durable: false, exclusive: false, autoDelete: false,
                arguments: null);

            var replyQueueName = channel.QueueDeclare().QueueName;

            var props = channel.CreateBasicProperties();
            var correlationId = Guid.NewGuid().ToString();
            props.CorrelationId = correlationId;
            props.ReplyTo = replyQueueName;

            var message = JsonSerializer.Serialize(username);
            var body = Encoding.UTF8.GetBytes(message);

            var response = new TaskCompletionSource<string>();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var responseMessage = Encoding.UTF8.GetString(body);
                if (ea.BasicProperties.CorrelationId == correlationId)
                {
                    response.SetResult(responseMessage);
                }
            };

            channel.BasicConsume(consumer: consumer, queue: replyQueueName, autoAck: true);

            channel.BasicPublish(exchange: EXCHANGE_NAME, routingKey: ROUTING_KEY, basicProperties: props, body: body);

            await response.Task; // Wait until the response is received

            Console.WriteLine("Received response: " + response.Task.Result);
            
            usernameToReturn = response.Task.Result;

            if (response.Task.Result.Equals("NotValidUser"))
            {
                throw new Exception("User is not valid");
            }
        }
        
        return usernameToReturn;
    }
}