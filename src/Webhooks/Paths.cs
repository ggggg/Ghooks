using System.IO;

namespace Webhooks
{
    public class Paths
    {
        public static string Folder { get; } = "GHooks";

        public static string SettingsFile { get; } = Path.Combine(Folder, "settings.json");

        public static string EventsFile { get; } = Path.Combine(Folder, "customEvents.json");
    }
}

