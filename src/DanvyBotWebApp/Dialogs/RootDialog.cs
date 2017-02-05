using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DanvyBotWebApp.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            //Root Dialog initiates and now waits for the next message from the user. 
            //When that arrives we will fall into MessageReceivedAsync
            context.Wait(this.MessageReceivedAsync);
        }

        public virtual async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result; //We've got a message!
            if (message.Text.ToLower().Contains("order"))
            {
                //User said 'order'. Let's invoke the New Order Dialog and wait for it to finish
                //Then, we will call the ResumeAfterNewOrderDialog
                //await context.Forward(new NewOrderDialog(), this.ResumeAfterNewOrderDialog, message, CancellationToken.None);
            }
            //User typed something else so for simplicity we will just ignore 
            //and keep waiting for the next message
            context.Wait(this.MessageReceivedAsync);
        }


        private async Task ResumeAfterNewOrderDialog(IDialogContext context, IAwaitable<string> result)
        {
            //This will get us whatever the NewOrderDialog decided to return to us. 
            //At this point, new order dialog finished and gave us back some value to work with
            //on the root dialog
            var resultFromNewOrder = await result;

            await context.PostAsync($"New order dialog just told me this: {resultFromNewOrder}");

            //Again, we will now just wait for the next message from the user
            context.Wait(this.MessageReceivedAsync);

        }
    }
}