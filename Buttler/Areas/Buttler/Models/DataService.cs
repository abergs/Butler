using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buttler.Areas.Buttler.Models
{
    public sealed class DataService
    {
        private static readonly DataService instance = new DataService();
        private ButtlerContext context;

        private DataService() {
            context = new ButtlerContext();
        }

        public static DataService Instance
        {
            get
            {
                return instance;
            }
        }

        public static dynamic Get(string id) {
            id = id.ToLower();
            // How should we structure data?
            // One table with ID / type ?
            // EF would then lookup ID and Type in that table and join the TypeTable for that ID ??
            return instance.context.Pages.FirstOrDefault(p => p.Name.ToLower() == id);
        }
    }
}