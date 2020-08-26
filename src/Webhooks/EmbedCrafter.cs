using BrokeProtocol.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Webhooks
{
    public static class EmbedCrafter
    {
        public static List<Embed> CreateAllEmbeds(List<Embed> embeds, ShPlayer player)
        {
            var allEmbeds = new List<Embed>();
            foreach (var embed in embeds)
            {
                allEmbeds.Add(new Embed
                {
                    Title = string.Format(embed.Title, player.username),
                    Description = string.Format(embed.Description, player.username),
                    Color = embed.Color,
                    Footer = new EmbedFooter { Text = string.Format(embed.Footer.Text, player.username), IconUrl = embed.Footer.IconUrl, ProxyIconUrl = embed.Footer.ProxyIconUrl },
                    Author = new EmbedAuthor { Name = string.Format(embed.Author.Name, player.username), IconUrl = embed.Author.IconUrl, ProxyIconUrl = embed.Author.ProxyIconUrl, Url = embed.Author.Url },
                    Fields = new List<EmbedField>(embed.Fields.Select(c =>
                    {
                        c.Name = string.Format(c.Name, player.username);
                        c.Value = string.Format(c.Value, player.username);
                        return c;
                    }).ToList()),
                    Image = embed.Image,
                    Provider = embed.Provider,
                    Url = embed.Url,
                    Thumbnail = embed.Thumbnail,
                    TimeStamp = embed.TimeStamp,
                    Type = embed.Type,
                    Video = embed.Video
                });
            }
            return allEmbeds;
        }
        public static List<Embed> CreateAllEmbeds(List<Embed> embeds, ShPlayer player, string message)
        {
            var allEmbeds = new List<Embed>();
            foreach (var embed in embeds)
            {
                allEmbeds.Add(new Embed
                {
                    Title = string.Format(embed.Title, message, player.username),
                    Description = string.Format(embed.Description, message, player.username),
                    Color = embed.Color,
                    Footer = new EmbedFooter { Text = string.Format(embed.Footer.Text, message, player.username), IconUrl = embed.Footer.IconUrl, ProxyIconUrl = embed.Footer.ProxyIconUrl },
                    Author = new EmbedAuthor { Name = string.Format(embed.Author.Name, message, player.username), IconUrl = embed.Author.IconUrl, ProxyIconUrl = embed.Author.ProxyIconUrl, Url = embed.Author.Url },
                    Fields = new List<EmbedField>(embed.Fields.Select(c =>
                    {
                        c.Name = string.Format(c.Name, message, player.username);
                        c.Value = string.Format(c.Value, message, player.username);
                        return c;
                    }).ToList()),
                    Image = embed.Image,
                    Provider = embed.Provider,
                    Url = embed.Url,
                    Thumbnail = embed.Thumbnail,
                    TimeStamp = embed.TimeStamp,
                    Type = embed.Type,
                    Video = embed.Video
                });
            }
            return allEmbeds;
        }
    }
}
