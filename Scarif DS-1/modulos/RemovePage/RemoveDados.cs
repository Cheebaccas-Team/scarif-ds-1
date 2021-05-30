using System;

namespace Scarif_DS_1.modulos.RemovePage
{
    //Classe do tipo de dados Remover
    public class RemoveDados:IDados
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private string _pathDestino;
        private string _fileDestino;
        private int _page;
        private TipoDados _tipo;

        //Construtor da Classe
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
        
        //Propriedade do atributo
        public string PathOrigem
        {
            get => _pathOrigem;
            set => _pathOrigem = value;
        }

        //Propriedade do atributo
        public string FileOrigem
        {
            get => _fileOrigem;
            set => _fileOrigem = value;
        }

        //Propriedade do atributo
        public string PathDestino
        {
            get => _pathDestino;
            set => _pathDestino = value;
        }

        //Propriedade do atributo
        public string FileDestino
        {
            get => _fileDestino;
            set => _fileDestino = value;
        }

        //Propriedade do atributo
        public int Page
        {
            get => _page;
            set => _page = value;
        }

        //Propriedade do atributo
        public TipoDados Tipo { get=>_tipo; set=>_tipo = value; }
    }
}