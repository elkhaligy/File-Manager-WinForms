using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Managment
{
    internal static class Utility
    {
        public static void Copy(string sourcePath, string destPath)
        {
            if (File.Exists(sourcePath))
            {
                File.Copy(sourcePath, destPath, true);
            }
            else
            {
                _CopyDirectory(sourcePath, destPath);
            }
        } 

        private static void _CopyDirectory(string sourcePath, string destPath)
        {
            // Create the destination directory if it does not exist
            Directory.CreateDirectory(destPath);

            // Copy all files in the current directory
            foreach (string file in Directory.GetFiles(sourcePath))
            {
                string destFilePath = Path.Combine(destPath, Path.GetFileName(file));
                File.Copy(file, destFilePath, true); // Overwrite if file exists
            }

            // Copy all subdirectories recursively
            foreach (string subDir in Directory.GetDirectories(sourcePath))
            {
                string destSubDir = Path.Combine(destPath, Path.GetFileName(subDir));
                _CopyDirectory(subDir, destSubDir);
            }
        }
    }
}
