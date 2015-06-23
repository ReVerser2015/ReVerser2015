using System.Xml.XPath;

namespace ReVerser2015.ParseAPI.HTML
{
    public partial class HTMLDocument : IXPathNavigable
    {
        /// <summary>
        /// Creates a new XPathNavigator object for navigating this HTML document.
        /// </summary>
        /// <returns>An XPathNavigator object. The XPathNavigator is positioned on the root of the document.</returns>
        public XPathNavigator CreateNavigator()
        {
            return new HTMLNodeNavigator(this, _documentnode);
        }
    }
}