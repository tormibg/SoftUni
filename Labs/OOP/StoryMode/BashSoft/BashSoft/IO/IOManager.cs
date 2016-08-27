using System;
using System.Collections.Generic;
using System.IO;
using BashSoft.Static_data;

namespace BashSoft.IO
{
    public class IOManager
    {
        public void TraverseDirectory(int depth)
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

                try
                {
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
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessException);
                }

                if (depth - identation < 0)
                {
                    break;
                }
            }
        }

        public void CreateDirectoryInCurrentFolder(string name)
        {
            string path = Path.Combine(SessionData.currentPath, name);
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException(ExceptionMessages.ForbiddenSymbolsContainedInName);
            }
        }

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf("\\", StringComparison.Ordinal);
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException("indexOfLastSlash", ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }

            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath = Path.Combine(currentPath, relativePath);
                ChangeCurrentDirectoryRelative(currentPath);
            }
        }

        public void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            int indexOfLastSlash = absolutePath.LastIndexOf("\\", StringComparison.Ordinal);

            if (indexOfLastSlash < 0)
            {
                absolutePath = absolutePath + "\\";
            }

            if (!Directory.Exists(absolutePath))
            {
                throw new DirectoryNotFoundException(ExceptionMessages.InvalidPath);
                //OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                //return;
            }
            SessionData.currentPath = absolutePath;
        }
    }
}
