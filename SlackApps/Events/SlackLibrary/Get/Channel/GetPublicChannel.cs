using SlackITSupport.SlackLibrary.JsonParsing.ChannelJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Threading.Tasks;

namespace SlackITSupport.SlackLibrary.Get.Channel
{
    public class GetPublicChannel : SlackApiGet<JsonGetChannel>
    {
        public GetPublicChannel(string token, string channelId) : base(token)
        {
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_CHANNEL_PUBLIC;
        }
    }
}