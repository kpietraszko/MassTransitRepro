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
# With UseRetry
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

# With UseMessageRetry
```
[15:03:21 DBG] Starting bus: rabbitmq://localhost/
[15:03:21 DBG] Connect: guest@localhost:5672/
[15:03:21 DBG] Connected: guest@localhost:5672/ (address: amqp://localhost:5672, local: 55809)
[15:03:21 DBG] Endpoint Ready: rabbitmq://localhost/5421002_MassTransitRepro_bus_6nqoyyyxieyy1kprbdp11167y9?temporary=true
[15:03:21 DBG] Declare queue: name: test, durable, consumer-count: 0 message-count: 1
[15:03:21 DBG] Declare exchange: name: test, type: fanout, durable
[15:03:21 DBG] Declare exchange: name: MassTransitRepro:SampleEvent, type: fanout, durable
[15:03:21 DBG] Bind queue: source: test, destination: test
[15:03:21 DBG] Bind exchange: source: MassTransitRepro:SampleEvent, destination: test
[15:03:21 DBG] Consumer Ok: rabbitmq://localhost/test - amq.ctag-B_YitJaPFLHQG_iWjo2XGg
[15:03:21 DBG] Endpoint Ready: rabbitmq://localhost/test
[15:03:21 INF] Bus started: rabbitmq://localhost/
start consume and wait
start stop
[15:03:26 DBG] Stopping bus: rabbitmq://localhost/
[15:03:27 DBG] Endpoint Stopping: rabbitmq://localhost/test
[15:03:27 DBG] Stopping receive transport: rabbitmq://localhost/test
[15:03:27 DBG] Consumer Stopping: rabbitmq://localhost/test (Stop Receive Transport)
[15:03:27 DBG] Consumer Cancel Ok: rabbitmq://localhost/test - amq.ctag-B_YitJaPFLHQG_iWjo2XGg
end waiting
[15:03:32 WRN] R-RETRY rabbitmq://localhost/test 181c0000-6393-3630-36a4-08daf4e7c6da MassTransit.RetryPolicies.RetryConsumeContext<MassTransitRepro.SampleEvent>
System.ApplicationException: Some exception caused by an external service. Timeout, 503 etc
   at MassTransitRepro.Consumer.Consume(ConsumeContext`1 context) in C:\source\MassTransitRepro\Program.cs:line 64
   at MassTransit.Consumer.DefaultConstructorConsumerFactory`1.Send[T](ConsumeContext`1 context, IPipe`1 next) in /_/src/MassTransit/Consumers/Consumer/DefaultConstructorConsumerFactory.cs:line 20
   at MassTransit.Consumer.DefaultConstructorConsumerFactory`1.Send[T](ConsumeContext`1 context, IPipe`1 next) in /_/src/MassTransit/Consumers/Consumer/DefaultConstructorConsumerFactory.cs:line 30
   at MassTransit.Middleware.ConsumerMessageFilter`2.MassTransit.IFilter<MassTransit.ConsumeContext<TMessage>>.Send(ConsumeContext`1 context, IPipe`1 next) in /_/src/MassTransit/Middleware/ConsumerMessageFilter.cs:line 46
   at MassTransit.Middleware.ConsumerMessageFilter`2.MassTransit.IFilter<MassTransit.ConsumeContext<TMessage>>.Send(ConsumeContext`1 context, IPipe`1 next) in /_/src/MassTransit/Middleware/ConsumerMessageFilter.cs:line 67
   at MassTransit.Middleware.RetryFilter`1.MassTransit.IFilter<TContext>.Send(TContext context, IPipe`1 next) in /_/src/MassTransit/Middleware/RetryFilter.cs:line 47
start consume and wait
end waiting
start consume and wait
end waiting
start consume and wait
end waiting
start consume and wait
end waiting
start consume and wait
end waiting
[15:04:22 DBG] Declare exchange: name: MassTransit:Fault--MassTransitRepro:SampleEvent--, type: fanout, durable
[15:04:22 DBG] Declare exchange: name: MassTransit:Fault, type: fanout, durable
[15:04:22 DBG] Bind exchange: source: MassTransit:Fault--MassTransitRepro:SampleEvent--, destination: MassTransit:Fault
[15:04:22 DBG] SEND rabbitmq://localhost/MassTransit:Fault--MassTransitRepro:SampleEvent-- f09d0000-0faa-0009-d106-08db294c01c8 MassTransit.Fault<MassTransitRepro.SampleEvent>
[15:04:22 ERR] R-FAULT rabbitmq://localhost/test 181c0000-6393-3630-36a4-08daf4e7c6da MassTransitRepro.SampleEvent MassTransitRepro.Consumer(00:00:10.0737743)
System.ApplicationException: Some exception caused by an external service. Timeout, 503 etc
   at MassTransitRepro.Consumer.Consume(ConsumeContext`1 context) in C:\source\MassTransitRepro\Program.cs:line 64
   at MassTransit.Consumer.DefaultConstructorConsumerFactory`1.Send[T](ConsumeContext`1 context, IPipe`1 next) in /_/src/MassTransit/Consumers/Consumer/DefaultConstructorConsumerFactory.cs:line 20
   at MassTransit.Consumer.DefaultConstructorConsumerFactory`1.Send[T](ConsumeContext`1 context, IPipe`1 next) in /_/src/MassTransit/Consumers/Consumer/DefaultConstructorConsumerFactory.cs:line 30
   at MassTransit.Middleware.ConsumerMessageFilter`2.MassTransit.IFilter<MassTransit.ConsumeContext<TMessage>>.Send(ConsumeContext`1 context, IPipe`1 next) in /_/src/MassTransit/Middleware/ConsumerMessageFilter.cs:line 46
   at MassTransit.Middleware.ConsumerMessageFilter`2.MassTransit.IFilter<MassTransit.ConsumeContext<TMessage>>.Send(ConsumeContext`1 context, IPipe`1 next) in /_/src/MassTransit/Middleware/ConsumerMessageFilter.cs:line 67
   at MassTransit.Middleware.RetryFilter`1.Attempt(TContext context, RetryContext`1 retryContext, IPipe`1 next) in /_/src/MassTransit/Middleware/RetryFilter.cs:line 158
[15:04:23 DBG] Declare queue: name: test_error, durable, consumer-count: 0 message-count: 0
[15:04:23 DBG] Declare exchange: name: test_error, type: fanout, durable
[15:04:23 DBG] Bind queue: source: test_error, destination: test_error
[15:04:23 DBG] Endpoint Completed: rabbitmq://localhost/test
[15:04:23 DBG] Stopping send transport: MassTransit:Fault--MassTransitRepro:SampleEvent--
[15:04:23 DBG] Consumer Completed: rabbitmq://localhost/test: 1 received, 1 concurrent, amq.ctag-B_YitJaPFLHQG_iWjo2XGg
[15:04:23 DBG] Endpoint Stopping: rabbitmq://localhost/5421002_MassTransitRepro_bus_6nqoyyyxieyy1kprbdp11167y9?temporary=true
[15:04:23 DBG] Stopping receive transport: rabbitmq://localhost/5421002_MassTransitRepro_bus_6nqoyyyxieyy1kprbdp11167y9?temporary=true
[15:04:23 DBG] Endpoint Completed: rabbitmq://localhost/5421002_MassTransitRepro_bus_6nqoyyyxieyy1kprbdp11167y9?temporary=true
[15:04:23 DBG] Disconnect: guest@localhost:5672/
[15:04:23 DBG] Disconnected: guest@localhost:5672/
[15:04:23 INF] Bus stopped: rabbitmq://localhost/
end stop
```