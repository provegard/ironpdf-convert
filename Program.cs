using System;
using System.Drawing.Imaging;
using IronPdf;

namespace ironpdf_convert
{
    class Program
    {
        static void Main(string[] args)
        {
            License.LicenseKey = "";

            Console.WriteLine("OS:     " + Environment.OSVersion);
            Console.WriteLine(".NET:   " + Environment.Version);
            Console.WriteLine("Iron:   " + VersionInfo.IronPdfAssemblyVersion);
            Console.WriteLine("Deploy: " + Installation.ActualDeploymentPath);

            var name = args[0];
            var nameNoExt = name[..name.LastIndexOf(".")];
            var pdf = new PdfDocument(name);
            var images = pdf.ToBitmap();
            for (var i = 0; i < images.Length; i++)
            {
                var imageName = $"{nameNoExt}_{i}.png";
                Console.WriteLine($"Saving image to {imageName}");
                images[i].Save(imageName, ImageFormat.Png);
                images[i].Dispose();
            }
        }
    }
}
