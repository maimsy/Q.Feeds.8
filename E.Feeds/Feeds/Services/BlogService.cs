using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Feeds.Services;
using System.ServiceModel.Syndication;
using System.Xml;
using System.IO;

namespace Feeds
{
    public static class BlogService
    {
        private const string CelebsSearchQuery = "http://rss.people.com/web/people/rss/topheadlines/index.xml";
        private const string MusicSearchQuery = "http://www.billboard.com/rss/charts/hot-100";
        private const string GamesSearchQuery = "http://feeds.feedburner.com/gamerant?format=xml";

        private static void GetRssItems(string rssFeed, Action<IEnumerable<RssItem>> onGetRssItemsCompleted = null, Action<Exception> onError = null, Action onFinally = null)
        {
            WebClient webClient = new WebClient();

            webClient.OpenReadCompleted += delegate(object sender, OpenReadCompletedEventArgs e)
            {
                try
                {
                    
                    if (e.Error != null)
                    {
                        if (onError != null)
                        {
                            onError(e.Error);
                        }
                        return;
                    }

                    List<RssItem> rssItems = new List<RssItem>();
                    Stream stream = e.Result;
                    XmlReader response = XmlReader.Create(stream);
                    SyndicationFeed feeds = SyndicationFeed.Load(response);
                    foreach (SyndicationItem f in feeds.Items)
                    {
                        RssItem rssItem = new RssItem(f.Title.Text, f.Summary.Text, f.PublishDate.ToString(), f.Links[0].Uri.AbsoluteUri);
                        rssItems.Add(rssItem);
                    }
                    if (onGetRssItemsCompleted != null)
                    {
                        onGetRssItemsCompleted(rssItems);
                    }
                }
                finally
                {
                    
                    if (onFinally != null)
                    {
                        onFinally();
                    }
                }
            };

            webClient.OpenReadAsync(new Uri(rssFeed));
        }

        
        public static void GetCelebsPosts(Action<IEnumerable<RssItem>> onGetBlogPostsCompleted = null, Action<Exception> onError = null, Action onFinally = null)
        {
            GetRssItems(CelebsSearchQuery, onGetBlogPostsCompleted, onError, onFinally);
        }

       
        public static void GetMusicPosts(Action<IEnumerable<RssItem>> onGetBlogPostsCompleted = null, Action<Exception> onError = null, Action onFinally = null)
        {
            GetRssItems(MusicSearchQuery, onGetBlogPostsCompleted, onError, onFinally);
        }

        
        public static void GetGamesPosts(Action<IEnumerable<RssItem>> onGetBlogPostsCompleted = null, Action<Exception> onError = null, Action onFinally = null)
        {
            GetRssItems(GamesSearchQuery, onGetBlogPostsCompleted, onError, onFinally);
        }

    }
}
