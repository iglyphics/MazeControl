using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Maze3D
{
    public static class Helper
    {
        public static Stream GetEmbeddedResourceStream(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Stream stream = asm.GetManifestResourceStream(resourceName);
            return stream;
        }
    }
}
