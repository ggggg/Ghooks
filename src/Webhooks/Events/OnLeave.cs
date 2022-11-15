using BrokeProtocol.API;
using BrokeProtocol.Entities;

namespace Webhooks.RegisteredEvents
{
    public class OnLeave : PlayerEvents
    {
        [Execution(ExecutionMode.Event)]
        public override bool Destroy(ShEntity entity)
        {
            Core.Instance.SendDefaultEvent(DefaultEvents.OnLeave, entity.Player.username);
            return true;
        }
    }
}
