using Quartz;

namespace SimpleSampleConsole.Jobs.CronJobSample;

public static class Configure
{
    public static async Task<IScheduler> ConfigureCronjobSampleJob(this IScheduler scheduler)
    {
        var job = JobBuilder.Create<CronjobSampleJob>()
            .WithIdentity("cronJobSampleJob", "mongo")
            .Build();

        var trigger = TriggerBuilder.Create()
            .WithIdentity("cronJobSampleTrigger", "mongo")
            .StartNow()
            .WithCronSchedule("0/10 * * * * ?") // fire every 10 seconds
            .Build();

        await scheduler.ScheduleJob(job, trigger);
        return scheduler;
    }
}
