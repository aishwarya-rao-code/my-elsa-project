using Elsa.Workflows;
using ElsaServer.Activities;
using System.Threading;
using System.Threading.Tasks;
using Elsa.Workflows.Models;

namespace ElsaServer.Workflows;

public class CheckDisk : IWorkflow
{
    public ValueTask BuildAsync(IWorkflowBuilder builder, CancellationToken cancellationToken)
    {
        var runScript = new ExecuteShellCommandActivity
        {
            ScriptFile = new Input<string>(@"C:\Users\aishu\Downloads\Elsa_3.5\ElsaServerAndStudio\ElsaServer\Shell_Scripts\CheckDisk.ps1")
        };

        builder.Root = runScript;
        return ValueTask.CompletedTask;
    }
}
