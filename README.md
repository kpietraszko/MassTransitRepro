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
[13:35:25 DBG] Starting bus: rabbitmq://localhost/
[13:35:25 DBG] Connect: guest@localhost:5672/
[13:35:25 DBG] Connected: guest@localhost:5672/ (address: amqp://localhost:5672, local: 54655)
[13:35:25 DBG] Endpoint Ready: rabbitmq://localhost/5421002_MassTransitRepro_bus_cnpyyyyxieyy1jhibdp11xhwnb?temporary=true
[13:35:25 DBG] Declare queue: name: test, durable, consumer-count: 0 message-count: 1
[13:35:25 DBG] Declare exchange: name: test, type: fanout, durable
[13:35:25 DBG] Declare exchange: name: MassTransitRepro:SampleEvent, type: fanout, durable
[13:35:25 DBG] Bind queue: source: test, destination: test
[13:35:25 DBG] Bind exchange: source: MassTransitRepro:SampleEvent, destination: test
[13:35:25 DBG] Consumer Ok: rabbitmq://localhost/test - amq.ctag-XoFTWvpEaAMo6QHPRTcULg
[13:35:25 DBG] Endpoint Ready: rabbitmq://localhost/test
[13:35:25 INF] Bus started: rabbitmq://localhost/
start consume and wait
start stop
[13:35:30 DBG] Stopping bus: rabbitmq://localhost/
[13:35:30 DBG] Endpoint Stopping: rabbitmq://localhost/test
[13:35:30 DBG] Stopping receive transport: rabbitmq://localhost/test
[13:35:30 DBG] Consumer Stopping: rabbitmq://localhost/test (Stop Receive Transport)
[13:35:30 DBG] Consumer Cancel Ok: rabbitmq://localhost/test - amq.ctag-XoFTWvpEaAMo6QHPRTcULg
end waiting
[13:35:35 WRN] R-RETRY rabbitmq://localhost/test 181c0000-6393-3630-36a4-08daf4e7c6da MassTransit.RetryPolicies.RetryConsumeContext
System.ApplicationException: Some exception caused by an external service. Timeout, 503 etc
   at MassTransitRepro.Consumer.Consume(ConsumeContext`1 context) in C:\source\MassTransitRepro\Program.cs:line 64
   at MassTransit.Consumer.DefaultConstructorConsumerFactory`1.Send[T](ConsumeContext`1 context, IPipe`1 next) in /_/src/MassTransit/Consumers/Consumer/DefaultConstructorConsumerFactory.cs:line 20
   at MassTransit.Consumer.DefaultConstructorConsumerFactory`1.Send[T](ConsumeContext`1 context, IPipe`1 next) in /_/src/MassTransit/Consumers/Consumer/DefaultConstructorConsumerFactory.cs:line 30
   at MassTransit.Middleware.ConsumerMessageFilter`2.MassTransit.IFilter<MassTransit.ConsumeContext<TMessage>>.Send(ConsumeContext`1 context, IPipe`1 next) in /_/src/MassTransit/Middleware/ConsumerMessageFilter.cs:line 46
   at MassTransit.Middleware.ConsumerMessageFilter`2.MassTransit.IFilter<MassTransit.ConsumeContext<TMessage>>.Send(ConsumeContext`1 context, IPipe`1 next) in /_/src/MassTransit/Middleware/ConsumerMessageFilter.cs:line 67
   at MassTransit.Middleware.RetryFilter`1.MassTransit.IFilter<TContext>.Send(TContext context, IPipe`1 next) in /_/src/MassTransit/Middleware/RetryFilter.cs:line 47
[13:35:36 DBG] SKIP rabbitmq://localhost/test null
[13:35:36 DBG] Declare queue: name: test_skipped, durable, consumer-count: 0 message-count: 0
[13:35:36 DBG] Declare exchange: name: test_skipped, type: fanout, durable
[13:35:36 DBG] Bind queue: source: test_skipped, destination: test_skipped
[13:35:36 DBG] Endpoint Completed: rabbitmq://localhost/test
[13:35:36 DBG] Consumer Completed: rabbitmq://localhost/test: 1 received, 1 concurrent, amq.ctag-XoFTWvpEaAMo6QHPRTcULg
[13:35:36 DBG] Endpoint Stopping: rabbitmq://localhost/5421002_MassTransitRepro_bus_cnpyyyyxieyy1jhibdp11xhwnb?temporary=true
[13:35:36 DBG] Stopping receive transport: rabbitmq://localhost/5421002_MassTransitRepro_bus_cnpyyyyxieyy1jhibdp11xhwnb?temporary=true
[13:35:36 DBG] Endpoint Completed: rabbitmq://localhost/5421002_MassTransitRepro_bus_cnpyyyyxieyy1jhibdp11xhwnb?temporary=true
[13:35:36 DBG] Disconnect: guest@localhost:5672/
[13:35:36 DBG] Disconnected: guest@localhost:5672/
[13:35:36 INF] Bus stopped: rabbitmq://localhost/
end stop
```
