using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Sample.Models
{
    [DisplayName("NormalPages")]
    public class PageInfo : ButlerCore.ButlerDocument
    {
        public string Headline { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public bool ShowTheSidebar { get; set; }
        public bool ShowInNav { get; set; }
        
    }
}