using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace Webhooks.RegisteredEvents
{
    public class OnLocalChatMessage : IScript
    {
        [Target(GameSourceEvent.PlayerLocalChatMessage, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player, string message)
        {
            if (message.StartsWith("/"))
            {
                Core.Instance.commandWebhook.Send(string.Format(Core.Instance.Settings.Chat.CommandsLogFormat, message, player.username), player.username);
            }
            Core.Instance.localWebhook.Send(string.Format(Core.Instance.Settings.Chat.LocalFormat, message, player.username), player.username);
        }
    }
}
