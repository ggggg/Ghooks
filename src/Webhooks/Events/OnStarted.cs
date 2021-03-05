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
            Core.Instance.JoinWebhook.Send(string.Format(Core.Instance.Settings.Server.ServerStartMessage),
                embeds: Core.Instance.Settings.Server.ServerStartUseEmbed? Core.Instance.Settings.Server.ServerStartEmbed:null);
        }
    }
}
