﻿using SlackITSupport.SlackLibrary.JsonParsing.TeamJson.TeamLogsJson;
using SlackITSupport.SlackLibrary.SlackConstants;
using System.Collections.Generic;

namespace SlackITSupport.SlackLibrary.Get.Team
{
    /**
     * This class is used to find the team logs for applications in the Slack team.
     * 
     * Requires the admin permission.
     */
    public class GetTeamIntegrationLogs : SlackApiGet<JsonIntegrationLogsResponse>
    {
        private int _count, _page;
        private string _appId, _userId, _serviceId, _changeType;

        /**
         * Method used to set the instance variables in order to avoid constructor repitition.
         * 
         * @param appId - The ID of the app to filter logs for.
         * @param changeType - The change type to filter logs for.
         * @param count - The number of items to return per page.
         * @param page - The page number of results to return.
         * @param serviceId - The ID of the service to filter logs for.
         * @param userId - The ID of the user to filter logs generated by their actions.
         */
        private void Initialize(string appId, string changeType, int count, int page, string serviceId, string userId)
        {
            _count = count;
            _page = page;
            _appId = appId;
            _userId = userId;
            _serviceId = serviceId;
            _changeType = changeType;
        }

        /**
         * Constructor for retrieving all logs.
         * 
         * @param token - The app Workspace or User token.
         */
        public GetTeamIntegrationLogs(string token) : base(token)
        {
            Initialize("", "", 100, 1, "", "");
        }

        /**
         * Constructor for filtering logs.
         */
        public GetTeamIntegrationLogs(string token, string appId, string changeType, string serviceId, string userId) : base(token)
        {
            Initialize(appId, changeType, 100, 1, serviceId, userId);
        }

        /**
         * Constructor for filtering logs and configuring the number of items retrieved.
         */
        public GetTeamIntegrationLogs(string token, string appId, string changeType, int count, int page, string serviceId, string userId) : base(token)
        {
            Initialize(appId, changeType, count, page, serviceId, userId);
        }

        protected override Dictionary<string, string> BuildRequest()
        {
            Dictionary<string, string> request = base.BuildRequest();
            request.Add(DicKeys.COUNT, _count.ToString());
            request.Add(DicKeys.PAGE, _page.ToString());
            request.Add(DicKeys.SERVICE_ID, _serviceId);
            request.Add(DicKeys.APP_ID, _appId);
            request.Add(DicKeys.CHANGE_TYPE, _changeType);
            request.Add(DicKeys.USER, _userId);
            return request;
        }

        protected override string GetApiUrl()
        {
            return ApiUrls.GET_TEAM_INTEGRATION_LOGS;
        }
    }
}