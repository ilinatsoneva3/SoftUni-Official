namespace ZipAndExtract
{
    using System;
    using System.IO.Compression;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var file = "copyMe.png";
            var pathToZip = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CompressedPic.zip");

            //create a zip file with the picture on the desktop
            using (var archive = ZipFile.Open(pathToZip, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(file, Path.GetFileName(file));
            }

            var destinationFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Target Folder");

            //extract the zip file just created to a new folder on the desktopp called Target Folder
            ZipFile.ExtractToDirectory(pathToZip, destinationFolder);
        }
    }
}
