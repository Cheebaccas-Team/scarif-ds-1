namespace Scarif_DS_1
{
    public class Model
    {
        private View ui;
        private string pathDestino;
        private string pathOrigem;
        private string fileOrigem;
        private string fileDestino;
        private string conteudo;
        private int numPages;

        public delegate void EfetuarProcessamento(Model modelo);
        public EfetuarProcessamento EfetuarProcesso;
        
        
        internal Model(View ui)
        {
            this.ui = ui;
            numPages = 0;
        }
        public int NumPages {
            get => numPages;
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
            get => pathOrigem;
            set => pathOrigem = value;
        }

        public string FileOrigem
        {
            get => fileOrigem;
            set => fileOrigem = value;
        }

        public string PathDestino
        {
            get => pathDestino;
            set => pathDestino = value;
        }

        public string FileDestino
        {
            get => fileDestino;
            set => fileDestino = value;
        }
    }
}