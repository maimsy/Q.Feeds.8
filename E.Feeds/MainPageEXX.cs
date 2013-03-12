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
    public partial class MainEXX : PhoneApplicationPage
    {
        // Constructor
        public MainEXX()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }


        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }


        #region LastPosts

        /// <summary>
        /// LastPosts Dependency Property
        /// </summary>
        public static readonly DependencyProperty LastPostsProperty =
            DependencyProperty.Register("LastPosts", typeof(ObservableCollection<RssItem>), typeof(MainEXX),
                new PropertyMetadata((ObservableCollection<RssItem>)null));

        /// <summary>
        /// Gets or sets the LastPosts property. This dependency property 
        /// indicates what are the last posts.
        /// </summary>
        public ObservableCollection<RssItem> LastPosts
        {
            get { return (ObservableCollection<RssItem>)GetValue(LastPostsProperty); }
            set { SetValue(LastPostsProperty, value); }
        }

        #endregion

        #region Posts

        /// <summary>
        /// Posts Dependency Property
        /// </summary>
        public static readonly DependencyProperty PostsProperty =
            DependencyProperty.Register("Posts", typeof(ObservableCollection<RssItem>), typeof(MainEXX),
                new PropertyMetadata((ObservableCollection<RssItem>)null));

        /// <summary>
        /// Gets or sets the Posts property. This dependency property 
        /// indicates what are all the posts.
        /// </summary>
        public ObservableCollection<RssItem> Posts
        {
            get { return (ObservableCollection<RssItem>)GetValue(PostsProperty); }
            set { SetValue(PostsProperty, value); }
        }

        #endregion

        #region Comments

        /// <summary>
        /// Comments Dependency Property
        /// </summary>
        public static readonly DependencyProperty CommentsProperty =
            DependencyProperty.Register("Comments", typeof(ObservableCollection<RssItem>), typeof(MainEXX),
                new PropertyMetadata((ObservableCollection<RssItem>)null));

        /// <summary>
        /// Gets or sets the Comments property. This dependency property 
        /// indicates what are the posts comments.
        /// 

        /// </summary>
        public ObservableCollection<RssItem> Comments
        {
            get { return (ObservableCollection<RssItem>)GetValue(CommentsProperty); }
            set { SetValue(CommentsProperty, value); }
        }

        #endregion


        #region IsPostsLoading

        /// <summary>
        /// IsPostsLoading Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsPostsLoadingProperty =
            DependencyProperty.Register("IsPostsLoading", typeof(bool), typeof(MainEXX),
                new PropertyMetadata((bool)false));

        /// <summary>
        /// Gets or sets the IsPostsLoading property. This dependency property 
        /// indicates whether we are currently loading posts.
        /// </summary>
        public bool IsPostsLoading
        {
            get { return (bool)GetValue(IsPostsLoadingProperty); }
            set { SetValue(IsPostsLoadingProperty, value); }
        }

        #endregion

        #region IsCommentsLoading

        /// <summary>
        /// IsCommentsLoading Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsCommentsLoadingProperty =
        DependencyProperty.Register("IsCommentsLoading", typeof(bool), typeof(MainEXX),
                new PropertyMetadata((bool)false));

        /// <summary>
        /// Gets or sets the IsCommentsLoading property. This dependency property 
        /// indicates whether we are currently loading comments.
        /// </summary>
        public bool IsCommentsLoading
        {
            get { return (bool)GetValue(IsCommentsLoadingProperty); }
            set { SetValue(IsCommentsLoadingProperty, value); }
        }

    }
}


        #endregion
