using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace Webhooks.Events
{
    public class OnDeath : IScript
    {
        [Target(GameSourceEvent.PlayerDeath, ExecutionMode.Event)]
        public void OnEvent(ShPlayer player, ShPlayer attacker)
        {
            if(!attacker || !attacker.isHuman || attacker==player)
            {
                return;
            }
            Core.Instance.SendDefaultEvent(DefaultEvents.OnDeath, player.username, attacker.username);
        }
    }
}
