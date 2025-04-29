﻿namespace eCommerce.Core.RabbitMQ;

public interface IRabbitMQPublisher
{
    void Publish<T>(string routingKey, T message);
}