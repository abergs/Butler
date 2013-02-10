using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buttler.Models
{
    public sealed class RenderService
    {
        private static readonly RenderService instance = new RenderService();
        private ButtlerContext context;

        private RenderService()
        {
            context = new ButtlerContext();
        }

        public static RenderService Instance
        {
            get
            {
                return instance;
            }
        }

        public static string Get(string id)
        {
            // How should we structure data?
            // One table with ID / type ?
            // EF would then lookup ID and Type in that table and join the TypeTable for that ID ??
            dynamic data =  DataService.Get(id);
            var template = ""; // Read from file or maybe DB. Use IoC?
            
            string result = RazorEngine.Razor.Parse(template,data);
            return result;           
        }
    }

}