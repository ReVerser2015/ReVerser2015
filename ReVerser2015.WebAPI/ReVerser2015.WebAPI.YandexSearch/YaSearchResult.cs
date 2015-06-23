using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//-------------------------------
using ReVerser2015.ParseAPI.HTML;

namespace ReVerser2015.WebAPI.YandexSearch
{
    public class YaSearchResult
    {
        HTMLNode _HTMLModel;

        public HTMLNode HTMLModel
        {
            get
            {
                return _HTMLModel;
            }
            set
            {
                _HTMLModel = value;
                this.Title = _HTMLModel.GetElementByClassName("b-link serp-item__title-link").InnerText;
            }
        }

        public string Title { get; set; }

        public HTMLNode Description { get; set; }

        public YaSearchResult()
        {
        }

        public YaSearchResult(HTMLNode htmlModel)
        {
            this.HTMLModel = htmlModel;
        }
    }
}
