using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ExtensionsAndHelpers
{
    public class PngToIco
    {
        public static void Main()
        {
            const string inPath = @"C:\Users\Daniel Sitali\Desktop\Campus Retreat Prep\logo.PNG";
            const string outPath = @"C:\Users\Daniel Sitali\Desktop\Campus Retreat Prep\logo.ico";

            Convert(inPath, outPath);
        }
        public static void Convert(string inPath, string outPath)
        {
            using (FileStream stream = File.OpenWrite(outPath))
            {
                Bitmap bitmap = (Bitmap) Image.FromFile(inPath);
                Icon.FromHandle(bitmap.GetHicon()).Save(stream);
            }
        }
    }
}
