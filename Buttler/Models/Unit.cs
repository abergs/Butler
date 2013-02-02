using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buttler.Models
{
    public class Unit : IUnit
    {
        public string Content { get; set; }
    }

    interface IUnit {
        public string Content { get; set; }
    }
}