namespace Scarif_DS_1
{
    public class Model
    {
        private View ui;
        private string pathOrigem;
        private string fileOrigem;
        private string pathDestino;
        private string fileDestino;
        private string pathOrigem2;
        private string fileOrigem2;
        private string pathDestino2;
        private string fileDestino2;
        private string conteudo;
        private int numPages;
        private int pageToRemove;
        private string texto;
        private string senha;
        private bool resultado;

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
        
        public string PathOrigem2
        {
            get => pathOrigem;
            set => pathOrigem = value;
        }

        //Propriedades (getter e setter) do Ficheiro de Origem
        public string FileOrigem2
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
        
        
        //Propriedades (getter e setter) do caminho de destino
        public string PathDestino2
        {
            get => pathDestino2;
            set => pathDestino2 = value;
        }

        //Propriedades (getter e setter) do ficheiro de destino
        public string FileDestino2
        {
            get => fileDestino2;
            set => fileDestino2 = value;
        }

        //Propriedades (getter e setter) da marca de água
        public string Texto
        {
            get => texto;
            set => texto = value;
        }

        //Propriedades (getter e setter) da página a remover
        public int PageToRemove
        {
            get => pageToRemove;
            set => pageToRemove = value;
        }

        public string Senha
        {
            get => senha;
            set => senha = value;
        }

        public bool Resultado
        {
            get => resultado;
            set => resultado = value;
        }
        
    }
}