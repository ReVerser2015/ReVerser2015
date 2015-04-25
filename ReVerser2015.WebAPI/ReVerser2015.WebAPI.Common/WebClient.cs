using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using net = System.Net;

namespace ReVerser2015.WebAPI.Common
{
    public class WebClient
    {
        public WebResponse Get(string URL)
        {
            var hwreq = (net.HttpWebRequest) net.WebRequest.Create(URL);

            var hwresp = (net.HttpWebResponse) hwreq.GetResponse();

            return new WebResponse(hwresp);
        }
    }
}
