using System;
using System.Collections.Generic;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Scarif_DS_1.exceptions;

namespace Scarif_DS_1.modulos.Count
{
    public class CountMod : IModel
    {
        private string _pathorigem;
        private string _fileOrigem;
        private int _numPages;
        private bool _resultado;
        private string _mensagem;
        private string _erro;

        internal CountMod(CountDados dados)
        {
            PathOrigem = dados.PathOrigem;
            FileOrigem = dados.FileOrigem;
            NumPages = 0;
            Resultado = false;
            _erro = null;
            _mensagem = null;
        }
        public void ContarPaginas()
        {
            try
            {
                //Validar os dados no model
                if (PathOrigem == null || FileOrigem == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (PathOrigem == null)
                        erros.Add("Caminho de Origem");
                    if (FileOrigem == null)
                        erros.Add("Ficheiro de Origem");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Cria o caminho para o endereço
                string caminho = Path.Combine(PathOrigem, FileOrigem);
                //Valida se o caminho é válido
                if (!File.Exists(caminho))
                {
                    Mensagem = "Ficheiro não encontrado!";
                    Erros = caminho;
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminho);
                }

                //Inicializa o valor de quantidade de páginas no modelo
                NumPages = 0;
                //Abre o ficheiro para analisar
                PdfDocument inputDocument = PdfReader.Open(caminho, PdfDocumentOpenMode.Import);
                //Atualiza valor de quantidade de páginas no modelo com a quantidade de páginas calculadas do ficheiro
                NumPages = inputDocument.PageCount;
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
                Mensagem = erro.Message;
                throw new DllNotFoundException(erro.Message);
            }
        }

        public string PathOrigem { get => _pathorigem; set => _pathorigem = value; }
        public string FileOrigem { get => _fileOrigem; set=> _fileOrigem = value; }
        public string PathOrigem2 { get; set; }
        public string FileOrigem2 { get; set; }
        public string PathDestino { get; set; }
        public string FileDestino { get; set; }
        public string PathDestino2 { get; set; }
        public string FileDestino2 { get; set; }
        public int NumPages { get => _numPages; set => _numPages = value; }
        public int Page { get; set; }
        public string Texto { get; set; }
        public int AddPosition { get; set; }
        public bool Resultado { get => _resultado; set => _resultado = value; }

        public string Mensagem
        {
            get=> _mensagem; 
            set => _mensagem = value;
        }

        public string Erros
        {
            get => _erro;
            set=> _erro = value;
        }
    }
}