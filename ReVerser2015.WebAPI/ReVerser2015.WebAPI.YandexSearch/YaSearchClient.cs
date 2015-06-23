using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//-------------------------------
using ReVerser2015.WebAPI;
using System.Threading;

namespace ReVerser2015.WebAPI.YandexSearch
{
    public class YaSearchClient
    {
        Client _client;

        public Client Client
        {
            get
            {
                return _client;
            }
            set
            {
                _client = value;
            }
        }

        public YaSearchClient()
        {
            _client = new Client();
        }

        public YaSearchResults Search(string query, int page)
        {
            var html = _client.Get("http://yandex.ru/search/?text=" + query + "&p=" + page).ToHTML();

            var resultsHtml = html.DocumentNode.GetElementsByClassName("serp-item serp-item_plain_yes i-bem");

            var results = new YaSearchResults(resultsHtml);

            return results;
        }

        public delegate void YaSearchCompletedEventHandler(object sender, YaSearchCompletedEventArgs e);

        public event YaSearchCompletedEventHandler SearchCompleted;

        public void SearchAsync(string query, int page)
        {
            SearchCompleted(this, new YaSearchCompletedEventArgs(""));
        }
    }

    public class YaSearchCompletedEventArgs
    {
        public YaSearchCompletedEventArgs(string s) { Text = s; }
        public String Text {get; private set;}
    }
}
