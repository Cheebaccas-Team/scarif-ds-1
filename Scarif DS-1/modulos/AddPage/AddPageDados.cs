using System;

namespace Scarif_DS_1.modulos.AddPage
{
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
        
        public string PathOrigem
        {
            get => _pathOrigem;
            set => _pathOrigem = value;
        }

        public string FileOrigem
        {
            get => _fileOrigem;
            set => _fileOrigem = value;
        }

        public string PathDestino
        {
            get => _pathDestino;
            set => _pathDestino = value;
        }

        public string FileDestino
        {
            get => _fileDestino;
            set => _fileDestino = value;
        }

        public int Page
        {
            get => _page;
            set => _page = value;
        }

        public string PathOrigem2
        {
            get => _pathOrigem2;
            set => _pathOrigem2 = value;
        }

        public string FileOrigem2
        {
            get => _fileOrigem2;
            set => _fileOrigem2 = value;
        }

        public int PageAdd
        {
            get => _pageAdd;
            set => _pageAdd = value;
        }

        public TipoDados Tipo { get; set; }
    }
}