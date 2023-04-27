namespace First_KafkaDemo.Interfaces;

interface IProducerService : IHostedService
{
    Task Send(string message);

    Task SetTopic(string topicName);
}