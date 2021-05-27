using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Scarif_DS_1.exceptions;

namespace Scarif_DS_1.modulos.Split
{
    public class SplitMod : IModel
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private string _pathDestino;
        private string _fileDestino;
        private string _pathDestino2;
        private string _fileDestino2;
        private int _page;
        private bool _resultado;

        internal SplitMod(SplitDados dados)
        {
            PathOrigem = dados.PathOrigem;
            FileOrigem = dados.FileOrigem;
            PathDestino = dados.PathDestino;
            FileDestino = dados.FileDestino;
            PathDestino2 = dados.PathDestino2;
            FileDestino2 = dados.FileDestino2;
            Page = dados.Page;
            Resultado = false;
        }
        public string PathOrigem
        {
            get => _pathOrigem;
            set => _pathOrigem = value;
        }

        public string FileOrigem
        {
            get => _fileOrigem;
            set => _fileOrigem = value;
        }

        public string PathOrigem2 { get; set; }
        public string FileOrigem2 { get; set; }

        public string PathDestino
        {
            get => _pathDestino;
            set => _pathDestino = value;
        }

        public string FileDestino
        {
            get => _fileDestino;
            set => _fileDestino = value;
        }

        public string PathDestino2
        {
            get => _pathDestino2;
            set => _pathDestino2 = value;
        }

        public string FileDestino2
        {
            get => _fileDestino2;
            set => _fileDestino2 = value;
        }

        public int NumPages { get; set; }

        public int Page
        {
            get => _page;
            set => _page = value;
        }

        public string Texto { get; set; }
        public int AddPosition { get; set; }

        public bool Resultado
        {
            get => _resultado;
            set => _resultado = value;
        }

        public void SplitDocument()
        {
            try
            {
                //Validar os dados no model
                if (PathOrigem == null || FileOrigem == null || PathDestino == null ||
                    FileDestino == null || PathDestino2 == null || FileDestino2 == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (PathOrigem == null)
                        erros.Add("Caminho de Origem");
                    if (FileOrigem == null)
                        erros.Add("Ficheiro de Origem");
                    if (PathDestino == null)
                        erros.Add("Caminho de Destino");
                    if (FileDestino == null)
                        erros.Add("Ficheiro de Destino");
                    if (PathDestino2 == null)
                        erros.Add("Segundo Caminho de Destino");
                    if (FileDestino2 == null)
                        erros.Add("Segundo Ficheiro de Destino");
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Cria caminhos
                string caminhoOrigem = Path.Combine(PathOrigem, FileOrigem);
                string caminhoDestino = Path.Combine(PathDestino, FileDestino);
                string caminhoDestino2 = Path.Combine(PathDestino2, FileDestino2);

                //Valida se o caminho é válido
                if (!File.Exists(caminhoOrigem))
                {
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminhoOrigem);
                }

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                // Abrir ficheiro
                PdfDocument inputDocument = PdfReader.Open(caminhoOrigem, PdfDocumentOpenMode.Import);

                string name = Path.GetFileNameWithoutExtension(caminhoDestino);

                if (Page > inputDocument.PageCount || Page <= 0)
                {
                    List<string> erros = new List<string>();
                    erros.Add("Número Página");
                    throw new ExceptionDadosInvalidos("Número da página a remover é inválido.", erros);
                }

                //criar novo documento 1
                PdfDocument outputDocument1 = new PdfDocument();
                outputDocument1.Version = inputDocument.Version;
                outputDocument1.Info.Creator = inputDocument.Info.Creator;

                //criar novo documento 2
                PdfDocument outputDocument2 = new PdfDocument();
                outputDocument2.Version = inputDocument.Version;
                outputDocument2.Info.Creator = inputDocument.Info.Creator;

                for (int idx = 0; idx < inputDocument.PageCount; idx++)
                {
                    //cria o primeiro documento com as páginas maiores ou iguais à selecionada
                    if (idx >= Page)
                    {
                        outputDocument1.AddPage(inputDocument.Pages[idx]);
                    }
                    //cria o segundo documento com as restantes
                    else
                    {
                        outputDocument2.AddPage(inputDocument.Pages[idx]);
                    }

                }

                //guarda documentos
                outputDocument1.Save(Path.Combine(caminhoDestino));
                outputDocument2.Save(Path.Combine(caminhoDestino2));
                Resultado = true;

            }
            //Verifica as Excepções apanhadas
            catch (ExceptionDadosInvalidos erro)

            {
                throw new ExceptionDadosInvalidos(erro);
            }
            catch (ExceptionFileNotFound erro)
            {
                throw new ExceptionFileNotFound(erro);
            }
            catch (DllNotFoundException erro)
            {
                throw new DllNotFoundException(erro.Message);

            }
        }

    }
}