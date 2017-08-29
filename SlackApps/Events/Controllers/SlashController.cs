using Newtonsoft.Json;
using SlackITSupport.SlackLibrary.Post;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Events.Controllers
{
    public class SlashController : ApiController
    {
        public async Task<Dictionary<string,dynamic>> PostAsync()
        {
            var a = await new MessagePost(Models.Constants.BOT_TOKEN, "G6UU1J6SX", "hi").Post();
            var b = await new ReactionPost(Models.Constants.BOT_TOKEN, "carson", "G6UU1J6SX", "1504010868.000110", ItemType.MESSAGE).Post();
            return new SlashMessagePost("MESSAGE: "+JsonConvert.SerializeObject(a)+"\n\n\n REACTION: "+JsonConvert.SerializeObject(b)).Build();
        }
    }
}
