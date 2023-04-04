using NATS.Client;
using Quartz;
using System.Text;
namespace SimpleSampleConsole.Jobs.NatsSubscriber;

public class NatsSubscriberJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine("Starting NatsSubscriberJob ...");

        var natsUri = Environment.GetEnvironmentVariable("NATS_URI");

        var options = ConnectionFactory.GetDefaultOptions();
        options.Url = natsUri;
        using var connection = new ConnectionFactory().CreateConnection(options);
        var subject = "mySubject";
        var subscription = connection.SubscribeAsync(subject, (sender, args) =>
        {
            var message = Encoding.UTF8.GetString(args.Message.Data);
            Console.WriteLine("Received message: {0}", message);
        });

        await Task.CompletedTask;
        Console.WriteLine("NatsSubscriberJob Ending...");
    }
}
