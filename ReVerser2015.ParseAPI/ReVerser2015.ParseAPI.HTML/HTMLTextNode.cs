// HtmlAgilityPack V1.0 - Simon Mourier <simon underscore mourier at hotmail dot com>
namespace ReVerser2015.ParseAPI.HTML
{
    /// <summary>
    /// Represents an HTML text node.
    /// </summary>
    public class HTMLTextNode : HTMLNode
    {
        #region Fields

        private string _text;

        #endregion

        #region Constructors

        internal HTMLTextNode(HTMLDocument ownerdocument, int index)
            :
                base(HTMLNodeType.Text, ownerdocument, index)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the HTML between the start and end tags of the object. In the case of a text node, it is equals to OuterHTML.
        /// </summary>
        public override string InnerHTML
        {
            get { return OuterHTML; }
            set { _text = value; }
        }

        /// <summary>
        /// Gets or Sets the object and its content in HTML.
        /// </summary>
        public override string OuterHTML
        {
            get
            {
                if (_text == null)
                {
                    return base.OuterHTML;
                }
                return _text;
            }
        }

        /// <summary>
        /// Gets or Sets the text of the node.
        /// </summary>
        public string Text
        {
            get
            {
                if (_text == null)
                {
                    return base.OuterHTML;
                }
                return _text;
            }
            set { _text = value; }
        }

        #endregion
    }
}