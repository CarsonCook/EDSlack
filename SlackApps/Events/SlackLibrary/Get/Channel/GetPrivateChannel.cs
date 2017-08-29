using System.Collections.Generic;
using SlackITSupport.SlackLibrary.JsonParsing.ChannelJson;
using SlackITSupport.SlackLibrary.SlackConstants;

namespace SlackITSupport.SlackLibrary.Get.Channel
{
    public class GetPrivateChannel : SlackApiGet<JsonGetChannel>
    {
        private string _channelId;

        public GetPrivateChannel(string token, string channelId) : base(token)
        {
            _channelId = channelId;
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.CHANNEL, _channelId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_CHANNEL_PRIVATE;
        }
    }
}