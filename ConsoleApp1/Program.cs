/* This file follows https://docs.particular.net/tutorials/nservicebus-step-by-step/1-getting-started/ */
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }

        static async Task AsyncMain()
        {
            Console.Title = "ClientUI";

            var endpointConfiguration = new EndpointConfiguration("ClientUI");

            /*
             * LearningTransport - starter transport for learning purposes
             * (other transports can be attained through nugget)
             */
            var transport = endpointConfiguration.UseTransport<LearningTransport>();


            /* Start the endpoint */
            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Presss Enter to exit...");
            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }
}
