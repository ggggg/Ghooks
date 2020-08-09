using BrokeProtocol.API;
using BrokeProtocol.Entities;
using System.Collections.Generic;

namespace Webhooks.RegisteredEvents
{
    public class OnLeave : IScript
    {
        [Target(GameSourceEvent.PlayerDestroy, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player)
        {
            List<Embed> leaveEmb = new List<Embed>();

            foreach (var em in Core.Instance.Settings.Server.PlayerLeaveEmbed)
            {
                leaveEmb.Add(new Embed { Title = string.Format(em.Title, player.username), Description = string.Format(em.Description, player.username) });
            }
            Core.Instance.joinWebhook.Send(string.Format(Core.Instance.Settings.Server.PlayerLeaveFormat, player.username), player.username,
                embeds: Core.Instance.Settings.Server.PlayerLeaveUseEmbed? leaveEmb:null);
        }
    }
}
