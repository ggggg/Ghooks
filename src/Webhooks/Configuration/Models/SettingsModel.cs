using System.Collections.Generic;

namespace Webhooks.Configuration.Models.SettingsModel
{
    public class Settings
    {
        public General General { get; set; }

        public Chat Chat { get; set; }
        public Server Server { get; set; }
    }

    public class ReportOptions
    {
    }

    public class FunctionUI
    {
    }
    public class Server
    {
        public string PlayerJoinLeave { get; set; }
        public string PlayerJoinFormat { get; set; }
        public bool PlayerJoinUseEmbed { get; set; }
        public List<Embed> PlayerJoinEmbed { get; set; }
        public string PlayerLeaveFormat { get; set; }
        public bool PlayerLeaveUseEmbed { get; set; }
        public List<Embed> PlayerLeaveEmbed { get; set; }
        public string ServerStart { get; set; }
        public string ServerStartMessage { get; set; }
        public bool ServerStartUseEmbed { get; set; }
        public List<Embed> ServerStartEmbed { get; set; }
    }
    public class Chat
    {
        public string GlobalChat { get; set; }

        public string GlobalFormat { get; set; }

        public bool GlobalUseEmbed { get; set; }

        public List<Embed> GlobalEmbed { get; set; }

        public string LocalChat { get; set; }

        public string LocalFormat { get; set; }

        public bool LocalUseEmbed { get; set; }

        public List<Embed> LocalEmbed { get; set; }

        public string CommandsLog { get; set; }

        public string CommandsLogFormat { get; set; }

        public bool CommandsUseEmbed { get; set; }

        public List<Embed> CommandsEmbed { get; set; }
    }
    public class General
    {
        public string Version { get; set; }
    }
}