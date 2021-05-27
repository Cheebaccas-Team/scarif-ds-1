using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Scarif_DS_1.exceptions;

namespace Scarif_DS_1.modulos.RemovePage
{
    public class RemoveMod: IModel
    {
        private string _fileDestino;
        private string _fileOrigem;
        private int _page;
        private string _pathDestino;
        private string _pathOrigem;
        private bool _resultado;

        internal RemoveMod(RemoveDados dados)
        {
            PathOrigem = dados.PathOrigem;
            PathDestino = dados.PathDestino;
            FileOrigem = dados.FileOrigem;
            FileDestino = dados.FileDestino;
            Page = dados.Page;
            Resultado = false;
        }

        public int AddPosition { get; set; }
        public bool Resultado
        {
            get => _resultado;
            set => _resultado = value;
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

        public string PathDestino2 { get; set; }
        public string FileDestino2 { get; set; }
        public int NumPages { get; set; }

        public int Page {
            get => _page;
            set => _page = value;
        }

        public string Texto { get; set; }

        public void RemovePage()
        {
            try { 
                    //Validar os dados no model
                    if (PathOrigem == null || FileOrigem == null || PathDestino == null || FileDestino == null)
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
                        throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                    }

                    //Cria caminhos
                    string caminhoOrigem = Path.Combine(PathOrigem, FileOrigem);
                    string caminhoDestino = Path.Combine(PathDestino, FileDestino);

                    //Valida se o caminho é válido
                    if (!File.Exists(caminhoOrigem))
                    {
                        throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminhoOrigem);
                    }

                    
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    // Abrir ficheiro
                    PdfDocument inputDocument = PdfReader.Open(caminhoOrigem, PdfDocumentOpenMode.Import);

                    if (Page > inputDocument.PageCount ||Page <= 0)
                    {
                        List<string> erros = new List<string>();
                        erros.Add("Número Página");
                        throw new ExceptionDadosInvalidos("Número da página a remover é inválido.",erros);
                    }
                    else
                    {
                        // Criar novo documento
                        PdfDocument outputDocument = new PdfDocument();
                        outputDocument.Version = inputDocument.Version;
                        outputDocument.Info.Title = inputDocument.Info.Title;
                        outputDocument.Info.Creator = inputDocument.Info.Creator;
                        for (int idx = 0; idx < inputDocument.PageCount; idx++)
                        {
                            // Valida se é página a remover 
                            if (Page == idx + 1)
                            {
                                //página a ignorar
                            }
                            else
                            {
                                outputDocument.AddPage(inputDocument.Pages[idx]);
                            }
                        }
                        //gravar documento substituindo
                        outputDocument.Save(caminhoDestino);
                        Resultado = true;
                    }

            }
            //Verifica as Excepções apanhadas
            catch (ExceptionDadosInvalidos erro)
            {
                throw new ExceptionDadosInvalidos(erro);
            }
            catch (ExceptionFileNotFound erro)
            {
                throw new ExceptionFileNotFound(erro);
            }catch (DllNotFoundException erro)
            {
                throw new DllNotFoundException(erro.Message);
            }
        }
    }
}