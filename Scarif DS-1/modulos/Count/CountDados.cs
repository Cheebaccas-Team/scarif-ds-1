using System;

namespace Scarif_DS_1.modulos.Count
{
    public class CountDados : IDados
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private TipoDados _tipo;

        public CountDados(string caminho)
        {
            int separar = caminho.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathOrigem = caminho.Substring(0, separar+1);                                  
            FileOrigem = caminho.Substring(separar + 1);
            Tipo = TipoDados.Count;
        }
        public string PathOrigem{
            get => _pathOrigem;
            set => _pathOrigem = value;
        }

        public string FileOrigem
        {
            get => _fileOrigem;
            set => _fileOrigem = value;
        }

        public string PathDestino { get; set; }
        public string FileDestino { get; set; }

        public TipoDados Tipo { get => _tipo; set=> _tipo = value; }
    }
    
    
}