using Confluent.Kafka;
using First_KafkaDemo.Interfaces;
using First_KafkaDemo.Services;

var builder = WebApplication.CreateBuilder(args);

var producerConfig = new ProducerConfig();

var ProducerTopic = builder.Configuration.GetValue<string>("Topic");
builder.Configuration.Bind("ProducerConfig", producerConfig);
builder.Services.AddSingleton<ProducerConfig>(producerConfig);

builder.Services.AddScoped<IProducerService, ProducerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/", () => "Welcome to Kafka Producer!");

app.MapPost("/send-message-to-kafka", async (HttpContext http) =>
{
    var messageToKafka = "";

    using (StreamReader sr = new(http.Request.Body))
    {
        messageToKafka = await sr.ReadToEndAsync();
    }

    if (string.IsNullOrWhiteSpace(messageToKafka))
    {
        throw new InvalidDataException("Must have a message body");
    }

    var producerService = http.RequestServices.GetRequiredService<IProducerService>();

    await producerService.SetTopic(ProducerTopic!);

    try
    {
        await producerService.Send(messageToKafka);
    }
    catch (Exception ex)
    {
        await http.Response.BodyWriter.WriteAsync(System.Text.Encoding.ASCII.GetBytes(ex.Message));

        http.Response.StatusCode = 500;
    }

    http.Response.StatusCode = 200;
});


app.Run();
