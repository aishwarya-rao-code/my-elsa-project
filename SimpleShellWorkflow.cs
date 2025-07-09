using Elsa.Workflows;
using ElsaServer.Activities;

namespace ElsaServer.Workflows;

public class SimpleShellWorkflow : IWorkflow
{
    public ValueTask BuildAsync(IWorkflowBuilder builder, CancellationToken cancellationToken)
    {
        builder.Root = new ExecuteShellCommandActivity
        {
            ScriptFile = new Elsa.Workflows.Models.Input<string>(
                @"C:\Users\aishu\Downloads\Elsa_3.5\ElsaServerAndStudio\Powershell scripts\testScript.ps1")
        };

        return ValueTask.CompletedTask;
    }
}
