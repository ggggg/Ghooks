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
                Core.Instance.commandWebhook.Send(string.Format(Core.Instance.Settings.Chat.CommandsLogFormat, message, player.username), player.username,
                    embeds: Core.Instance.Settings.Chat.CommandsUseEmbed ? EmbedCrafter.CreateAllEmbeds(Core.Instance.Settings.Chat.CommandsEmbed,player,message) : null);
                return;
            }
            Core.Instance.globalWebhook.Send(string.Format(Core.Instance.Settings.Chat.GlobalFormat, message, player.username), player.username, 
                embeds: Core.Instance.Settings.Chat.GlobalUseEmbed ? EmbedCrafter.CreateAllEmbeds(Core.Instance.Settings.Chat.GlobalEmbed,player,message) : null);
        }
    }
}
