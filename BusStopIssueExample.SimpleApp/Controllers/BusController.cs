using BusStopIssueExample.SimpleApp.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace BusStopIssueExample.SimpleApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BusController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IBusControl _busControl;

        public BusController(IBusControl busControl, IBus bus)
        {
            _busControl = busControl;
            _bus = bus;
        }

        [HttpPut("stop")]
        public async Task Stop(CancellationToken cancellationToken)
        {
            await _busControl.StopAsync(cancellationToken);
        }

        [HttpPut("start")]
        public async Task Start(CancellationToken cancellationToken)
        {
            await _busControl.StartAsync(cancellationToken);
        }

        [HttpPost("publishMessage")]
        public async Task PublishMessage(CancellationToken cancellationToken)
        {
            await _bus.Publish(new ExampleEvent(Guid.NewGuid()), cancellationToken);
        }
    }
}