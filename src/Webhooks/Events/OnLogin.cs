using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace Webhooks.RegisteredEvents
{
    public class OnLogin : IScript
    {
        [Target(GameSourceEvent.PlayerInitialize, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player)
        {
            if(!player.isHuman) return;
            Core.Instance.JoinWebhook.Send(string.Format(Core.Instance.Settings.Server.PlayerJoinFormat, player.username), player.username, 
                embeds: Core.Instance.Settings.Server.PlayerJoinUseEmbed? EmbedCrafter.CreateAllEmbeds(Core.Instance.Settings.Server.PlayerJoinEmbed,player) :null);
        }
    }

}
