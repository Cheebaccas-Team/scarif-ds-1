using System;

namespace Scarif_DS_1.modulos.Split
{
    //Classe do tipo de dados Separar
    public class SplitDados : IDados
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private string _pathDestino;
        private string _fileDestino;
        private string _pathDestino2;
        private string _fileDestino2;
        private int _page;
        private TipoDados _tipo;

        //Construtor da Classe
        internal SplitDados(string caminhoOrigem, string caminhoDestino, string caminhoDestino2, int page)
        {
            int separar = caminhoOrigem.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathOrigem = caminhoOrigem.Substring(0, separar+1);                                  
            FileOrigem = caminhoOrigem.Substring(separar + 1);
            separar = caminhoDestino2.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathDestino2 = caminhoDestino2.Substring(0, separar+1);                                  
            FileDestino2 = caminhoDestino2.Substring(separar + 1);
            separar = caminhoDestino.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathDestino = caminhoDestino.Substring(0, separar+1);                                  
            FileDestino = caminhoDestino.Substring(separar + 1);
            Page = page;
            Tipo = TipoDados.Split;
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
        public string PathDestino2
        {
            get => _pathDestino2;
            set => _pathDestino2 = value;
        }

        //Propriedade do atributo
        public string FileDestino2
        {
            get => _fileDestino2;
            set => _fileDestino2 = value;
        }

        //Propriedade do atributo
        public int Page
        {
            get => _page;
            set => _page = value;
        }

        //Propriedade do atributo
        public TipoDados Tipo
        {
            get => _tipo;
            set => _tipo = value;
        }
    }
}