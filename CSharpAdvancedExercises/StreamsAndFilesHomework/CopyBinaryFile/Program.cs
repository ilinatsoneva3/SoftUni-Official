namespace CopyBinaryFile
{
    using System;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            using (var readStream = new FileStream("copyMe.png", FileMode.Open))
            {
                using (var writeStream = new FileStream("copied.png", FileMode.Create))
                {
                    var buffer = new byte[4096];
                    var size = readStream.Read(buffer, 0, buffer.Length);

                    while (size != 0)
                    {
                        writeStream.Write(buffer, 0, size);
                        size = readStream.Read(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
