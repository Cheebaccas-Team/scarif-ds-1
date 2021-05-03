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
        public void SubmeterDados(string caminhoOrigem, string caminhoDestino, string watermark, int pageToRemove)
        {
            validarDados(caminhoOrigem, caminhoDestino, watermark, pageToRemove);
            modelo.NumPages = 0;
        }

        //Valida os dados
        private void validarDados(string caminhoOrigem, string caminhoDestino, string watermark, int pageToRemove)
        {
            if (caminhoOrigem != null)
            {
                //Prepara os dados para fornecer ao Modelo
                int separar = caminhoOrigem.LastIndexOf("/");
                modelo.PathOrigem = caminhoOrigem.Substring(0, separar+1);
                modelo.FileOrigem = caminhoOrigem.Substring(separar + 1);
            }
            if (caminhoDestino != null)
            {
                //Prepara os dados para fornecer ao Modelo
                int separar = caminhoOrigem.LastIndexOf("/");
                modelo.PathDestino = caminhoDestino.Substring(0, separar+1);
                modelo.FileDestino = caminhoDestino.Substring(separar + 1);
            }
            if (watermark != null)
            {
                modelo.Watermark = watermark;
            }
            if (pageToRemove != 0)
            {
                modelo.PageToRemove = pageToRemove;
            }
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
                    case 2:
                        modelo.EfetuarProcesso = EditMod.RemovePage;
                        break;
                    case 3:
                        modelo.EfetuarProcesso = EditMod.WatermarkFile;
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