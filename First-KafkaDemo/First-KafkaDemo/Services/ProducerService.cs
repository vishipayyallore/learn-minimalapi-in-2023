using First_KafkaDemo.Interfaces;

namespace First_KafkaDemo.Services;

public class ProducerService : IProducerService
{
    public Task Send(string message)
    {
        throw new NotImplementedException();
    }

    public Task SetTopic(string topicName)
    {
        throw new NotImplementedException();
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
