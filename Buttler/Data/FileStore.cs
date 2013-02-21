using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Buttler
{
    public class FileStore
    {

        public static void Save(string path, string content) {
            File.WriteAllText(path, content);
        }

        public static string Read(string path) {
            return File.ReadAllText(path);
        }


    }
}