using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System.Collections.Generic;

namespace Webhooks.RegisteredEvents
{
    public class OnLocalChatMessage : IScript
    {
        [Target(GameSourceEvent.PlayerLocalChatMessage, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player, string message)
        {
            List<Embed> commandsEmb = new List<Embed>();
            List<Embed> localEmb = new List<Embed>();

            foreach (var em in Core.Instance.Settings.Chat.CommandsEmbed)
            {
                commandsEmb.Add(new Embed { Title = string.Format(em.Title, message, player.username), Description = string.Format(em.Description, message, player.username) });
            }
            foreach (var em in Core.Instance.Settings.Chat.LocalEmbed)
            {
                localEmb.Add(new Embed { Title = string.Format(em.Title, message, player.username), Description = string.Format(em.Description, message, player.username) });
            }
            if (message.StartsWith("/"))
            {
                Core.Instance.commandWebhook.Send(string.Format(Core.Instance.Settings.Chat.CommandsLogFormat, message, player.username), player.username,embeds: Core.Instance.Settings.Chat.CommandsUseEmbed?commandsEmb:null);
                return;
            }
            Core.Instance.localWebhook.Send(string.Format(Core.Instance.Settings.Chat.LocalFormat, message, player.username), player.username,embeds: Core.Instance.Settings.Chat.LocalUseEmbed?localEmb:null);
        }
    }
}
