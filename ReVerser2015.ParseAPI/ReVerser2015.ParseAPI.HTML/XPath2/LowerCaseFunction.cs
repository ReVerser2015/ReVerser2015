using System;
using System.Collections.Generic;
using System.Text;
//-------------------------------
using System.Xml.XPath;
using System.Xml.Xsl;

namespace ReVerser2015.ParseAPI.HTML.XPath2
{
    public class LowerCaseFunction : IXsltContextFunction
    {
        private static XPathResultType[] _argTypes = new XPathResultType[] { XPathResultType.Any };
        private static LowerCaseFunction _instance = new LowerCaseFunction();

        public static LowerCaseFunction Instance
        {
            get { return _instance; }
        }

        #region IXsltContextFunction Members

        public XPathResultType[] ArgTypes
        {
            get { return _argTypes; }
        }

        public int Maxargs
        {
            get { return 1; }
        }

        public int Minargs
        {
            get { return 1; }
        }

        public XPathResultType ReturnType
        {
            get { return XPathResultType.String; }
        }

        public object Invoke(XsltContext xsltContext, object[] args, XPathNavigator navigator)
        {
            string arg0 = null;
            string result = null;

            XPathNodeIterator it;

            if ((it = args[0] as XPathNodeIterator) != null)
            {
                it.MoveNext();
                arg0 = it.Current.Value;
            }
            else
            {
                arg0 = args[0].ToString();
            }

            result = arg0.ToLower();

            return result;
        }
        #endregion
    }
}
