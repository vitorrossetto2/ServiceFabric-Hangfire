using System;
using System.Collections.Generic;
using System.Fabric;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace BatchJob
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class BatchJob : StatelessService
    {
        public BatchJob(StatelessServiceContext context)
            : base(context)
        { }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[0];
        }

        /// <summary>
        /// This is the main entry point for your service instance.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service instance.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("<connection string>");
    
            //telling to Hangfire to run this method every minute
            RecurringJob.AddOrUpdate(
                () => Console.WriteLine("Recurring"),
                Cron.MinuteInterval(1), queue: "recurring_queue");

            //creating a hangfire server for processing the batch job created above
            using (var server = new BackgroundJobServer(new BackgroundJobServerOptions()
            {
                Queues = new[] { "recurring_queue" }
            }))
            {
                //keep the server running forever!
                await Task.Delay(Timeout.Infinite, cancellationToken);
            }
        }
    }
}
