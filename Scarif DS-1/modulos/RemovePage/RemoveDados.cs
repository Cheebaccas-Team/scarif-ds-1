using System;

namespace Scarif_DS_1.modulos.RemovePage
{
    public class RemoveDados:IDados
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private string _pathDestino;
        private string _fileDestino;
        private int _page;
        private TipoDados _tipo;

        internal RemoveDados(string caminhoOrigem, string caminhoDestino, int page)
        {
            int separar = caminhoOrigem.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathOrigem = caminhoOrigem.Substring(0, separar+1);                                  
            FileOrigem = caminhoOrigem.Substring(separar + 1);
            separar = caminhoDestino.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathDestino = caminhoDestino.Substring(0, separar+1);                                  
            FileDestino = caminhoDestino.Substring(separar + 1);
            Page = page;
            Tipo = TipoDados.RemovePage;
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

        public TipoDados Tipo { get=>_tipo; set=>_tipo = value; }
    }
}