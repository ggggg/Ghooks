using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace Webhooks.RegisteredEvents
{
    public class OnLogin : PlayerEvents
    {
        [Execution(ExecutionMode.Event)]
        public override bool Initialize(ShEntity entity)
        {
            if(!entity.Player.isHuman) return true;
            Core.Instance.SendDefaultEvent(DefaultEvents.OnLogin, entity.Player.username);
            return true;
        }
    }

}
