using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Utility;

namespace Webhooks.Events
{
    public class OnCrime : IScript
    {
        [Target(GameSourceEvent.PlayerCrime, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player, byte crimeIndex, ShPlayer victim)
        {
            if (player.svPlayer.godMode || player.svPlayer.InvalidCrime(crimeIndex)) return;
            Crime crime = player.manager.GetCrime(crimeIndex);
            Core.Instance.crimeWebhook.Send(string.Format(Core.Instance.Settings.General.CrimeLogFormat, player.username, victim ? victim.username: "No victim", crime.crimeName), player.username, 
                embeds: Core.Instance.Settings.General.CrimeUseEmbed? EmbedCrafter.CreateAllEmbeds(Core.Instance.Settings.General.CrimeEmbed,player) :null);
        }
    }
}