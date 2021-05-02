using System;
using Scarif_DS_1.ui;

namespace Scarif_DS_1
{
    public class Controller
    {
        private Model modelo;
        private View ui;

        //Construtor do Controlador
        internal Controller()
        {
            modelo = new Model(ui);
            ui = new Consola(modelo, this);
            ui.AtivarInterface();
        }

        //Função que permite atualizar os dados do modelo
        public bool SubmeterDados(string pathOrigem, string pathDestino, string fileOrigem, string fileDestino)
        {
            modelo.PathOrigem = pathOrigem;
            modelo.PathDestino = pathDestino;
            modelo.FileOrigem = fileOrigem;
            modelo.FileDestino = fileDestino;
            modelo.NumPages = 0;
            return true;
        }
        
        //Função que executa a funcionalidade
        public void ProcessarDados(int op)
        {
            try
            {
                switch (op)
                {
                    case 1:
                        modelo.EfetuarProcesso = CountMod.ProcessarDados;
                        break;
                }

                modelo.EfetuarProcesso(modelo);
            }
            catch (ExceptionDadosInvalidos erro)
            {
                throw new ExceptionDadosInvalidos(erro);
            }
            catch (ExceptionFileNotFound erro)
            {
                throw new ExceptionFileNotFound(erro);
            }
        }
    }
}