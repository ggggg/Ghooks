using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System.Collections.Generic;

namespace Webhooks.RegisteredEvents
{
    public class OnLogin : IScript
    {
        [Target(GameSourceEvent.PlayerInitialize, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player)
        {
            List<Embed> joinEmb = new List<Embed>();

            foreach (var em in Core.Instance.Settings.Server.PlayerJoinEmbed)
            {
                joinEmb.Add(new Embed { Title = string.Format(em.Title, player.username), Description = string.Format(em.Description, player.username) });
            }
            Core.Instance.joinWebhook.Send(string.Format(Core.Instance.Settings.Server.PlayerJoinFormat, player.username), player.username, embeds: Core.Instance.Settings.Server.PlayerJoinUseEmbed? joinEmb:null);
        }
    }

}

