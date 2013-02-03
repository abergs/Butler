using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buttler.Models
{
    public class Unit : IUnit
    {
        public Unit()
        {
            this.ContentFormat = new PlainText();
        }

        public string ID { get; set; }
        public string Content { get; set; }
        public IFormat ContentFormat { get; set; }

        public string ParsedContent
        {
            get
            {
                return ContentFormat.Parse(this.Content);
            }
        }
    }

    public interface IUnit
    {
        string ID { get; set; }
        string Content { get; set; }
        string ParsedContent { get; }
        IFormat ContentFormat { get; set; }
    }

    public interface IFormat
    {
        string Parse(string raw);
    }

    public class PlainText : IFormat
    {
        public const string Name = "plaintext";

        public string Parse(string value)
        {
            return value;
        }
    }
}