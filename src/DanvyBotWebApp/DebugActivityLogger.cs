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
    public class DebugActivityLogger : IActivityLogger
    {
        public async Task LogAsync(IActivity activity)
        {
            Debug.WriteLine($"From:{activity.From.Id} - To:{activity.Recipient.Id} - Message:{(activity as IMessageActivity)?.Text}");
            //System.Diagnostics.Trace.TraceInformation("Information");
            //System.Diagnostics.Trace.TraceWarning("Warning");
            //System.Diagnostics.Trace.TraceError("Error");
        }
    }
}