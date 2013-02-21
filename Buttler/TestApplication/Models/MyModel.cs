using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication.Models
{
    public class MyModel : Butler.ButlerDocument
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}