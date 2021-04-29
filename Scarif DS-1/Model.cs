using System;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Scarif_DS_1
{
    public class Model
    {
        private View ui;
        private PdfDocument documento;
        private string pathDestino;
        private string pathOrigem;
        private string fileOrigem;
        private string fileDestino;
        private string conteudo;
        private int numPages;

        internal Model(View ui)
        {
            this.ui = ui;
            this.numPages = 0;
        }
        public int NumPages {
            get { return numPages; }
            set {
                if (value == 0)
                {
                    numPages = value;
                }
                else
                {
                    numPages += value;
                }
            }
        }

        public string PathOrigem
        {
            get
            {
                return pathOrigem;
            }
            set => pathOrigem = value;
        }

        public string FileOrigem
        {
            get
            {
                return fileOrigem;
            }
            set => fileOrigem = value;
        }

        public void CountPages()
        {
            //Devolve o número de páginas que o ficheiro PDF indicado tem
            NumPages = 0;
            // Open the file
            PdfDocument inputDocument = PdfReader.Open(Path.Combine(PathOrigem, FileOrigem), PdfDocumentOpenMode.Import);
            NumPages = inputDocument.PageCount;
        }

    }
}