using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buttler.Client
{
    public static class ButtleClient
    {
        
        public static string Render(string name)
        {
            Buttler.Models.UnitRepository repo = new Buttler.Models.UnitRepository();
            Buttler.Models.Unit unit = repo.All.Where(u => u.Name == name).First();
            return unit.ParsedContent;
        }
    }
}