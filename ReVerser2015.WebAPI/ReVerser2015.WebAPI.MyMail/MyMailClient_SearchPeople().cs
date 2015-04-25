using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ReVerser2015.WebAPI.Common;

namespace ReVerser2015.WebAPI.MyMail
{
    public class MyMailClient
    {
        private WebClient mWebClient;

        public MyMailClient()
        {
            mWebClient = new WebClient();
        }

        public MyMailPerson[] SearchPeople(string query)
        {
            var r = mWebClient.Get("http://my.mail.ru/cgi-bin/my/ajax?ajax_call=1&func_name=search.get&arg_name=" + query);
            
            r.ToJSON(Encoding.UTF8);

            List<MyMailPerson> l = new List<MyMailPerson>();
            l.Add(new MyMailPerson(r.ToString(Encoding.UTF8)));
            return l.ToArray();
        }
    }
}
