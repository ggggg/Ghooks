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
            if (!player.isHuman || player.svPlayer.godMode || player.svPlayer.InvalidCrime(crimeIndex)) return;
            var crime = player.manager.GetCrime(crimeIndex);
            Core.Instance.SendDefaultEvent(DefaultEvents.OnCrime, player.username, victim ? victim.username : "No victim", crime.crimeName);
        }
    }
}