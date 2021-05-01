using System;

namespace Scarif_DS_1
{
    public class ExceptionFileNotFound : Exception
    {
        private string ficheiro;
        public ExceptionFileNotFound(string mensagem, string file) : base(mensagem)
        {
            ficheiro = file;
        }
        public string Ficheiro => ficheiro;
    }
}