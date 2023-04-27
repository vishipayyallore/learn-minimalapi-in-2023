using Confluent.Kafka;
using First_KafkaDemo.Interfaces;
using First_KafkaDemo.Services;

var builder = WebApplication.CreateBuilder(args);

var producerConfig = new ProducerConfig();

var ProducerTopic = builder.Configuration.GetValue<string>("Topic");
builder.Configuration.Bind("ProducerConfig", producerConfig);
builder.Services.AddSingleton<ProducerConfig>(producerConfig);
builder.Services.AddSingleton(ProducerTopic);

builder.Services.AddScoped<IProducerService, ProducerService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
