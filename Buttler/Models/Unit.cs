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
        public string Content { get; set; }
        public IFormat ContentFormat { get; set; }
    }

    public interface IUnit {
        string Content { get; set; }
        IFormat ContentFormat { get; set; }
    }

    public interface IFormat {
        string Parse();
        string Stringify();
    }

    public class PlainText : IFormat {

        public string Parse(string value) {
            return value;
        }

        public string Stringify(string value)
        {
            return value;
        }
        
    }
}