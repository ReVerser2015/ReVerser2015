using System;
using System.Collections.Generic;
using System.Text;
//-------------------------------
using System.Xml.XPath;
using System.Xml.Xsl;

namespace ReVerser2015.ParseAPI.HTML.XPath2
{
    public class XPath2Context : XsltContext
    {
        public XPath2Context()
        {
        }

        public override IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] ArgTypes)
        {
            switch (name)
            {
                case "ends-with":
                    return EndsWithFunction.Instance;
                case "lower-case":
                    return LowerCaseFunction.Instance;
            }

            return null;
        }

        public override IXsltContextVariable ResolveVariable(string prefix, string name)
        {
            return null;
        }

        public override int CompareDocument(string baseUri, string nextbaseUri)
        {
            return 0;
        }

        public override bool PreserveWhitespace(XPathNavigator node)
        {
            return false;
        }

        public override bool Whitespace
        {
            get { return true; }
        }
    }
}
