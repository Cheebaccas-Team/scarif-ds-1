using System;
using System.Collections.Generic;
using System.Linq;

namespace Scarif_DS_1
{
    public class ExceptionDadosInvalidos : Exception
    {
        private List<string> dados;
        public ExceptionDadosInvalidos(string mensagem, List<string> lista): base(mensagem)
        {
            dados = lista;
        }

        public string ListaErros()
        {
            string str = "";
            foreach (string s in dados)
            {
                str += s + " ";
            }
            return str;
        }
    }
}