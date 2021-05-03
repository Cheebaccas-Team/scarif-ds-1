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
        private int pageToRemove;
        private string watermark;

        public delegate void EfetuarProcessamento(Model modelo);
        public EfetuarProcessamento EfetuarProcesso;
        
        //Construtor do Modelo
        internal Model(View ui)
        {
            this.ui = ui;
            numPages = 0;
        }
        
        //Propiedades (getter e setter) da quantidade de Páginas
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

        //Propriedades (getter e setter) do Caminho de Origem dos ficheiros
        public string PathOrigem
        {
            get => pathOrigem;
            set => pathOrigem = value;
        }

        //Propriedades (getter e setter) do Ficheiro de Origem
        public string FileOrigem
        {
            get => fileOrigem;
            set => fileOrigem = value;
        }

        //Propriedades (getter e setter) do caminho de destino
        public string PathDestino
        {
            get => pathDestino;
            set => pathDestino = value;
        }

        //Propriedades (getter e setter) do ficheiro de destino
        public string FileDestino
        {
            get => fileDestino;
            set => fileDestino = value;
        }

        //Propriedades (getter e setter) da marca de água
        public string Watermark
        {
            get => watermark;
            set => watermark = value;
        }

        //Propriedades (getter e setter) da página a remover
        public int PageToRemove
        {
            get => pageToRemove;
            set => pageToRemove = value;
        }

    }
}