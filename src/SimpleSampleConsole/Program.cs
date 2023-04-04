using Microsoft.Extensions.Hosting;
using Quartz.Impl;
using SimpleSampleConsole.Jobs.CronJobSample;
using SimpleSampleConsole.Jobs.NatsSubscriber;

Console.WriteLine("Hello, World!");
var hostBuilder = new HostBuilder();

var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
await scheduler.Start();

// jobs
await scheduler.ConfigureNatsJob();
await scheduler.ConfigureCronjobSampleJob();


await hostBuilder.RunConsoleAsync();
await scheduler.Shutdown();