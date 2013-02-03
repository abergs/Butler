using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buttler.Models
{
    public class Page : Unit
    {
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}