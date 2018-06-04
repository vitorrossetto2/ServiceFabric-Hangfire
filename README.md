# ServiceFabric-Hangfire
Example of service fabric stateless service with hangfire for batch jobs.

This solution have three projects inside, one for service fabric publish and debug called SfExample.Hangfire, one for creating the queue and running the queue process called BatchJob and one for just running the Hangfire dashboard.

Do not forget to create the Sql Server database and configure the connection string on **Startup.cs** at **Web** Project and **BatchJob.cs** at **BatchJob** Project.
