using System;
using System.Dynamic;
using System.IO;

class CopyBinaryFile
{
    static void Main()
    {
        FileStream fsRead = new FileStream(@"../../test.JPG", FileMode.Open);
        FileStream fsWrite = new FileStream(@"../../test_copy.JPG", FileMode.Create);
        using (fsRead)
        {
            using (fsWrite)
            {
                byte[] buffer = new byte[4096];
                int bytesRead;
                while (true)
                {
                    bytesRead = fsRead.Read(buffer, 0, buffer.Length);
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
        }
    }
}