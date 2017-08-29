using Events.Models.EventHandlers;
using SlackITSupport.SlackLibrary.Events;
using SlackITSupport.SlackLibrary.Post;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Events.Controllers
{
    public class EventController : ApiController
    {
        public async Task<string> PostAsync()
        {
            string content = await Request.Content.ReadAsStringAsync();
            await EventHandler.HandleEvent(BuildHandlerList(), GetEvent.Get(content));
            return content;
        }

        private List<EventHandler> BuildHandlerList()
        {
            return new List<EventHandler>
            {
                { new MessageHandler(SlackITSupport.SlackLibrary.SlackConstants.Events.MESSAGE_SENT)}
            };
        }
    }
}
