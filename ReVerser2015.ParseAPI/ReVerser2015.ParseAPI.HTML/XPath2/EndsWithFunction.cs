using System;
using System.Collections.Generic;
using System.Text;
//-------------------------------
using System.Xml.XPath;
using System.Xml.Xsl;

namespace ReVerser2015.ParseAPI.HTML.XPath2
{
    public class EndsWithFunction : IXsltContextFunction
    {
        private static XPathResultType[] _argTypes = new XPathResultType[] { XPathResultType.Any };
        private static EndsWithFunction _instance = new EndsWithFunction();

        public static EndsWithFunction Instance
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
            get { return 2; }
        }

        public int Minargs
        {
            get { return 2; }
        }

        public XPathResultType ReturnType
        {
            get { return XPathResultType.Boolean; }
        }

        public object Invoke(XsltContext xsltContext, object[] args, XPathNavigator navigator)
        {
            string arg0 = null;
            string arg1 = null;
            bool result = false;

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

            if ((it = args[1] as XPathNodeIterator) != null)
            {
                it.MoveNext();
                arg1 = it.Current.Value;
            }
            else
            {
                arg1 = args[1].ToString();
            }

            result = arg0.EndsWith(arg1);

            return result;
        }
        #endregion
    }
}
