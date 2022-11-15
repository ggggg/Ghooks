using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Utility;
using BrokeProtocol.GameSource.Types;
using BrokeProtocol.GameSource;
using UnityEngine;

namespace Webhooks.Events
{
    public class OnCrime : IScript
    {
        // This event is no longer in BP Events (i think so)

        //[Target(GameSourceEvent.PlayerCrime, ExecutionMode.Event)]
        //public void OnEvent(ShPlayer player, byte crimeIndex, ShPlayer victim)
        //{
        //    if (!player.isHuman || player.svPlayer.godMode || player.svPlayer.InvalidCrime(crimeIndex)) return;
        //    var crime = player.manager.GetCrime(crimeIndex);
        //    Core.Instance.SendDefaultEvent(DefaultEvents.OnCrime, player.username, victim ? victim.username : "No victim", crime.crimeName);
        //}
    }
}