using Microsoft.EntityFrameworkCore;
using NewsAPI.Database;
using NewsAPI.Models;
using System.Xml;
using System;
using System.ServiceModel.Syndication;

namespace NewsAPI
{
    public class ParseNewsSourcesTimer
    {

        public static void Parse(object obj)
        {
            ApplicationContext db = ((IDbContextFactory<ApplicationContext>)obj).CreateDbContext();

            List<NewsSource> newsSources = db.NewsSources.ToList();


            foreach (NewsSource newsSource in newsSources)
            {
                XmlReader reader;

                try
                {
                    reader = XmlReader.Create(newsSource.RssURL);
                }
                catch
                {
                    continue;
                }

                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                foreach (SyndicationItem item in feed.Items)
                {
                    string? title = item.Title?.Text;
                    string? URL = item.Links?[0].Uri.ToString();
                    string? summary = item.Summary?.Text;

                    DateTime publishTime = item.PublishDate.DateTime;

                    if(db.Posts.All(p => p.Title != title))
                    {
                        Post post = new Post()
                        {
                            Title = title,
                            Content = summary,
                            URL = URL,
                            CreatedDate = publishTime
                        };

                        db.Posts.Add(post);

                        db.SaveChanges();
                    }
                }
            }
        }

    }
}
