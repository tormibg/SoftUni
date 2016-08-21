﻿namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public static class IOManager
    {
        public static void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.currentPath);

            while (subFolders.Count != 0)
            {
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;
                OutputWriter.WriteMessageOnNewLine($"{new string('-', identation)}{currentPath}");

                foreach (var file in Directory.GetFiles(currentPath))
                {
                    int indexOfLastSlash = file.LastIndexOf("\\", StringComparison.Ordinal);
                    string fileName = file.Substring(indexOfLastSlash);
                    OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + fileName);
                }

                foreach (string directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
                }

                if (depth - identation < 0)
                {
                    break;
                }
            }
        }

        public static void CreateDirectoryInCurrentFolder(string name)
        {
            string path = Path.Combine(SessionData.currentPath, name);
            Directory.CreateDirectory(path);
        }

        public static void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                string currentPath = SessionData.currentPath;
                int indexOfLastSlash = currentPath.LastIndexOf("\\", StringComparison.Ordinal);
                string newPath = currentPath.Substring(0, indexOfLastSlash);
                SessionData.currentPath = newPath;
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath = Path.Combine(currentPath, relativePath);
                ChangeCurrentDirectoryRelative(currentPath);
            }
        }

        public static void ChangecurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
            }
            SessionData.currentPath = absolutePath;
        }
    }
}
