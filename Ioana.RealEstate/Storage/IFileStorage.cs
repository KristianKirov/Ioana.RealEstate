using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Storage
{
    public interface IFileStorage
    {
        Task<string> Store(Stream fileStream, string name);

        Stream GetReadStream(string name);

        Stream CreateWriteStream(string name);
    }
}
