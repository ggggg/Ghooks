using BrokeProtocol.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Webhooks
{
    public static class EmbedCrafter
    {
        public static List<Embed> CreateAllEmbeds(List<Embed> embeds, params object[] args)
        {
            return embeds.Select(embed => new Embed
                {
                    Title = string.Format(embed.Title, args),
                    Description = string.Format(embed.Description, args),
                    Color = embed.Color,
                    Footer = new EmbedFooter {Text = string.Format(embed.Footer.Text, args), IconUrl = embed.Footer.IconUrl, ProxyIconUrl = embed.Footer.ProxyIconUrl},
                    Author = new EmbedAuthor {Name = string.Format(embed.Author.Name, args), IconUrl = embed.Author.IconUrl, ProxyIconUrl = embed.Author.ProxyIconUrl, Url = embed.Author.Url},
                    Fields = new List<EmbedField>(embed.Fields.Select(c =>
                        {
                            c.Name = string.Format(c.Name, args);
                            c.Value = string.Format(c.Value, args);
                            return c;
                        })
                        .ToList()),
                    Image = embed.Image,
                    Provider = embed.Provider,
                    Url = embed.Url,
                    Thumbnail = embed.Thumbnail,
                    TimeStamp = embed.TimeStamp,
                    Type = embed.Type,
                    Video = embed.Video
                })
                .ToList();
        }
    }
}
