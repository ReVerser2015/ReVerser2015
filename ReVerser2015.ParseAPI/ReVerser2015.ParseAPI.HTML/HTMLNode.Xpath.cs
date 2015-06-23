using System;
using System.Xml.XPath;

namespace ReVerser2015.ParseAPI.HTML
{
	public partial class HTMLNode : IXPathNavigable
	{
		
		/// <summary>
		/// Creates a new XPathNavigator object for navigating this HTML node.
		/// </summary>
		/// <returns>An XPathNavigator object. The XPathNavigator is positioned on the node from which the method was called. It is not positioned on the root of the document.</returns>
		public XPathNavigator CreateNavigator()
		{
			return new HTMLNodeNavigator(OwnerDocument, this);
		}

		/// <summary>
		/// Creates an XPathNavigator using the root of this document.
		/// </summary>
		/// <returns></returns>
		public XPathNavigator CreateRootNavigator()
		{
			return new HTMLNodeNavigator(OwnerDocument, OwnerDocument.DocumentNode);
		}

		/// <summary>
		/// Selects a list of nodes matching the <see cref="XPath"/> expression.
		/// </summary>
		/// <param name="xpath">The XPath expression.</param>
		/// <returns>An <see cref="HTMLNodeCollection"/> containing a collection of nodes matching the <see cref="XPath"/> query, or <c>null</c> if no node matched the XPath expression.</returns>
		public HTMLNodeCollection SelectNodes(string xpath)
		{
			HTMLNodeCollection list = new HTMLNodeCollection(null);

			HTMLNodeNavigator nav = new HTMLNodeNavigator(OwnerDocument, this);
			XPathNodeIterator it = nav.Select(xpath);
			while (it.MoveNext())
			{
				HTMLNodeNavigator n = (HTMLNodeNavigator)it.Current;
				list.Add(n.CurrentNode);
			}
			if (list.Count == 0)
			{
				return null;
			}
			return list;
		}

		/// <summary>
		/// Selects the first XmlNode that matches the XPath expression.
		/// </summary>
		/// <param name="xpath">The XPath expression. May not be null.</param>
		/// <returns>The first <see cref="HTMLNode"/> that matches the XPath query or a null reference if no matching node was found.</returns>
		public HTMLNode SelectNode(string xpath)
		{
			if (xpath == null)
			{
				throw new ArgumentNullException("xpath");
			}

			HTMLNodeNavigator nav = new HTMLNodeNavigator(OwnerDocument, this);
			XPathNodeIterator it = nav.Select(xpath);
			if (!it.MoveNext())
			{
				return null;
			}

			HTMLNodeNavigator node = (HTMLNodeNavigator)it.Current;
			return node.CurrentNode;
		}

	}
}
