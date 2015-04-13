using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ioana.RealEstate.Storage
{
    public class FileSystemStorage : IFileStorage
    {
        private readonly string basePath;

        public FileSystemStorage(string basePath)
        {
            this.basePath = basePath;

            if (!Directory.Exists(this.basePath))
            {
                Directory.CreateDirectory(this.basePath);
            }
        }

        public async Task<string> Store(Stream fileStream, string name)
        {
            string uniqueFileName = this.GetUniqueFileName(name);
            string fullFilePath = Path.Combine(this.basePath, uniqueFileName);

            using (FileStream outputFileStream = new FileStream(fullFilePath, FileMode.Create, FileAccess.Write))
            {
                await fileStream.CopyToAsync(outputFileStream);
            }

            return uniqueFileName;
        }

        private string GetUniqueFileName(string name)
        {
            string fullFilePath = Path.Combine(this.basePath, name);
            if (!File.Exists(fullFilePath))
            {
                return name;
            }

            return string.Concat(Guid.NewGuid().ToString("N"), name);
        }
    }
}