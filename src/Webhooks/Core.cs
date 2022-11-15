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
using UnityEngine;

namespace Webhooks
{
    public enum DefaultEvents
    {
        OnDeath,
        OnLeave,
        OnLogin,
        OnCrime,
        OnStarted,
        OnChat,
        OnCommand,
        OnLocal
    }
    public class Core : Plugin
    {
        public static Core Instance { get; internal set; }

        public static string Version { get; } = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

        public BPCoreLib.Interfaces.ILogger Logger { get; } = new BPCoreLib.Util.Logger();

        public SvManager SvManager { get; set; }

        public Paths Paths { get; } = new Paths();

        private IReader<Dictionary<string, WebHookModel>> SettingsReader { get; } = new Reader<Dictionary<string, WebHookModel>>();

        private Dictionary<string, WebHookModel> Settings => SettingsReader.Parsed;
        private IReader<List<CustomEvent>> CustomEventReader { get; } = new Reader<List<CustomEvent>>();

        private Dictionary<DefaultEvents, WebHookModel> Webhooks { get; set; }

        public Core()
        {
            Instance = this;
            Info = new PluginInfo("GHooks", "GHooks")
            {
                Description = "A bp to discord webhooks plugin. \nBy: The-g, xiluisx."
            };
            OnReloadRequestAsync();
            RegisterCustomEvents();
        }
        private async void OnReloadRequestAsync()
        {
            SetConfigurationFilePaths();
            await FileChecker.CheckFiles();
            ReadConfigurationFiles();
            RegisterWebhooks();
        }

        private void RegisterWebhooks()
        {
            Webhooks = new Dictionary<DefaultEvents, WebHookModel>();
            foreach (DefaultEvents key in Enum.GetValues(typeof(DefaultEvents)))
            {
                var stringKey = key.ToString();
                if (!Settings.ContainsKey(stringKey))
                {
                    continue;
                }
                Webhooks[key] = Settings[stringKey];
            }
        }

        public void SendDefaultEvent(DefaultEvents defaultEvent, params object[] args)
        {
            if (!Webhooks.ContainsKey(defaultEvent))
            {
                return;
            }
            Webhooks[defaultEvent].send(args);
        }

        private void RegisterCustomEvents()
        {
            foreach (var customEvent in CustomEventReader.Parsed)
            {
                Logger.LogInfo($"[CC] Registering custom event(s) for webhook {string.Join(", ", customEvent.Event)} by name '{customEvent.Event}'..");
                EventsHandler.Add(customEvent.Event, new Action<ShEntity, ShPhysical>((trigger, physical) =>
                {
                    if (!(physical is ShPlayer player) || player.svPlayer.HasPermission("webhook."+customEvent.Event))
                    {
                        return;
                    }
                    Logger.LogInfo($"Custom event {customEvent.Event} was triggered.");
                    var web = new Webhook(customEvent.webhookLink);
                    web.Send(string.Format(customEvent.Response, player.username), string.Format(customEvent.SenderName, player.username));
                }));
            }
        }

        private void SetConfigurationFilePaths()
        {
            SettingsReader.Path = Paths.SettingsFile;
            CustomEventReader.Path = Paths.EventsFile;
        }

        private void ReadConfigurationFiles()
        {
            SettingsReader.ReadAndParse();
            CustomEventReader.ReadAndParse();
        }
    }
}
