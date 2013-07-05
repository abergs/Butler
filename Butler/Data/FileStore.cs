using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Butler
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

        public static List<string> ReadAll(string path)
        {
            path = cleanPath(path);
            string[] filePaths = Directory.GetFiles(path);
            List<String> files = new List<string>();

            foreach (string filePath in filePaths)
            {
                files.Add(Read(filePath));
            }

            var pathz = "asdasd";
            string[] filePathsz = Directory.GetFiles(path);

            var searchWord = "hello";

            foreach (string filePath in filePaths)
            {
                // remove extension
                var file = Path.GetFileNameWithoutExtension(filePath);
                if (file.Contains(searchWord))
                {
                    // found it
                }
            }

            return files;
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