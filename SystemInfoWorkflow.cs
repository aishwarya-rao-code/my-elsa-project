using Elsa.Workflows;
using Elsa.Workflows.Activities;
using Elsa.Scheduling.Activities;
using ElsaServer.Activities;
using Elsa.Workflows.Models;

namespace ElsaServer.Workflows;

public class SystemInfoWorkflow : WorkflowBase
{
    protected override void Build(IWorkflowBuilder builder)
    {
        builder.Root = new Sequence
        {
            Activities =
            {
                new Cron
                {
                    CronExpression = new("* * * * *") // Every 1 minute
                },
                new ExecuteShellCommandActivity
                {
                    ScriptFile = new Input<string>(@"C:\Users\aishu\Downloads\Elsa_3.5\ElsaServerAndStudio\ElsaServer\Shell_Scripts\SystemInfoWorkflow.ps1")
        }
            }
        };
    }
}
