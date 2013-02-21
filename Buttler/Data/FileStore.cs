using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Buttler
{
    public class FileStore
    {

        public static void Save(string path, string content)
        {
            // Remove the filename from path
            string pathOnly = cleanPath(path);
            if (!Directory.Exists(pathOnly))
            {
                Directory.CreateDirectory(pathOnly);
            }

            File.WriteAllText(path, content);
        }

        public static string Read(string path)
        {
            return File.ReadAllText(path);
        }

        private static string cleanPath(string path)
        {
            string[] lines = path.Split('\\');
            int lastLength = lines.Last().Length;
            path = path.Substring(0, path.Length - lastLength);

            return path;
        }
    }
}