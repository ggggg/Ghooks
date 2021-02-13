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
                Core.Instance.CommandWebhook.Send(string.Format(Core.Instance.Settings.Chat.CommandsLogFormat, message, player.username), player.username,
                    embeds: Core.Instance.Settings.Chat.CommandsUseEmbed ? EmbedCrafter.CreateAllEmbeds(Core.Instance.Settings.Chat.CommandsEmbed,player,message) : null);
                return;
            }
            Core.Instance.LocalWebhook.Send(string.Format(Core.Instance.Settings.Chat.LocalFormat, message, player.username), player.username,
                embeds: Core.Instance.Settings.Chat.LocalUseEmbed ? EmbedCrafter.CreateAllEmbeds(Core.Instance.Settings.Chat.LocalEmbed, player,message) : null);
        }
    }
}
