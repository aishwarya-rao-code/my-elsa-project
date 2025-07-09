using Elsa.Workflows;
using Elsa.Workflows.Activities;
using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Encodings.Web;
using Elsa.Http;

namespace ElsaServer.Workflows
{
    public class SendSmsWorkflow : WorkflowBase
    {
        protected override void Build(IWorkflowBuilder builder)
        {
            var smsResponse = builder.WithVariable<string>("SmsResponse");

            var now = DateTime.UtcNow;
            var rounded = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
            var formattedDate = rounded.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) + " UTC";

            var payload = new
            {
                senderid = "Delphi-Agent",
                type = "text",
                subject = "Ticket Assignment",
                message = "You have been assigned ticket 1",
                application = "TestApp",
                datecreated = formattedDate,
                priority = 1,
                sendas = "no_reply@tenexsolutions.com",
                sendto = "+15189618416",
                msgexpireduration = "24h"
            };

            var jsonPayload = JsonSerializer.Serialize(payload, new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = false
            });

            builder.Root = new SendHttpRequest
            {
                Url = new(new Uri("http://10.0.18.14/message")),
                Method = new("POST"),
                Content = new(jsonPayload),
                ContentType = new("application/json"),
                ParsedContent = new(smsResponse)
            };
        }
    }
}
