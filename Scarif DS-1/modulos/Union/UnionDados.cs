using System;

namespace Scarif_DS_1.modulos.Union
{
    //Classe do tipo de dados União
    public class UnionDados : IDados
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private string _pathOrigem2;
        private string _fileOrigem2;
        private string _pathDestino;
        private string _fileDestino;
        private TipoDados _tipo;

        //Construtor da classe
        internal UnionDados(string caminhoOrigem, string caminhoOrigem2, string caminhoDestino, TipoDados tipo)
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
            Tipo = tipo;
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
        public string PathOrigem2
        {
            get => _pathOrigem2;
            set => _pathOrigem2 = value;
        }

        //Propriedade do atributo
        public string FileOrigem2
        {
            get => _fileOrigem2;
            set => _fileOrigem2 = value;
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
        public TipoDados Tipo
        {
            get => _tipo;
            set => _tipo = value;
        }
    }
}