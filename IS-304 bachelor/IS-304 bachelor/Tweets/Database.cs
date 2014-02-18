
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.ComponentModel;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;



namespace WpfApplication1
{

    public class Tweets
    {
        // The fields here are the ones which are written out ot the datagrid in Mainwindow.xaml.
        // Other fields are listed as excluded in   var cursor = collection.FindAll().SetFields(Fields.Exclude)
        public string screen_name { get; set; }
        public string text { get; set; }




    }








    class Docs //: INotifyPropertyChanged
    {

       /* protected static void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public static event PropertyChangedEventHandler PropertyChanged;*/
        private static string _queryTest;
        // get and set methods for the field QueryTest
        public static string QueryTest
        {
            get { return _queryTest; }
            set
            {
             _queryTest = value;
             
            }
            }

        //Create a new Observable collection.
        //This should be moved to a seperate class according ot MVVM standards.

        private static ObservableCollection<Tweets> _TweetOC = new ObservableCollection<Tweets>();
        public static ObservableCollection<Tweets> TweetOC
        {   //get and set methods for the collection.
            get { return _TweetOC; }

            set
            {
                _TweetOC = value;

            }

        }


        //Method for setting field QueryTest. Don't knwow if it should be used.
 /*       public void setQueryTest(String query)
        {
            

            query = QueryTest;

            
        }
*/
        //Method for establishing connection to database.
        //The query var query = Query.GT("id", "0"); need to be replaced.
        //It needs to be replaced with something that takes an argument or parameter from a text or search box from MainWindow.xaml and parses it as a query to the database.
        public static MongoDatabase GetDatabase()
        {

            QueryTest = "flom";
            System.Console.WriteLine(QueryTest);
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("lysing.uia.no", 27017);
            MongoServer server = new MongoServer(settings);
            MongoDatabase database = server.GetDatabase("tweet_database");
            var collection = database.GetCollection<Tweets>("docs");
            System.Console.WriteLine("5");
            var query = Query.Matches("text", QueryTest); //Should probably be something like Matches("text", "searchFromTextBoxInMainWindow.xaml") 
            //Another option is trying to make the searchbox update QueryTest.

            System.Console.WriteLine("6");
            var cursor = collection.Find(query).SetFields(Fields.Exclude("_id", "retweeted", "retweet_count", "followers_count", "contributors", "truncated", "in_reply_to_status_id", "id", "favorite_count",
            "source", "coordinates", "entities", "symbols", "user_mentions", "indices", "id_str", "name", "hashtags", "urls",
            "media", "source_status_id_str", "expanded_url", "display_url", "url", "media_url_https", "source_status_ID", "sizes",
            "h", "resize", "w", "large", "medium", "thumb", "in_reply_to_screen_name", "favorited", "retweeted_status", "in_reply_to_user_id",
            "user", "follow_request_sent", "profile_use_background_image", "default_profile_image", "verified", "profile_image_url_https", "profile_sidebar_fill_color",
            "profile_text_color", "favourite_count", "profile_sidebar_border_color", "profile_background_color", "listed_count", "profile_background_image_url_https",
            "utc_offset", "statuses_count", "description", "friends_count", "location", "profile_link_color", "profile_image_url", "following", "geo_enabled",
            "profile_background_image_url", "lang", "profile_background_tile", "favorites_count", "notifications", "created_at", "contributors_enabled",
            "time_zone", "protected", "default_profile", "is_translator", "geo", "in_reply_to_user_id_str", "possibly_sensitive", "storage_time", "filter_level",
            "in_reply_to_status_id_str", "place", "disconnect"));
            cursor.SetLimit(100);
            System.Console.WriteLine("7");
            //Puts the result from the last query into a list.
            var resultList = cursor.ToList();

            //Iterates over the previous mentioned list and inserts the content into the ObservableCollcetion created earlier.
            foreach (var item in resultList)
                TweetOC.Add(item);
            System.Console.WriteLine(TweetOC.Count);




            return database;

        }





    }

}
