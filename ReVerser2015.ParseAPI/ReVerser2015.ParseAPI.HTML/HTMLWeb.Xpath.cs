﻿using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace ReVerser2015.ParseAPI.HTML
{
    public partial class HTMLWeb
    {
        /// <summary>
        /// Creates an instance of the given type from the specified Internet resource.
        /// </summary>
        /// <param name="htmlUrl">The requested URL, such as "http://Myserver/Mypath/Myfile.asp".</param>
        /// <param name="xsltUrl">The URL that specifies the XSLT stylesheet to load.</param>
        /// <param name="xsltArgs">An <see cref="XsltArgumentList"/> containing the namespace-qualified arguments used as input to the transform.</param>
        /// <param name="type">The requested type.</param>
        /// <returns>An newly created instance.</returns>
        public object CreateInstance(string htmlUrl, string xsltUrl, XsltArgumentList xsltArgs, Type type)
        {
            return CreateInstance(htmlUrl, xsltUrl, xsltArgs, type, null);
        }

        /// <summary>
        /// Creates an instance of the given type from the specified Internet resource.
        /// </summary>
        /// <param name="htmlUrl">The requested URL, such as "http://Myserver/Mypath/Myfile.asp".</param>
        /// <param name="xsltUrl">The URL that specifies the XSLT stylesheet to load.</param>
        /// <param name="xsltArgs">An <see cref="XsltArgumentList"/> containing the namespace-qualified arguments used as input to the transform.</param>
        /// <param name="type">The requested type.</param>
        /// <param name="xmlPath">A file path where the temporary XML before transformation will be saved. Mostly used for debugging purposes.</param>
        /// <returns>An newly created instance.</returns>
        public object CreateInstance(string htmlUrl, string xsltUrl, XsltArgumentList xsltArgs, Type type,
                                     string xmlPath)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter writer = new XmlTextWriter(sw);
            if (xsltUrl == null)
            {
                LoadHTMLAsXML(htmlUrl, writer);
            }
            else
            {
                if (xmlPath == null)
                {
                    LoadHTMLAsXML(htmlUrl, xsltUrl, xsltArgs, writer);
                }
                else
                {
                    LoadHTMLAsXML(htmlUrl, xsltUrl, xsltArgs, writer, xmlPath);
                }
            }
            writer.Flush();
            StringReader sr = new StringReader(sw.ToString());
            XmlTextReader reader = new XmlTextReader(sr);
            XmlSerializer serializer = new XmlSerializer(type);
            object o;
            try
            {
                o = serializer.Deserialize(reader);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex + ", --- xml:" + sw);
            }
            return o;
        }

        /// <summary>
        /// Loads an HTML document from an Internet resource and saves it to the specified XmlTextWriter, after an XSLT transformation.
        /// </summary>
        /// <param name="htmlUrl">The requested URL, such as "http://Myserver/Mypath/Myfile.asp".</param>
        /// <param name="xsltUrl">The URL that specifies the XSLT stylesheet to load.</param>
        /// <param name="xsltArgs">An XsltArgumentList containing the namespace-qualified arguments used as input to the transform.</param>
        /// <param name="writer">The XmlTextWriter to which you want to save.</param>
        public void LoadHTMLAsXML(string htmlUrl, string xsltUrl, XsltArgumentList xsltArgs, XmlTextWriter writer)
        {
            LoadHTMLAsXML(htmlUrl, xsltUrl, xsltArgs, writer, null);
        }

        /// <summary>
        /// Loads an HTML document from an Internet resource and saves it to the specified XmlTextWriter, after an XSLT transformation.
        /// </summary>
        /// <param name="htmlUrl">The requested URL, such as "http://Myserver/Mypath/Myfile.asp". May not be null.</param>
        /// <param name="xsltUrl">The URL that specifies the XSLT stylesheet to load.</param>
        /// <param name="xsltArgs">An XsltArgumentList containing the namespace-qualified arguments used as input to the transform.</param>
        /// <param name="writer">The XmlTextWriter to which you want to save.</param>
        /// <param name="xmlPath">A file path where the temporary XML before transformation will be saved. Mostly used for debugging purposes.</param>
        public void LoadHTMLAsXML(string htmlUrl, string xsltUrl, XsltArgumentList xsltArgs, XmlTextWriter writer,
                                  string xmlPath)
        {
            if (htmlUrl == null)
            {
                throw new ArgumentNullException("htmlUrl");
            }

            HTMLDocument doc = Load(htmlUrl);

            if (xmlPath != null)
            {
                XmlTextWriter w = new XmlTextWriter(xmlPath, doc.Encoding);
                doc.Save(w);
                w.Close();
            }
            if (xsltArgs == null)
            {
                xsltArgs = new XsltArgumentList();
            }

            // add some useful variables to the xslt doc
            xsltArgs.AddParam("url", "", htmlUrl);
            xsltArgs.AddParam("requestDuration", "", RequestDuration);
            xsltArgs.AddParam("fromCache", "", FromCache);

            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xsltUrl);
            xslt.Transform(doc, xsltArgs, writer);
        }

    }
}