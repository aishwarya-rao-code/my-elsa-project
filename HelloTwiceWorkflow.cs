using Elsa.Workflows;
using Elsa.Workflows.Activities;

public class HelloTwiceWorkflow : WorkflowBase
{
    protected override void Build(IWorkflowBuilder builder)
    {
        builder.Root = new Sequence
        {
            Activities =
            {
                new WriteLine("Hello! (1st time)"),
                new WriteLine("Hello! (2nd time)")
            }
        };
    }
}
