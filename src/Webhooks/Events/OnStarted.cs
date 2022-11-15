using BrokeProtocol.API;
using BrokeProtocol.Managers;

namespace Webhooks.RegisteredEvents
{
    public class OnStarted : ManagerEvents
    {
        [Execution(ExecutionMode.Event)]
        public override bool Start()
        {
            Core.Instance.SvManager = SvManager.Instance;
            Core.Instance.SendDefaultEvent(DefaultEvents.OnStarted);
            return true;
        }
    }
}
