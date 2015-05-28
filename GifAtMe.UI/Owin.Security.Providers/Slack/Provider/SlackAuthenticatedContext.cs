using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace GifAtMe.UI.Owin.Security.Providers.Slack.Provider
{
    public class SlackAuthenticatedContext : BaseContext
    {
        /// <summary>
        /// Initializes a <see cref="SlackAuthenticatedContext"/>
        /// </summary>
        /// <param name="context">The OWIN environment</param>
        /// <param name="user">The JSON-serialized user</param>
        /// <param name="accessToken">Slack Access token</param>
        /// <param name="expires">Seconds until expiration</param>
        public SlackAuthenticatedContext(IOwinContext context, JObject user, string accessToken, string expires, string refreshToken)
            : base(context)
        {
            User = user;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            int expiresValue;
            if (Int32.TryParse(expires, NumberStyles.Integer, CultureInfo.InvariantCulture, out expiresValue))
            {
                ExpiresIn = TimeSpan.FromSeconds(expiresValue);
            }

            UserId = TryGetValue(user, "user_id");
            UserName = TryGetValue(user, "user");
            TeamId = TryGetValue(user, "team_id");
            TeamName = TryGetValue(user, "team");
            Url = TryGetValue(user, "url");
        }

        /// <summary>
        /// Gets the JSON-serialized user
        /// </summary>
        /// <remarks>
        /// Contains the Slack user
        /// </remarks>
        public JObject User { get; private set; }

        /// <summary>
        /// Gets the Slack access token
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets Slack refresh token
        /// </summary>
        public string RefreshToken { get; private set; }

        /// <summary>
        /// Gets the Slack access token expiration time
        /// </summary>
        public TimeSpan? ExpiresIn { get; set; }

        /// <summary>
        /// Gets the Slack team ID
        /// </summary>
        public string TeamId { get; private set; }

        /// <summary>
        /// Gets the Slack team name
        /// </summary>
        public string TeamName { get; private set; }

        /// <summary>
        /// Gets the Slack user's URL
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the Slack user ID
        /// </summary>
        public string UserId { get; private set; }

        /// <summary>
        /// Gets the Slack username
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Gets the <see cref="ClaimsIdentity"/> representing the user
        /// </summary>
        public ClaimsIdentity Identity { get; set; }

        /// <summary>
        /// Gets or sets a property bag for common authentication properties
        /// </summary>
        public AuthenticationProperties Properties { get; set; }

        private static string TryGetValue(JObject user, string propertyName)
        {
            JToken value;
            return user.TryGetValue(propertyName, out value) ? value.ToString() : null;
        }
    }
}