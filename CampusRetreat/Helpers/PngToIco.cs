using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace CampusRetreat.Helpers
{
    /// <summary>
    /// Converts PNG to ICO
    /// </summary>
    public class PngToIco
    {
        public void Convert(string inPath, string outPath)
        {
            using (FileStream stream = File.OpenWrite(outPath))
            {
            }
        }
    }
}
