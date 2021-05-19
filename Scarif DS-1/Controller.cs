using System;
using System.IO;
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
        public void SubmeterDados(string caminhoOrigem, string caminhoDestino)
        {
            ValidarDados(caminhoOrigem, caminhoDestino, null,null);
            ValidarDados(null, null,0, null);
        }
        
        //Função que permite atualizar os dados do modelo
        public void SubmeterDados(string caminhoOrigem, string caminhoDestino, string texto)
        {
            ValidarDados(caminhoOrigem, caminhoDestino, null,null);
            ValidarDados(null, null,0, texto);
        }
        
        //Função que permite atualizar os dados do modelo
        public void SubmeterDados(string caminhoOrigem, string caminhoDestino, string caminhoOrigem2, string caminhoDestino2)
        {
            ValidarDados(caminhoOrigem, caminhoDestino, caminhoOrigem2,caminhoDestino2);
            ValidarDados(null, null,0, null);
        }
        
        //Função que permite atualizar os dados do modelo
        public void SubmeterDados(string caminhoOrigem, string caminhoDestino, int pageToRemove,  string senha, string watermark)
        {
            ValidarDados(caminhoOrigem, caminhoDestino, null,null);
            ValidarDados(watermark, senha, pageToRemove, null);
        }

        //Validar os Dados
        private void ValidarDados(string caminhoOrigem, string caminhoDestino, string caminhoOrigem2, string caminhoDestino2)
        {
            try
            {
                if (caminhoOrigem != null)
                {
                    //Prepara os dados para fornecer ao Modelo
                    int separar = caminhoOrigem.LastIndexOf("/");
                    modelo.PathOrigem = caminhoOrigem.Substring(0, separar+1);
                    modelo.FileOrigem = caminhoOrigem.Substring(separar + 1);
                    if (!File.Exists(caminhoOrigem))
                    {
                        throw new ExceptionFileNotFound("Ficheiro não encontrado!" , caminhoOrigem);
                    }
                }
                if (caminhoOrigem2 != null)
                {
                    //Prepara os dados para fornecer ao Modelo
                    int separar = caminhoOrigem2.LastIndexOf("/");
                    modelo.PathOrigem2 = caminhoOrigem2.Substring(0, separar+1);
                    modelo.FileOrigem2 = caminhoOrigem2.Substring(separar + 1);
                    if (!File.Exists(caminhoOrigem))
                    {
                        throw new ExceptionFileNotFound("Ficheiro não encontrado!" , caminhoOrigem);
                    }
                }
                if (caminhoDestino != null)
                {
                    //Prepara os dados para fornecer ao Modelo
                    int separar = caminhoOrigem.LastIndexOf("/");
                    modelo.PathDestino = caminhoDestino.Substring(0, separar+1);
                    modelo.FileDestino = caminhoDestino.Substring(separar + 1);
                }
                if (caminhoDestino2 != null)
                {
                    //Prepara os dados para fornecer ao Modelo
                    int separar = caminhoOrigem2.LastIndexOf("/");
                    modelo.PathDestino2 = caminhoDestino2.Substring(0, separar+1);
                    modelo.FileDestino2 = caminhoDestino2.Substring(separar + 1);
                }
            }
            catch (ExceptionFileNotFound erro)
            {
                throw new ExceptionFileNotFound(erro);
            }
        }

        private void ValidarDados(string watermark, string senha, int pageToRemove, string texto)
        {
            if (watermark != null)
            {
                modelo.Texto = watermark;
            }
            if (senha != null)
            {
                modelo.Senha = senha;
            }
            if (pageToRemove != 0)
            {
                modelo.PageToRemove = pageToRemove;
            }
            if (texto != null)
            {
                modelo.Texto = texto;
            }
            modelo.NumPages = 0;
        }


        //Função que executa a funcionalidade
        public void ProcessarDados(OpcoesExecucao op)
        {
            try
            {
                switch (op)
                {
                    case OpcoesExecucao.ContarPaginas:
                        modelo.EfetuarProcesso = CountMod.ContarPaginas;
                        break;
                    case OpcoesExecucao.RemoverPagina:
                        modelo.EfetuarProcesso = EditMod.RemovePage;
                        break;
                    case OpcoesExecucao.AdicionarMarca:
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