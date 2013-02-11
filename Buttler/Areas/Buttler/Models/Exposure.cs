using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buttler.Areas.Buttler.Models;

namespace Buttler.Areas.Buttler.Client
{
    public static class ButtleClient
    {
        
        public static string Render(string name)
        {
            UnitRepository repo = new UnitRepository();
            Unit unit = repo.All.Where(u => u.Name == name).First();
            return unit.ParsedContent;
        }

        public static dynamic Get(string name) {
            return DataService.Get(name);
        }
    }
}