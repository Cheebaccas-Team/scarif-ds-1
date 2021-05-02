using System;
using System.Collections.Generic;
using System.Linq;

namespace Scarif_DS_1
{
    //Classe para as Excepções de Dados Inválidos
    public class ExceptionDadosInvalidos : Exception
    {
        private List<string> dados;

        public ExceptionDadosInvalidos(ExceptionDadosInvalidos erro): base(erro.Message)
        {
            dados = erro.dados;
        }
        
        public ExceptionDadosInvalidos(string mensagem, List<string> lista): base(mensagem)
        {
            dados = lista;
        }

        //Lista de Erros detectados
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