using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webhooks.Configuration.Models
{
    public class WebHookModel
    {
        public string Format { get; set; }

        public string Username { get; set; }

        public string Url { get; set; }

        public List<Embed> Embeds { get; set; }

        public string AvatarUrl { get; set; }

        public void send(params object[] args)
        {
            var webhook = new Webhook(Url)
            {
                Embeds = Embeds?.Count  > 0 ? EmbedCrafter.CreateAllEmbeds(Embeds, args) : new List<Embed>()  ,
                AvatarUrl = AvatarUrl,
                Content = string.Format(Format, args),
                Username = string.Format(Username, args)
            };
            webhook.Send();
        }
    }
}
