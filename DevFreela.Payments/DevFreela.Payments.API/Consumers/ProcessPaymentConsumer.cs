﻿using DevFreela.Payments.API.Models;
using DevFreela.Payments.API.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DevFreela.Payments.API.Consumers
{
    public class ProcessPaymentConsumer : BackgroundService
    {
        private const string PAYMENTS_QUEUE = "Payments";
        private const string PAYMENTS_APPROVED_QUEUE = "PaymentsApproved";
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;
        public ProcessPaymentConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: PAYMENTS_QUEUE,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            _channel.QueueDeclare(
                queue: PAYMENTS_APPROVED_QUEUE,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var byteArray = eventArgs.Body.ToArray();
                var paymentInfoJson = Encoding.UTF8.GetString(byteArray);
                var paymentInfo = JsonSerializer.Deserialize<PaymentInfoInputModel>(paymentInfoJson);
                await ProcessPayment(paymentInfo);

                var paymentApproved = new PaymentApprovedIntegrationEvent(paymentInfo.ProjectId);
                var paymentApprovedJson = JsonSerializer.Serialize(paymentApproved);
                var paymentApprovedBytes = Encoding.UTF8.GetBytes(paymentApprovedJson);

                _channel.BasicPublish(
                    exchange: string.Empty,
                    routingKey: PAYMENTS_APPROVED_QUEUE,
                    basicProperties: null,
                    body: paymentApprovedBytes);


                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(PAYMENTS_QUEUE, false, consumer);

            await Task.CompletedTask;
        }

        private async Task ProcessPayment(PaymentInfoInputModel paymentInfo)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();

                await paymentService.ProcessAsync(paymentInfo);
            }
        }
    }
}
