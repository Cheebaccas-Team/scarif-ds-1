using System;

namespace Scarif_DS_1.modulos.Count
{
    //Classe dos dados do Tipo Contar
    public class CountDados : IDados
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private TipoDados _tipo;

        //Construtor da Classe
        public CountDados(string caminho)
        {
            int separar = caminho.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathOrigem = caminho.Substring(0, separar+1);                                  
            FileOrigem = caminho.Substring(separar + 1);
            Tipo = TipoDados.Count;
        }
        
        //Propriedades do atributo
        public string PathOrigem{
            get => _pathOrigem;
            set => _pathOrigem = value;
        }

        //Propriedades do atributo
        public string FileOrigem
        {
            get => _fileOrigem;
            set => _fileOrigem = value;
        }

        //Propriedades do atributo
        public string PathDestino { get; set; }
        
        //Propriedades do atributo
        public string FileDestino { get; set; }

        //Propriedades do atributo
        public TipoDados Tipo { get => _tipo; set=> _tipo = value; }
    }
    
    
}