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

        public Webhook localWebhook { get; set; }
        public Webhook globalWebhook { get; set; }
        public Webhook joinWebhook { get; set; }
        public Webhook startWebhook { get; set; }
        public Webhook commandWebhook { get; set; }

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
            localWebhook = new Webhook(Settings.Chat.LocalChat);
            globalWebhook = new Webhook(Settings.Chat.GlobalChat);
            joinWebhook = new Webhook(Settings.Server.PlayerJoinLeave);
            startWebhook = new Webhook(Settings.Server.ServerStart);
            commandWebhook = new Webhook(Settings.Chat.CommandsLog);
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
                    Logger.LogInfo($"cutstom event {customEvent.Event} was tiriggered");
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
