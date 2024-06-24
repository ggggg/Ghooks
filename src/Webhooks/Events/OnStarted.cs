using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Managers;

namespace Webhooks.RegisteredEvents
{
    public class OnStarted : IScript
    {
        [Target(GameSourceEvent.ManagerStart, ExecutionMode.Event)]
        public void OnEvent()
        {
            Core.Instance.SendDefaultEvent(DefaultEvents.OnStarted);
        }
    }
}
