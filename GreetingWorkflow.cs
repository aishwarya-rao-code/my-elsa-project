using Elsa.Workflows;
using Elsa.Workflows.Activities;
using Elsa.Workflows.Models;
using Elsa.Scheduling.Activities;

namespace ElsaServer.Workflows;

public class GreetingWorkflow : WorkflowBase
{
    protected override void Build(IWorkflowBuilder builder)
    {
        builder.Root = new Sequence
        {
            Activities =
            {
                new Cron
                {
                    CronExpression = new Input<string>("0 9, * * *") // 9:00 AM and 6:00 PM daily
                },
                new WriteLine("Hello! This workflow runs at 9 AM and 6 PM daily.")
            }
        };
    }
}
