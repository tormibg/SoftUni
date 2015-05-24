using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

class ZippingSlicedFiles
{
    static void Main()
    {
        int parts = 5;
        string sourceFile = @"..\..\..\05.SlicingFile\test.mpg";
        string fileExt = Path.GetExtension(sourceFile);
        string destinationDirectory = @"..\..\..\05.SlicingFile\";
        Compres(sourceFile, destinationDirectory, parts);
        List<string> filesList = Directory.GetFiles(destinationDirectory, "part*.gz").ToList();
            //List<string> filesList = new List<string>();
        //filesList.Add(@"..\..\part-0.mpg");
        //filesList.Add(@"..\..\part-1.mpg");
        //filesList.Add(@"..\..\part-2.mpg");
        //filesList.Add(@"..\..\part-3.mpg");
        //filesList.Add(@"..\..\part-4.mpg");
        Decompress(filesList, destinationDirectory, fileExt);
    }

    private static void Decompress(List<string> filesList, string destinationDirectory, string fileExt)
    {
        if (filesList.Count > 0)
        {
            FileStream fsWrite = new FileStream(destinationDirectory + "assembled" + fileExt, FileMode.Create, FileAccess.Write);
            using (fsWrite)
            {
                for (int i = 0; i < filesList.Count; i++)
                {
                    FileStream fsRead = new FileStream(filesList[i], FileMode.Open, FileAccess.Read);
                    GZipStream fsGZRead = new GZipStream(fsRead,CompressionMode.Decompress);
                    using (fsGZRead)
                    {
                        byte[] buffer = new byte[4096];
                        while (true)
                        {
                            int bytesRead = fsGZRead.Read(buffer, 0, buffer.Length);
                            if (bytesRead == 0)
                            {
                                break;
                            }
                            else
                            {
                                fsWrite.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                    fsRead.Close();
                }
            }
        }
    }

    private static void Compres(string sourceFile, string destinationDirectory, int parts)
    {
        FileStream fsRead = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
        using (fsRead)
        {
            //long targetLength = fsRead.Length;
            long sizeOfEachFile = (long)Math.Ceiling((double)fsRead.Length / parts);
            //Console.WriteLine(targetLength);
            //Console.WriteLine(sizeOfEachFile);
            for (int i = 0; i < parts; i++)
            {
                //string sFileWoExt = Path.GetFileNameWithoutExtension(sourceFile);
                string extFile = Path.GetExtension(sourceFile);
                FileStream fsWrite = new FileStream(destinationDirectory + "part-" + i.ToString() + ".gz", FileMode.Create, FileAccess.Write);
                GZipStream fsGZip = new GZipStream(fsWrite,CompressionMode.Compress,false);
                using (fsGZip)
                {

                    {
                        int countBytes = 0;
                        while (true)
                        {
                            byte[] buffer = new byte[4096];
                            if (countBytes >= sizeOfEachFile)
                            {
                                break;
                            }
                            if (countBytes + buffer.Length >= sizeOfEachFile)
                            {
                                buffer = new byte[sizeOfEachFile - countBytes];
                            }
                            countBytes += buffer.Length;
                            int bytesRead = fsRead.Read(buffer, 0, buffer.Length);
                            if (bytesRead > 0)
                            {
                                fsGZip.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                }
                fsWrite.Close();
            }
        }
    }
}