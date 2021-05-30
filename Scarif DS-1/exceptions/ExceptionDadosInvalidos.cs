using System;
using System.Collections.Generic;

namespace Scarif_DS_1.exceptions
{
    //Classe para as Excepções de Dados Inválidos
    public class ExceptionDadosInvalidos : Exception
    {
        //Atributo de lista de Erros
        private List<string> dados;

        //Construtor da Classe
        public ExceptionDadosInvalidos(ExceptionDadosInvalidos erro): base(erro.Message)
        {
            dados = erro.dados;
        }
        
        //Construtor da classe
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