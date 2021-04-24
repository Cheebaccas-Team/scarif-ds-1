using System;

namespace Cheewbacca_PDFSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            PDFSharpIntegrate obj = new PDFSharpIntegrate();
            obj.SplitDocument("c://PDFTests", "21111SO-20-efA.pdf", "c://PDFTests/Output"); //Testado
            Console.WriteLine(obj.CountPages("c://PDFTests", "21111SO-20-efA.pdf")); //Testado deu 3
            Console.WriteLine(obj.CountPages("c://PDFTests", "pdf1.pdf")); //Testado deu 9
            Console.WriteLine(obj.CountPages("c://PDFTests", "pdf2.pdf")); //Testado deu 96
            Console.WriteLine(obj.CountPages("c://PDFTests", "pdf3.pdf")); //Testado deu 83
            obj.WatermarkFile("c://PDFTests", "21111SO-20-efA.pdf","PDF Sharp");

        }
    }
}
