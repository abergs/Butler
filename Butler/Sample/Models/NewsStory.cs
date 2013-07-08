using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Sample.Models
{
    [DisplayName("News")]
    public class NewsStory : ButlerCore.ButlerDocument
    {
        public string Headline { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
    }
}