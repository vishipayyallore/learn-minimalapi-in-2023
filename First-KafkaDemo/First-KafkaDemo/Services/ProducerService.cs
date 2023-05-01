using Confluent.Kafka;
using First_KafkaDemo.Interfaces;

namespace First_KafkaDemo.Services;

public class ProducerService : IProducerService
{
    private readonly ProducerConfig _config = default!;
    private readonly ILogger<ProducerService> _logger = default!;
    private readonly IProducer<int, string> _producer = default!;
    private readonly ProducerBuilder<int, string> _builder = default!;

    public string? Topic { get; private set; }

    public ProducerService(ProducerConfig config, ILogger<ProducerService> logger)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        Topic = string.Empty;

        _builder = new ProducerBuilder<int, string>(_config);
        _producer = _builder.Build();
    }

    public async Task Send(string message)
    {
        await Task.Run(() =>
        {
            var messagePacket = new Message<int, string>() { Key = 1, Value = message };

            _logger.LogInformation($"Sending Message: {messagePacket}");

            _producer.ProduceAsync(Topic, messagePacket, CancellationToken.None);

            _logger.LogInformation($"Message: {messagePacket} Sent!");
        });
    }

    public async Task SetTopic(string topicName)
    {
        await Task.Run(() => { Topic = topicName; });
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
