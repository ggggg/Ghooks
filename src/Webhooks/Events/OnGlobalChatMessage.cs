using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace Webhooks.RegisteredEvents
{
    public class OnGlobalChatMessage : IScript
    {
        [Target(GameSourceEvent.PlayerGlobalChatMessage, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player, string message)
        {
            Core.Instance.SendDefaultEvent(message.StartsWith("/") ? DefaultEvents.OnCommand : DefaultEvents.OnChat, player.username, message);
        }
    }
}
