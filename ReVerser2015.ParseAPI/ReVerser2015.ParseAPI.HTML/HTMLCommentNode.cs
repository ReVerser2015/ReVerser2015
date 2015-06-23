// HtmlAgilityPack V1.0 - Simon Mourier <simon underscore mourier at hotmail dot com>
namespace ReVerser2015.ParseAPI.HTML
{
    /// <summary>
    /// Represents an HTML comment.
    /// </summary>
    public class HTMLCommentNode : HTMLNode
    {
        #region Fields

        private string _comment;

        #endregion

        #region Constructors

        internal HTMLCommentNode(HTMLDocument ownerdocument, int index)
            :
                base(HTMLNodeType.Comment, ownerdocument, index)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the comment text of the node.
        /// </summary>
        public string Comment
        {
            get
            {
                if (_comment == null)
                {
                    return base.InnerHTML;
                }
                return _comment;
            }
            set { _comment = value; }
        }

        /// <summary>
        /// Gets or Sets the HTML between the start and end tags of the object. In the case of a text node, it is equals to OuterHTML.
        /// </summary>
        public override string InnerHTML
        {
            get
            {
                if (_comment == null)
                {
                    return base.InnerHTML;
                }
                return _comment;
            }
            set { _comment = value; }
        }

        /// <summary>
        /// Gets or Sets the object and its content in HTML.
        /// </summary>
        public override string OuterHTML
        {
            get
            {
                if (_comment == null)
                {
                    return base.OuterHTML;
                }
                return "<!--" + _comment + "-->";
            }
        }

        #endregion
    }
}