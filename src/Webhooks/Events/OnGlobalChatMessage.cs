using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace Webhooks.RegisteredEvents
{
    public class OnGlobalChatMessage : IScript
    {
        [Target(GameSourceEvent.PlayerGlobalChatMessage, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player, string message)
        {
            if (message.StartsWith("/"))
            {
                Core.Instance.commandWebhook.Send(string.Format(Core.Instance.Settings.Chat.CommandsLogFormat, message, player.username), player.username);
            }
           Core.Instance.globalWebhook.Send(string.Format(Core.Instance.Settings.Chat.GlobalFormat , message, player.username), player.username);
        }
    }
}
