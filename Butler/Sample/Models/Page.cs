using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Models
{
    public class Page : ButlerCore.ButlerDocument
    {
        public bool ShowInMenu { get; set; }
        public string Title { get; set; }
    }
}