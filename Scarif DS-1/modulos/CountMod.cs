using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Scarif_DS_1
{
    public class CountMod
    {
        public static void ProcessarDados(Model modelo)
        {
            //Devolve o número de páginas que o ficheiro PDF indicado tem
            modelo.NumPages = 0;
            // Open the file
            PdfDocument inputDocument = PdfReader.Open(Path.Combine(modelo.PathOrigem, modelo.FileOrigem), PdfDocumentOpenMode.Import);
            modelo.NumPages = inputDocument.PageCount;
        }
        
    }
}