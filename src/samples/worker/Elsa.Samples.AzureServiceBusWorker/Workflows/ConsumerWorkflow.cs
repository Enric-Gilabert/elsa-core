﻿using Elsa.Activities.AzureServiceBus;
using Elsa.Activities.Console;
using Elsa.Builders;
using Elsa.Samples.AzureServiceBusWorker.Messages;

namespace Elsa.Samples.AzureServiceBusWorker.Workflows
{
    public class ConsumerWorkflow : IWorkflow
    {
        public void Build(IWorkflowBuilder workflow)
        {
            workflow
                .MessageReceived<Greeting>("greetings")
                .WriteLine(context =>
                {
                    var test = context.WorkflowExecutionContext.Input;
                    var greeting = context.GetInput<Greeting>();
                    return $"Received a greeting from {greeting.From}, saying \"{greeting.Message}\" to {greeting.To}!";
                });
        }
    }
}