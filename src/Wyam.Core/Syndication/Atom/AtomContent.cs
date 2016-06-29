using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using Wyam.Core.Syndication.Extensions;

namespace Wyam.Core.Syndication.Atom
{
    /// <summary>
    /// http://tools.ietf.org/html/rfc4287#section-4.1.3
    /// </summary>
    [Serializable]
    public class AtomContent : AtomText, IUriProvider
    {
        private Uri _src = null;

        /// <summary>
        /// Ctor
        /// </summary>
        public AtomContent() { }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="text"></param>
        public AtomContent(string text)
            : base(text)
        {
        }

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="xhtml"></param>
        public AtomContent(XmlNode xhtml)
            : base(xhtml)
        {
        }

        [DefaultValue(null)]
        [XmlAttribute("src")]
        public string Src
        {
            get { return ConvertToString(_src); }
            set { _src = ConvertToUri(value); }
        }

        [XmlText]
        [DefaultValue(null)]
        public override string Value
        {
            get
            {
                if (_src != null)
                {
                    return null;
                }
                return base.Value;
            }
            set { base.Value = value; }
        }

        Uri IUriProvider.Uri
        {
            get { return _src; }
        }

        public static implicit operator AtomContent(string value)
        {
            return new AtomContent(value);
        }

        public static implicit operator AtomContent(XmlNode value)
        {
            return new AtomContent(value);
        }

        public static explicit operator string(AtomContent value)
        {
            return value.Value;
        }

        public static explicit operator XmlNode(AtomContent value)
        {
            return value.XhtmlValue;
        }
    }
}