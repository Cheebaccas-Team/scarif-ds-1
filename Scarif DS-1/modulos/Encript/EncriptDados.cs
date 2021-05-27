using System;

namespace Scarif_DS_1.modulos.Encript
{
    public class EncriptDados : IDados
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private string _pathDestino;
        private string _fileDestino;
        private string _senha;
        private TipoDados _tipo;

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

        public string Senha
        {
            get => _senha;
            set => _senha = value;
        }

        public TipoDados Tipo
        {
            get => _tipo;
            set => _tipo = value;
        }
    }
    
    
}