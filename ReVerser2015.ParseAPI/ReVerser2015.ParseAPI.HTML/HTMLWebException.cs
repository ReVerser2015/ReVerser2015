// HtmlAgilityPack V1.0 - Simon Mourier <simon underscore mourier at hotmail dot com>
using System;

namespace ReVerser2015.ParseAPI.HTML
{
    /// <summary>
    /// Represents an exception thrown by the HTMLWeb utility class.
    /// </summary>
    public class HTMLWebException : Exception
    {
        #region Constructors

        /// <summary>
        /// Creates an instance of the HTMLWebException.
        /// </summary>
        /// <param name="message">The exception's message.</param>
        public HTMLWebException(string message)
            : base(message)
        {
        }

        #endregion
    }
}