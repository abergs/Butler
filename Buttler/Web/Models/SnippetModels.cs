using Buttler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Snippet : ButtlerDocument
    {
        public override string ID
        {
            get;
            set;
        }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}