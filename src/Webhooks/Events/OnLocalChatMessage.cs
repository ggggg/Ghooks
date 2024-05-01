using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace Webhooks.RegisteredEvents
{
    public class OnLocalChatMessage : IScript
    {
        [Target(GameSourceEvent.PlayerChatLocal, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player, string message)
        {
            Core.Instance.SendDefaultEvent(message.StartsWith("/") ? DefaultEvents.OnCommand : DefaultEvents.OnLocal, player.username, message);
        }
    }
}
