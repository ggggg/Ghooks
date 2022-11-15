using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace Webhooks.RegisteredEvents
{
    public class OnLocalChatMessage : PlayerEvents
    {
        [Execution(ExecutionMode.Event)]
        public override bool LocalChatMessage(ShPlayer player, string message)
        {
            Core.Instance.SendDefaultEvent(message.StartsWith("/") ? DefaultEvents.OnCommand : DefaultEvents.OnLocal, player.username, message);
            return true;
        }
    }
}
