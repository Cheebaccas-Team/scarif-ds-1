using System;

namespace Scarif_DS_1
{
    public class ExceptionFileNotFound : Exception
    {
        public ExceptionFileNotFound(){}

        public ExceptionFileNotFound(string mensagem) : base(mensagem)
        {
            
        }
    }
}