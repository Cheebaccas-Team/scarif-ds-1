using PdfSharp.Pdf;

namespace Scarif_DS_1
{
    public class Model
    {
        private View ui;
        private PdfDocument documento;
        private string pathDestino;
        private string pathOrigem;
        private string conteudo;
        private int numPages;

        internal Model(View ui)
        {
            this.ui = ui;
        }

    }
}