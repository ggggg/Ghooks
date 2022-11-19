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
            // Checks if valid URL if not sets the url to null
            if (!CheckURLValid(AvatarUrl))
            {
                AvatarUrl = null;
            }

            var webhook = new Webhook(Url)
            {
                Embeds = Embeds?.Count  > 0 ? EmbedCrafter.CreateAllEmbeds(Embeds, args) : new List<Embed>(),
                AvatarUrl = AvatarUrl,
                Content = string.Format(Format, args),
                Username = string.Format(Username, args)
            };
            webhook.Send();
        }

        // This is for cheking the AvatarURL, literally this was causing a BadRequest
        public static bool CheckURLValid(string source)
        {
            return Uri.TryCreate(source, UriKind.Absolute, out var uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        }
    }
}
