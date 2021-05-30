using System;

namespace Scarif_DS_1.modulos.Encript
{
    //Classe do tipo de dados Encriptar
    public class EncriptDados : IDados
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private string _pathDestino;
        private string _fileDestino;
        private string _senha;
        private TipoDados _tipo;

        //Construtor da classe
        internal EncriptDados(string caminhoOrigem, string caminhoDestino, string senha, TipoDados tipo)
        {
            int separar = caminhoOrigem.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathOrigem = caminhoOrigem.Substring(0, separar+1);                                  
            FileOrigem = caminhoOrigem.Substring(separar + 1);
            separar = caminhoDestino.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathDestino = caminhoDestino.Substring(0, separar+1);                                  
            FileDestino = caminhoDestino.Substring(separar + 1);
            Senha = senha;
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
        public string Senha
        {
            get => _senha;
            set => _senha = value;
        }

        //Propriedade do atributo
        public TipoDados Tipo
        {
            get => _tipo;
            set => _tipo = value;
        }
    }
}