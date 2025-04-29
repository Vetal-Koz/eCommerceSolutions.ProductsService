using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace eCommerce.Core.RabbitMQ;

public class RabbitMQPublisher : IRabbitMQPublisher, IDisposable
{
    private readonly IConfiguration _configuration;
    private readonly ConnectionFactory _connectionFactory;
    private IConnection _connection;
    private IChannel _channel;

    public RabbitMQPublisher(IConfiguration configuration)
    {
        _configuration = configuration;

        var hostName = _configuration["RabbitTMQ_HostName"];
        var userName = _configuration["RabbitTMQ_UserName"];
        var password = _configuration["RabbitTMQ_Password"];
        var port = _configuration["RabbitTMQ_Port"];

         _connectionFactory = new ConnectionFactory()
        {
            HostName = hostName,
            UserName = userName,
            Password = password,
            Port = ushort.Parse(port)
        };


    }

    private async Task InitAsync()
    {
        _connection = await _connectionFactory.CreateConnectionAsync();
        _channel = await _connection.CreateChannelAsync();
    }
    
    public async void Publish<T>(string routingKey, T message)
    {
        await InitAsync();
        string messageJson = JsonSerializer.Serialize(message);
        byte[] messageBodyInBytes =  Encoding.UTF8.GetBytes(messageJson);
        string exchangeName = _configuration["RabbitMQ_Products_Exchange"]!;
        
        await _channel.ExchangeDeclareAsync(
            exchange: exchangeName, type: ExchangeType.Direct, durable: true);

        await _channel.BasicPublishAsync(exchangeName, routingKey,  new BasicProperties(), messageBodyInBytes);
    }

    public void Dispose()
    {
        _connection.Dispose();
        _channel.Dispose();
    }
}