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
            Core.Instance.SendDefaultEvent(DefaultEvents.OnLogin, player.username);
        }
    }

}
