using BusStopIssueExample.SimpleApp.Events;
using MassTransit;

namespace BusStopIssueExample.SimpleApp.Consumers
{
    public class ExampleEventConsumer : IConsumer<ExampleEvent>
    {
        public Task Consume(ConsumeContext<ExampleEvent> context)
        {
            Console.WriteLine("Message read");
            throw new InvalidOperationException("Simulate something went wrong");
        }
    }

    public class ExampleEventConsumerDefinition : ConsumerDefinition<ExampleEventConsumer>
    {
        public ExampleEventConsumerDefinition()
        {
            EndpointName = "example-message";

            ConcurrentMessageLimit = 1;
        }

        // Disabled retry policy on endpoint level as suggested
        //protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<ExampleEventConsumer> consumerConfigurator)
        //{
        //    endpointConfigurator.UseMessageRetry(r =>
        //    {
        //        r.Handle<InvalidOperationException>();
        //        r.Interval(100, TimeSpan.FromSeconds(1));
        //    });
        //}
    }
}
