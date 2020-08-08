using System.IO;

namespace Webhooks
{
    public class Paths
    {
        public static string Folder { get; } = "GHooks";

        public string SettingsFile { get; } = Path.Combine(Folder, "settings.json");

        public string EventsFile { get; } = Path.Combine(Folder, "customEvents.json");
    }
}

