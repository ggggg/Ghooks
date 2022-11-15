using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.Networking;
using UnityEngine;
using BrokeProtocol.Managers;
using BrokeProtocol.API;
using System.Net;
using System.Collections.Specialized;

namespace Webhooks
{
    [JsonObject]
    public class Webhook : ManagerEvents
    {
        private readonly HttpClient _httpClient;

        private readonly string _webhookUrl;

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty("tts")]
        public bool IsTTS { get; set; }

        [JsonProperty("embeds")]
        public List<Embed> Embeds { get; set; } = new List<Embed>();

        public Webhook(string webhookUrl)
        {
            _httpClient = new HttpClient();
            _webhookUrl = webhookUrl;
        }

        public Webhook(ulong id, string token) : this($"https://discordapp.com/api/webhooks/{id}/{token}")
        {
        }

        public void Send()
        {
            SvManager.Instance.StartCoroutine(PostRequest());
        }
        private IEnumerator PostRequest()
        {
            var content = new System.Text.UTF8Encoding().GetBytes(JsonConvert.SerializeObject(this));

            var handler = new UnityWebRequest(_webhookUrl, "POST")
            {
                uploadHandler = new UploadHandlerRaw(content),
                downloadHandler = new DownloadHandlerBuffer()
            };
            handler.SetRequestHeader("Content-Type", "application/json");

            //Send the request then wait here until it returns
            yield return handler.SendWebRequest();

            if (handler.result == UnityWebRequest.Result.ProtocolError)
            {
                Core.Instance.Logger.LogError("Webhook request failed: " + handler.error);
            }
        }
        // ReSharper disable once InconsistentNaming
        public void Send(string content, string username = null, string avatarUrl = null, bool isTTS = false, IEnumerable<Embed> embeds = null)
        {
            Content = content;

            // Checks if valid URL if not sets the url to null
            if (!Configuration.Models.WebHookModel.CheckURLValid(AvatarUrl))
            {
                AvatarUrl = null;
            }

            Username = username;
            AvatarUrl = avatarUrl;
            IsTTS = isTTS;
            Embeds.Clear();
            if (embeds != null)
            {
                Embeds.AddRange(embeds);
            }

            Send();
        }
    }
}