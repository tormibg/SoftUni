﻿using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BashSoft.Network
{
    public class DowloadManager
    {
        public static void Download(string fileURL)
        {
            WebClient webClient = new WebClient();

            try
            {
                OutputWriter.WriteMessageOnNewLine("Started download ...");

                string nameOfFile = ExtractNameOfFile(fileURL);
                string pathToDownload = Path.Combine(SessionData.currentPath, nameOfFile);

                webClient.DownloadFile(fileURL, pathToDownload);

                OutputWriter.WriteMessageOnNewLine("Download complete");
            }
            catch (WebException ex)
            {
                
                OutputWriter.DisplayException(ex.Message);
            }
        }

        public static void DownloadAsync(string fileURL)
        {
            Task.Run(() => Download(fileURL));
        }

        private static string ExtractNameOfFile(string fileURL)
        {
            int indexOfLastBackSlash = fileURL.IndexOf("/", StringComparison.Ordinal);

            if (indexOfLastBackSlash != -1)
            {
                return fileURL.Substring(indexOfLastBackSlash + 1);
            }
            else
            {
                throw new WebException(ExceptionMessages.InvalidPath);
            }
        }
    }
}