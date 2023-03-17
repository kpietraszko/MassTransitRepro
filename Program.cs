using GreenPipes;
using MassTransit;

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
            Func<Exception, bool> handleRetryException = (ex) => {
                var ex3 = ex;
                return false;
            };
            var busControl = Bus.Factory.CreateUsingRabbitMq(x => {
                x.Host(new Uri("rabbitmq://localhost"), h => {
                    h.Username("guest");
                    h.Password("guest");
                });
                //with this retry it moves to skipped
                x.UseRetry(r => {
                    r.Immediate(5);
                    //r.Handle(handleRetryException);
                    r.Handle(); // with this line the message moves to error queue, without it, it moves to skipped
                });
                x.ReceiveEndpoint($"test", e => {
                    e.PrefetchCount = 1;
                    e.Consumer<Consumer>();
                });
            });
            return busControl;
        }
    }
    class Consumer : IConsumer<SampleEvent>
    {
        public async Task Consume(ConsumeContext<SampleEvent> context)
        {
            Console.WriteLine("start consume and wait");
            await Task.Delay(TimeSpan.FromSeconds(10));
            Console.WriteLine("end waiting");
            throw new ApplicationException("test");
        }
    }
    public class SampleEvent
    {
    }
}