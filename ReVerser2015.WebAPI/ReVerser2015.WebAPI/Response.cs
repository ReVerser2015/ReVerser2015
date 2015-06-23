using System;
using System.Collections.Generic;
using System.Text;
//-------------------------------
using ReVerser2015.ParseAPI.HTML;
using ReVerser2015.ParseAPI.JSON;
using System.Xml;

namespace ReVerser2015.WebAPI
{
    public class Response
    {
        private string __responseString = "";

        public Response(string responseString)
        {
            this.__responseString = responseString;
        }

        public override string ToString()
        {
            return __responseString;
        }

        public HTMLDocument ToHTML()
        {
            return new HTMLDocument(__responseString);
        }

        public JObject ToJSON()
        {
            throw new NotImplementedException();
        }

        public XmlDocument ToXML()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(this.__responseString);
            return xmlDoc;
        }
    }
}
