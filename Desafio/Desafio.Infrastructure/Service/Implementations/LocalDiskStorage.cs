using Desafio.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infrastructure.Service
{
    public class LocalDiskStorage : ILocalDiskStorage
    {
        public string GetDefaultPath()
        {
            string path = "C:\\Images\\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }
    }
}
