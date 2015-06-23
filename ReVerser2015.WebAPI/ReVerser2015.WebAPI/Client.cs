using System;
using System.Collections.Generic;
using System.Text;
//-------------------------------
using System.IO;
using System.Net;

namespace ReVerser2015.WebAPI
{
    public class Client
    {
        public Response Get(string url)
        {
            HttpWebRequest _native_hwreq = (HttpWebRequest) WebRequest.Create(url);
            _native_hwreq.Method = "GET";
            
            HttpWebResponse _native_hwresp = (HttpWebResponse) _native_hwreq.GetResponse();

            Stream s = _native_hwresp.GetResponseStream();

            var encoding = Encoding.Default;

            string responseText;

            using (var reader = new System.IO.StreamReader(s, encoding))
            {
                responseText = reader.ReadToEnd();
            }

            Response resp = new Response(responseText);

            return resp;
        }
    }
}
