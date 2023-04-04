using Quartz;

namespace SimpleSampleConsole.Jobs.NatsSubscriber;

public static class Configure
{
    public static async Task<IScheduler> ConfigureNatsJob(this IScheduler scheduler)
    {
        var job = JobBuilder.Create<NatsSubscriberJob>()
            .WithIdentity("natsSubscriberJob", "nats")
            .Build();

        var trigger = TriggerBuilder.Create()
            .WithIdentity("natsSubscriberTrigger", "nats")
            .StartNow()
            .WithCronSchedule("0/10 * * * * ?") // fire every 10 seconds
            .Build();

        await scheduler.ScheduleJob(job, trigger);
        return scheduler;
    }
}
