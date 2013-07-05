using Butler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web2.Models
{
    public class Snippet : ButlerDocument
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}