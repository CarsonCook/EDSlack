using System.Threading.Tasks;
using SlackITSupport.SlackLibrary.Events;
using SlackITSupport.SlackLibrary.JsonParsing.EventJson;
using SlackITSupport.SlackLibrary;
using SlackITSupport.SlackLibrary.Post;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace Events.Models.EventHandlers
{
    public class MessageHandler : EventHandler
    {
        public MessageHandler(string eventToHandle) : base(eventToHandle)
        {
        }

        protected override async Task<bool> Handle(JsonEventDetails eventDetails)
        {
            return await new ReactionPost(Constants.BOT_TOKEN, GetUsersReaction(eventDetails.User), eventDetails.Channel, eventDetails.Ts, ItemType.MESSAGE).Post();
        }

        private string GetUsersReaction(string username)
        {
            switch (username)
            {
                case "U49UAFEB0":
                    return "aidan";
                case "U46HE20S1":
                    return "besh";
                case "U462CE82C":
                    return "carson";
                case "U45FR8FUZ":
                    return "cliff";
                case "U4638KL3W":
                    return "cody";
                case "U49SLC65V":
                    return "emily";
                case "U49SALTCN":
                    return "hannah";
                case "U45HB4S82":
                    return "jill";
                case "U45LM6U5T":
                    return "jj";
                case "U47DY4MC6":
                    return "jordan";
                case "U462405EY":
                    return "leah";
                case "U462JPV52":
                    return "monica";
                case "U45FDJK0T":
                    return "nat";
                case "U46EXBUHL":
                    return "nick";
                case "U44TW4M4Y":
                    return "oliver";
                case "U4BLSHZ5Y":
                    return "sarah";

            }
            return "";
        }
    }
}