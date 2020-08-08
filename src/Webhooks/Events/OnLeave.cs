using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace Webhooks.RegisteredEvents
{
    public class OnLeave : IScript
    {
        [Target(GameSourceEvent.PlayerDestroy, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player)
        {
            Core.Instance.joinWebhook.Send(string.Format(Core.Instance.Settings.Server.PlayerLeaveFormat, player.username), player.username);
        }
    }
}
