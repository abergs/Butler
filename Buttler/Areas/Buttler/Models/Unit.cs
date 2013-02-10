using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        // Save in DB
        public int ID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

        public IFormat ContentFormat { get; set; }

        public virtual string ParsedContent
        {
            get
            {
                return ContentFormat.Parse(this.Content);
            }
        }
    }

    public interface IUnit
    {
        int ID { get; set; }
        string Name { get; set; }
        string Content { get; set; }
        string ParsedContent { get; }
        IFormat ContentFormat { get; set; }
    }

    public interface IFormat
    {
        string Name { get; }
        string Parse(string raw);        
    }

    public class PlainText : IFormat
    {
        public string Name { get { return "plaintext"; } }

        public string Parse(string value)
        {
            return value;
        }
    }
}