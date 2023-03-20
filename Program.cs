using MassTransit;
using Serilog;
using Serilog.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace MassTransitRepro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var d = CreateRabbitMqBus();
            d.Start();
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();
            Console.WriteLine("start stop");
            d.Stop();
            Console.WriteLine("end stop");
        }
        protected static IBusControl CreateRabbitMqBus()
        {
            Func<Exception, bool> handleRetryException = _ => {
                return true;
            };
            var busControl = Bus.Factory.CreateUsingRabbitMq(x => {
                x.Host(new Uri("rabbitmq://localhost"), h => {
                    h.Username("guest");
                    h.Password("guest");
                });
                //with this retry it moves to skipped
                x.UseRetry(r => {
                    r.Immediate(5);
                    r.Handle(handleRetryException);
                });
                x.ReceiveEndpoint($"test", e => {
                    e.PrefetchCount = 1;
                    e.Consumer<Consumer>();
                });

                LogContext.ConfigureCurrentLogContext(GetLogger());
            });
            return busControl;
        }

        private static ILogger GetLogger()
        {
            var serilogLogger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            var microsoftLogger = new SerilogLoggerFactory(serilogLogger)
                .CreateLogger("MassTransitRepro");

            return microsoftLogger; 
        }
    }
    class Consumer : IConsumer<SampleEvent>
    {
        public async Task Consume(ConsumeContext<SampleEvent> context)
        {
            Console.WriteLine("start consume and wait");
            await Task.Delay(TimeSpan.FromSeconds(10));
            Console.WriteLine("end waiting");
            throw new ApplicationException("Some exception caused by an external service. Timeout, 503 etc");
        }
    }
    public class SampleEvent
    {
    }
}