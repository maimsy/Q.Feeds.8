using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Collections.ObjectModel;
using Feeds.Services;



namespace Feeds
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

        }

        
        #region CelebPosts
        public static readonly DependencyProperty CelebPostsProperty =
           DependencyProperty.Register("CelebsPosts", typeof(ObservableCollection<RssItem>), typeof(MainPage),
               new PropertyMetadata((ObservableCollection<RssItem>)null));


        public ObservableCollection<RssItem> CelebPosts
        {
            get { return (ObservableCollection<RssItem>)GetValue(CelebPostsProperty); }
            set { SetValue(CelebPostsProperty, value); }
        }

        #endregion

        #region MusicPosts
        public static readonly DependencyProperty MusicPostsProperty =
            DependencyProperty.Register("MusicPosts", typeof(ObservableCollection<RssItem>), typeof(MainPage),
                new PropertyMetadata((ObservableCollection<RssItem>)null));


        public ObservableCollection<RssItem> MusicPosts
        {
            get { return (ObservableCollection<RssItem>)GetValue(MusicPostsProperty); }
            set { SetValue(MusicPostsProperty, value); }
        }

        #endregion

        #region GamesPosts
        public static readonly DependencyProperty GamesPostsProperty =
           DependencyProperty.Register("GamesPosts", typeof(ObservableCollection<RssItem>), typeof(MainPage),
               new PropertyMetadata((ObservableCollection<RssItem>)null));


        public ObservableCollection<RssItem> GamesPosts
        {
            get { return (ObservableCollection<RssItem>)GetValue(GamesPostsProperty); }
            set { SetValue(GamesPostsProperty, value); }
        }

        #endregion

         

        public const string CelebsPostsKey = "CelebKey";
        public const string MusicPostsKey = "MusicKey";
        public const string GamesPostsKey = "GameKey";


        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            //MessageBox.Show("helloo");
            //this.SaveState(CelebsPostsKey, CelebPostsProperty);
            //this.SaveState(MusicPostsKey, MusicPostsProperty);
            //this.SaveState(GamesPostsKey, GamesPostsProperty);

        }



        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {

            CelebPosts = this.LoadState<ObservableCollection<RssItem>>(CelebsPostsKey);
            MusicPosts = this.LoadState<ObservableCollection<RssItem>>(MusicPostsKey);
            GamesPosts = this.LoadState<ObservableCollection<RssItem>>(GamesPostsKey);

            if (CelebPosts != null)
            {

                return;
            }

            if (MusicPosts != null)
            {
                return;
            }

            if (GamesPosts != null)
            {
                return;
            }

             
         
                BlogService.GetCelebsPosts(
                    delegate(IEnumerable<RssItem> rssItems)
                    { 
                        CelebPosts = new ObservableCollection<RssItem>(); 
                        foreach (RssItem rssItem in rssItems)
                        { 
                            CelebPosts.Add(rssItem); 
                        }
                    },
                    delegate(Exception exception)
                    { 
                        System.Diagnostics.Debug.WriteLine(exception);
                    });


                BlogService.GetMusicPosts(
                       delegate(IEnumerable<RssItem> rssItems)
                       {
                           MusicPosts = new ObservableCollection<RssItem>();
                           foreach (RssItem rssItem in rssItems)
                           {
                               MusicPosts.Add(rssItem);
                           }
                       },
                       delegate(Exception exception)
                       {
                           System.Diagnostics.Debug.WriteLine(exception);
                       }); 



            BlogService.GetGamesPosts(
              delegate(IEnumerable<RssItem> rssItems)
              { 
                  GamesPosts = new ObservableCollection<RssItem>(); 
                  foreach (RssItem rssItem in rssItems)
                  {  
                      GamesPosts.Add(rssItem); 
                  }
              },
              delegate(Exception exception)
              { 
                  System.Diagnostics.Debug.WriteLine(exception);
              });


            
        }
    }     
}