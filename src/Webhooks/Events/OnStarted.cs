using BrokeProtocol.API;
using BrokeProtocol.Managers;

namespace Webhooks.RegisteredEvents
{
    public class OnStarted : IScript
    {
        [Target(GameSourceEvent.ManagerStart, ExecutionMode.Event)]
        public void OnEvent(SvManager svManager)
        {
            Core.Instance.SvManager = svManager;
            Core.Instance.SendDefaultEvent(DefaultEvents.OnStarted);
        }
    }
}
