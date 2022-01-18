using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Friendstagram_Backend
{
    public static class StorageManager
    {
        public const string ImagePath = "wwwroot/images/";
        public static void SaveFile(string path, Stream fileStream)
        {
            using (var saveFileStream = File.Create(path))
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                fileStream.CopyTo(saveFileStream);
            }
        }
    }
}
