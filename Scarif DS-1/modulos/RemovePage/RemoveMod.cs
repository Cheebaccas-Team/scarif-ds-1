using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Scarif_DS_1.exceptions;

namespace Scarif_DS_1.modulos.RemovePage
{
    //Classe da funcionalidade de Remover Página
    public class RemoveMod: IModel
    {
        private string _fileDestino;
        private string _fileOrigem;
        private int _page;
        private string _pathDestino;
        private string _pathOrigem;
        private bool _resultado;
        private string _mensagem;
        private string _erro;

        //Construtor daclasse
        internal RemoveMod(RemoveDados dados)
        {
            PathOrigem = dados.PathOrigem;
            PathDestino = dados.PathDestino;
            FileOrigem = dados.FileOrigem;
            FileDestino = dados.FileDestino;
            Page = dados.Page;
            Resultado = false;
            _erro = null;
            _mensagem = null;
        }

        //Propriedade do atributo
        public int AddPosition { get; set; }
        
        //Propriedade do atributo
        public bool Resultado
        {
            get => _resultado;
            set => _resultado = value;
        }

        //Propriedade do atributo
        public string PathOrigem
        {
            get => _pathOrigem;
            set => _pathOrigem = value;
        }

        //Propriedade do atributo
        public string FileOrigem
        {
            get => _fileOrigem;
            set => _fileOrigem = value;
        }

        //Propriedade do atributo
        public string PathOrigem2 { get; set; }
        
        //Propriedade do atributo
        public string FileOrigem2 { get; set; }
        
        //Propriedade do atributo
        public string PathDestino
        {
            get => _pathDestino;
            set => _pathDestino = value;
        }
        
        //Propriedade do atributo
        public string FileDestino
        {
            get => _fileDestino;
            set => _fileDestino = value;
        }

        //Propriedade do atributo
        public string PathDestino2 { get; set; }
        
        //Propriedade do atributo
        public string FileDestino2 { get; set; }
        
        //Propriedade do atributo
        public int NumPages { get; set; }

        //Propriedade do atributo
        public int Page {
            get => _page;
            set => _page = value;
        }

        //Propriedade do atributo
        public string Texto { get; set; }

        //Função que executa a funcionalidade
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
                        Erros = string.Join(", ", erros);
                        Mensagem = "Faltam Dados para concluir a tarefa";
                        throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                    }

                    //Cria caminhos
                    string caminhoOrigem = Path.Combine(PathOrigem, FileOrigem);
                    string caminhoDestino = Path.Combine(PathDestino, FileDestino);

                    //Valida se o caminho é válido
                    if (!File.Exists(caminhoOrigem))
                    {
                        Mensagem = "Ficheiro não encontrado!";
                        Erros = caminhoOrigem;
                        throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminhoOrigem);
                    }
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    // Abrir ficheiro
                    PdfDocument inputDocument = PdfReader.Open(caminhoOrigem, PdfDocumentOpenMode.Import);
                    //Verifica se a página existe
                    if (Page > inputDocument.PageCount ||Page <= 0)
                    {
                        List<string> erros = new List<string>();
                        erros.Add("Número Página");
                        Erros = string.Join(", ", erros);
                        Mensagem = "Faltam Dados para concluir a tarefa";
                        throw new ExceptionDadosInvalidos("Número da página a remover é inválido.",erros);
                    }
                    else
                    {
                        // Criar novo documento
                        PdfDocument outputDocument = new PdfDocument();
                        outputDocument.Version = inputDocument.Version;
                        outputDocument.Info.Title = inputDocument.Info.Title;
                        outputDocument.Info.Creator = inputDocument.Info.Creator;
                        //Percorre o documento original e copia as páginas para o novo documento
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
                Mensagem = erro.Message;
                throw new DllNotFoundException(erro.Message);
            }
        }
        
        //Propriedade do atributo
        public string Mensagem
        {
            get=> _mensagem; 
            set => _mensagem = value;
        }

        //Propriedade do atributo
        public string Erros
        {
            get => _erro;
            set=> _erro = value;
        }
    }
}