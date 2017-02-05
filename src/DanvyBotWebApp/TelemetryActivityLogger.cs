using Microsoft.Bot.Builder.History;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DanvyBotWebApp
{
    public class TelemetryActivityLogger : IActivityLogger
    {
        public async Task LogAsync(IActivity activity)
        {
            Trace.TraceInformation("Message from {0} to {1}", activity.From.Id, activity.Recipient.Id);
        }
    }
}