# ServiceFabric-Hangfire
Example of service fabric stateless service with [Hangfire](https://github.com/HangfireIO/Hangfire) for batch jobs.

This solution have three projects inside, one for service fabric publish and debug called **SfExample.Hangfire**, one for creating the queue and running the queue process called **BatchJob** and one for just running the Hangfire dashboard called **Web**.

Do not forget to create the Sql Server database and configure the connection string on **Startup.cs** at **Web** project and **BatchJob.cs** at **BatchJob** project.

Note that **BatchJob** project is a Hangfire client (generate queues) and also a server (process queues).
