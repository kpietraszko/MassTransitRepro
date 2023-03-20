## Steps
1. Publish a message like this on the queue
```
{
    "messageId": "181c0000-6393-3630-36a4-08daf4e7c6da",
    "messageType": [
        "urn:message:MassTransitRepro:SampleEvent"
    ],
    "message": {
    }
}
```
2. Run the app and wait for it to complete
3. Notice that the message was moved to the "skipped" queue

## Logs
```
[12:00:58 DBG] Starting bus: rabbitmq://localhost:0/
[12:00:58 DBG] Connect: guest@localhost:5672/
[12:00:58 DBG] Connected: guest@localhost:5672/ (address: amqp://localhost:5672, local: 53445)
[12:00:58 DBG] Endpoint Ready: rabbitmq://localhost:0/5421002_MassTransitRepro_bus_yyyoyyyxieyyum3rbdp11cunf8?temporary=true
[12:00:58 DBG] Declare queue: name: test, durable, consumer-count: 0 message-count: 1
[12:00:58 DBG] Declare exchange: name: test, type: fanout, durable
[12:00:58 DBG] Declare exchange: name: MassTransitRepro:SampleEvent, type: fanout, durable
[12:00:58 DBG] Bind queue: source: test, destination: test
[12:00:58 DBG] Bind exchange: source: MassTransitRepro:SampleEvent, destination: test
[12:00:59 DBG] Consumer Ok: rabbitmq://localhost:0/test - amq.ctag-4n2Fl1CepMqDn3QfLm-faA
[12:00:59 DBG] Endpoint Ready: rabbitmq://localhost:0/test
[12:00:59 INF] Bus started: rabbitmq://localhost:0/
start consume and wait
start stop
[12:01:04 DBG] Stopping bus: rabbitmq://localhost:0/
[12:01:04 DBG] Endpoint Stopping: rabbitmq://localhost:0/test
[12:01:04 DBG] Stopping receive transport: rabbitmq://localhost:0/test
[12:01:04 DBG] Stopping Consumer: rabbitmq://localhost:0/test - amq.ctag-4n2Fl1CepMqDn3QfLm-faA
[12:01:04 DBG] Consumer Cancel Ok: rabbitmq://localhost:0/test - amq.ctag-4n2Fl1CepMqDn3QfLm-faA
[12:01:04 DBG] Endpoint Stopping: rabbitmq://localhost:0/5421002_MassTransitRepro_bus_yyyoyyyxieyyum3rbdp11cunf8?temporary=true
[12:01:04 DBG] Stopping receive transport: rabbitmq://localhost:0/5421002_MassTransitRepro_bus_yyyoyyyxieyyum3rbdp11cunf8?temporary=true
[12:01:04 DBG] Endpoint Completed: rabbitmq://localhost:0/5421002_MassTransitRepro_bus_yyyoyyyxieyyum3rbdp11cunf8?temporary=true
end waiting
[12:01:09 WRN] R-RETRY rabbitmq://localhost:0/test 181c0000-6393-3630-36a4-08daf4e7c6da MassTransit.Context.RetryConsumeContext
System.ApplicationException: Some exception caused by an external service. Timeout, 503 etc
   at MassTransitRepro.Consumer.Consume(ConsumeContext`1 context) in C:\source\MassTransitRepro\Program.cs:line 66
   at MassTransit.Pipeline.ConsumerFactories.DefaultConstructorConsumerFactory`1.Send[T](ConsumeContext`1 context, IPipe`1 next)
   at MassTransit.Pipeline.ConsumerFactories.DefaultConstructorConsumerFactory`1.Send[T](ConsumeContext`1 context, IPipe`1 next)
   at MassTransit.Pipeline.Filters.ConsumerMessageFilter`2.GreenPipes.IFilter<MassTransit.ConsumeContext<TMessage>>.Send(ConsumeContext`1 context, IPipe`1 next)
   at MassTransit.Pipeline.Filters.ConsumerMessageFilter`2.GreenPipes.IFilter<MassTransit.ConsumeContext<TMessage>>.Send(ConsumeContext`1 context, IPipe`1 next)
   at GreenPipes.Filters.RetryFilter`1.GreenPipes.IFilter<TContext>.Send(TContext context, IPipe`1 next)
[12:01:09 DBG] SKIP rabbitmq://localhost:0/test null
[12:01:09 DBG] Declare queue: name: test_skipped, durable, consumer-count: 0 message-count: 0
[12:01:09 DBG] Declare exchange: name: test_skipped, type: fanout, durable
[12:01:09 DBG] Bind queue: source: test_skipped, destination: test_skipped
[12:01:09 DBG] Endpoint Completed: rabbitmq://localhost:0/test
[12:01:09 DBG] Consumer completed amq.ctag-4n2Fl1CepMqDn3QfLm-faA: 1 received, 1 concurrent
[12:01:09 DBG] Disconnect: guest@localhost:5672/
[12:01:09 DBG] Disconnected: guest@localhost:5672/
[12:01:09 INF] Bus stopped: rabbitmq://localhost:0/
end stop
```
