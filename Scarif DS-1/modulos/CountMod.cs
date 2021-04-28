using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Scarif_DS_1.modulos
{
    public abstract class CountMod
    {
        private int totalPages;
        
        public int CountPages(string filePath, string filename) { 
            //Devolve o número de páginas que o ficheiro PDF indicado tem
            int totalPages = 0;
            // Open the file
            PdfDocument inputDocument = PdfReader.Open(Path.Combine(filePath, filename), PdfDocumentOpenMode.Import); 
            totalPages = inputDocument.PageCount;
            return totalPages;
        }
        
    }
}