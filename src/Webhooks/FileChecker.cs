using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Webhooks
{
    public static class FileChecker
    {
        public static Dictionary<string, string> RequiredDirectories { get; }= new Dictionary<string, string>
        {
            {"GHooks", Paths.Folder}
        };

        public static Dictionary<string, string> RequiredFiles { get; } = new Dictionary<string, string>
        {
            {"settings.json", Core.Instance.Paths.SettingsFile},
            {"customEvents.json", Core.Instance.Paths.EventsFile}
        };

        public static HttpClient Client { get; } = new HttpClient();

        public static async Task CheckFiles()
        {
            foreach (var directory in RequiredDirectories)
            {
                if (Directory.Exists(directory.Value))
                {
                    continue;
                }
                Core.Instance.Logger.LogWarning($"{directory.Key} directory was not found; creating");
                Directory.CreateDirectory(directory.Value);
                Core.Instance.Logger.LogInfo($"{directory.Key} directory was created.");
            }

            foreach (var file in RequiredFiles)
            {
                if (File.Exists(file.Value))
                {
                    continue;
                }
                Core.Instance.Logger.LogError($"{file.Key} was not found; downloading.");
                var content = await Client.GetStringAsync($"https://raw.githubusercontent.com/ggggg/file-download/master/{file.Key}");
                File.WriteAllText(file.Value, content);
                Core.Instance.Logger.LogInfo($"{file.Key} was downloaded.");
            }
        }
    }
}
