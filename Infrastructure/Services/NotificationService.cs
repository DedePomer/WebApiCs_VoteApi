using System.Text;
using System.Text.Json;
using Infrastructure.DataTypes;
using RabbitMQ.Client;

namespace Infrastructure.Services;

public class NotificationService
{
    private readonly string _defaultText = "Спасибо что проголосовали";
    private readonly string _exchange = "Notification.topic";
    private readonly string _localHost = "localhost";
    
    public async Task NotificateMyMessanger(NotificationDataType nootification)
    {
        const string routingKey = "test.mq.classic";
        if (nootification.Text == null)
        {
            nootification.Text = _defaultText;
        }
        await Notificate(nootification, routingKey);
    }

    private async Task Notificate(NotificationDataType nootification, string routingKey)
    {
        var factory = new ConnectionFactory { HostName = _localHost };
        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();
        
        string jsonString = JsonSerializer.Serialize(nootification);
        var body = Encoding.UTF8.GetBytes(jsonString);
        
        await channel.BasicPublishAsync(
            exchange: _exchange,          
            routingKey: routingKey,   
            body: body);
    }
}