using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System.Collections.Specialized;
using System.Net;

namespace Webhooks.RegisteredEvents
{
    public class OnLogin : IScript
    {
        [Target(GameSourceEvent.PlayerInitialize, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player)
        {
            Core.Instance.joinWebhook.Send(string.Format(Core.Instance.Settings.Server.PlayerJoinFormat, player.username), player.username);
        }
    }

}

