using BPCoreLib.Interfaces;
using BPCoreLib.Util;
using BrokeProtocol.API;
using BrokeProtocol.Entities;
using BrokeProtocol.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Webhooks.Configuration.Models;
using Webhooks.Configuration.Models.SettingsModel;

namespace Webhooks
{
    public class Core : Plugin
    {
        public static Core Instance { get; internal set; }

        public static string Version { get; } = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

        public ILogger Logger { get; } = new Logger();

        public SvManager SvManager { get; set; }

        public Webhook LocalWebhook { get; set; }
        public Webhook GlobalWebhook { get; set; }
        public Webhook JoinWebhook { get; set; }
        public Webhook StartWebhook { get; set; }
        public Webhook CommandWebhook { get; set; }
        public Webhook DeathWebhook { get; set; }
        public Webhook CrimeWebhook { get; set; }

        public Paths Paths { get; } = new Paths();

        public IReader<Settings> SettingsReader { get; } = new Reader<Settings>();

        public Settings Settings => SettingsReader.Parsed;
        public IReader<List<CustomEvent>> CustomEventReader { get; } = new Reader<List<CustomEvent>>();

        public Core()
        {
            Instance = this;
            Info = new PluginInfo("GHooks", "GHooks")
            {
                Description = "A bp to discord webhooks plugin. \nBy: The-g, xiluisx."
            };
            OnReloadRequestAsync();
            LocalWebhook = new Webhook(Settings.Chat.LocalChat);
            GlobalWebhook = new Webhook(Settings.Chat.GlobalChat);
            JoinWebhook = new Webhook(Settings.Server.PlayerJoinLeave);
            StartWebhook = new Webhook(Settings.Server.ServerStart);
            CommandWebhook = new Webhook(Settings.Chat.CommandsLog);
            DeathWebhook = new Webhook(Settings.General.DeathLog);
        }
        public async void OnReloadRequestAsync()
        {
            SetConfigurationFilePaths();
            await FileChecker.CheckFiles();
            ReadConfigurationFiles();
            RegisterCustomCommands();
        }
        public void RegisterCustomCommands()
        {
            foreach (var customEvent in CustomEventReader.Parsed)
            {
                Logger.LogInfo($"[CC] Registering custom event(s) for webhook {string.Join(", ", customEvent.Event)} by name '{customEvent.Event}'..");
                EventsHandler.Add(customEvent.Event, new Action<ShPlayer, string>((player, eventName) =>
                {
                    if (player.svPlayer.HasPermission("webhook." + eventName))
                    {
                        return;
                    }
                    Logger.LogInfo($"Custom event {customEvent.Event} was triggered.");
                    Webhook web = new Webhook(customEvent.webhookLink);
                    web.Send(string.Format(customEvent.Response, player.username), string.Format(customEvent.SenderName, player.username));
                }));
            }
        }
        public void SetConfigurationFilePaths()
        {
            SettingsReader.Path = Paths.SettingsFile;
            CustomEventReader.Path = Paths.EventsFile;
        }

        public void ReadConfigurationFiles()
        {
            SettingsReader.ReadAndParse();
            CustomEventReader.ReadAndParse();
        }
    }
}
