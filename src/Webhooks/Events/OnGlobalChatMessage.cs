using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace Webhooks.RegisteredEvents
{
    public class OnGlobalChatMessage : PlayerEvents
    {
        [Execution(ExecutionMode.Event)]
        public override bool GlobalChatMessage(ShPlayer player, string message)
        {
            Core.Instance.SendDefaultEvent(message.StartsWith("/") ? DefaultEvents.OnCommand : DefaultEvents.OnChat, player.username, message);
            return true;
        }
    }
}
