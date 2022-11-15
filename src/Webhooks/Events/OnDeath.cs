using BrokeProtocol.API;
using BrokeProtocol.Entities;
using UnityEngine;

namespace Webhooks.Events
{
    public class OnDeath : PlayerEvents
    {
        [Execution(ExecutionMode.Event)]
        public override bool Death(ShDestroyable destroyable, ShPlayer attacker)
        {
            if(!attacker || !attacker.isHuman || attacker.ID== destroyable.ID)
            {
                return true;
            }
            Core.Instance.SendDefaultEvent(DefaultEvents.OnDeath, destroyable.Player.username, attacker.username);
            return true;
        }
    }
}
