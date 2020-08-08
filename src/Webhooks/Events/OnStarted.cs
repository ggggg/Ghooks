using BrokeProtocol.API;
using BrokeProtocol.Managers;

namespace Webhooks.RegisteredEvents
{
    public class OnStarted : IScript
    {
        [Target(GameSourceEvent.ManagerStart, ExecutionMode.Event)]
        public void OnEvent(SvManager svManager)
        {
            Core.Instance.joinWebhook.Send(string.Format(Core.Instance.Settings.Server.ServerStartMessage));

        }
    }
}
