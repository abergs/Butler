using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ButlerCore
{
    public abstract class ButlerDocument
    {
        public string ID { get; set; }
        public virtual Func<dynamic, dynamic> OrderBy() { return m => m.ID; }
    }
}