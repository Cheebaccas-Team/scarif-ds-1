using System;

namespace Scarif_DS_1.exceptions
{
    //Classe para excepções de Ficheiro Não Encontrado
    public class ExceptionFileNotFound : Exception
    {
        //Atributo do ficheiro errado
        private string ficheiro;

        //Construtor da Classe
        public ExceptionFileNotFound(ExceptionFileNotFound erro) : base(erro.Message)
        {
            ficheiro = erro.Ficheiro;
        }
        
        //Construtor da Classe
        public ExceptionFileNotFound(string mensagem, string file) : base(mensagem)
        {
            ficheiro = file;
        }
        
        //Indica o Ficheiro que tentou procurar
        public string Ficheiro => ficheiro;
    }
}