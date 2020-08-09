using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System.Collections.Generic;

namespace Webhooks.RegisteredEvents
{
    public class OnGlobalChatMessage : IScript
    {
        [Target(GameSourceEvent.PlayerGlobalChatMessage, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player, string message)
        {
            List<Embed> commandsEmb = new List<Embed>();
            List<Embed> globalEmb = new List<Embed>();

            foreach (var em in Core.Instance.Settings.Chat.CommandsEmbed)
            {
                commandsEmb.Add(new Embed { Title = string.Format(em.Title, message, player.username), Description = string.Format(em.Description, message, player.username) });
            }
            foreach(var em in Core.Instance.Settings.Chat.GlobalEmbed)
            {
                globalEmb.Add(new Embed { Title = string.Format(em.Title, message, player.username), Description = string.Format(em.Description, message, player.username) });
            }
            if (message.StartsWith("/"))
            {
                Core.Instance.commandWebhook.Send(string.Format(Core.Instance.Settings.Chat.CommandsLogFormat, message, player.username), player.username,embeds: Core.Instance.Settings.Chat.CommandsUseEmbed? commandsEmb:null);
                return;
            }
           Core.Instance.globalWebhook.Send(string.Format(Core.Instance.Settings.Chat.GlobalFormat , message, player.username), player.username,embeds: Core.Instance.Settings.Chat.GlobalUseEmbed? globalEmb :null);
            
        }
    }
}