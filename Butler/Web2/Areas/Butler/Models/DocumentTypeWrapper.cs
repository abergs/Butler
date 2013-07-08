using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ButlerWeb.Areas.Butler.Models
{
    public class DocumentTypeWrapper
    {
        public DocumentTypeWrapper(Type type)
        {
            this.Type = type;
        }
        public Type Type { get; set; }
        public string Name { get; set; }
    }
}