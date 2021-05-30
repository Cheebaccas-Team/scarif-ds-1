using System;

namespace Scarif_DS_1.modulos.AddPage
{
    //Classe dos dados do Tipo AddPage
    public class AddPageDados : IDados
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private string _pathOrigem2;
        private string _fileOrigem2;
        private string _pathDestino;
        private string _fileDestino;
        private int _page;
        private int _pageAdd;

        //Construtor da Classe
        internal AddPageDados(string caminhoOrigem, string caminhoOrigem2, string caminhoDestino, int page, int pageAdd)
        {
            int separar = caminhoOrigem.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathOrigem = caminhoOrigem.Substring(0, separar+1);                                  
            FileOrigem = caminhoOrigem.Substring(separar + 1);
            separar = caminhoOrigem2.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathOrigem2 = caminhoOrigem2.Substring(0, separar+1);                                  
            FileOrigem2 = caminhoOrigem2.Substring(separar + 1);
            separar = caminhoDestino.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathDestino = caminhoDestino.Substring(0, separar+1);                                  
            FileDestino = caminhoDestino.Substring(separar + 1);
            Page = page;
            PageAdd = pageAdd;
            Tipo = TipoDados.AddPage;
        }
        
        //Propriedades dos atributos
        public string PathOrigem
        {
            get => _pathOrigem;
            set => _pathOrigem = value;
        }

        //Propriedades dos atributos
        public string FileOrigem
        {
            get => _fileOrigem;
            set => _fileOrigem = value;
        }

        //Propriedades dos atributos
        public string PathDestino
        {
            get => _pathDestino;
            set => _pathDestino = value;
        }

        //Propriedades dos atributos
        public string FileDestino
        {
            get => _fileDestino;
            set => _fileDestino = value;
        }

        //Propriedades dos atributos
        public int Page
        {
            get => _page;
            set => _page = value;
        }

        //Propriedades dos atributos
        public string PathOrigem2
        {
            get => _pathOrigem2;
            set => _pathOrigem2 = value;
        }

        //Propriedades dos atributos
        public string FileOrigem2
        {
            get => _fileOrigem2;
            set => _fileOrigem2 = value;
        }

        //Propriedades dos atributos
        public int PageAdd
        {
            get => _pageAdd;
            set => _pageAdd = value;
        }

        //Propriedades dos atributos
        public TipoDados Tipo { get; set; }
    }
}