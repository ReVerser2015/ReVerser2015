using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//-------------------------------
using ReVerser2015.ParseAPI.HTML;

namespace ReVerser2015.WebAPI.YandexSearch
{
    public class YaSearchResults
    {
        public YaSearchResult[] Items;

        public YaSearchPages Pages;

        HTMLNodeCollection _HTMLModel;

        public HTMLNodeCollection HTMLModel
        {
            get
            {
                return _HTMLModel;
            }
            set
            {
                _HTMLModel = value;

                this.Items = new YaSearchResult[_HTMLModel.Count];

                for (int i = 0; i < _HTMLModel.Count; i++)
                {
                    this.Items[i] = new YaSearchResult(_HTMLModel[i]);
                }
            }
        }

        public YaSearchResults(HTMLNodeCollection htmlModel)
        {
            this.HTMLModel = htmlModel;
        }
    }
}
