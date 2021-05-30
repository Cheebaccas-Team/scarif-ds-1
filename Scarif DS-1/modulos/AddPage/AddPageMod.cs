using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Scarif_DS_1.exceptions;

namespace Scarif_DS_1.modulos.AddPage
{
    //Classe de Modulo Adicionar Página
    public class AddPageMod : IModel
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private string _pathOrigem2;
        private string _fileOrigem2;
        private string _pathDestino;
        private string _fileDestino;
        private int _page;
        private int _addPosition;
        private bool _resultado;
        private string _mensagem;
        private string _erro;

        //Construtor da Classe
        internal AddPageMod(AddPageDados dados)
        {
            PathOrigem = dados.PathOrigem;
            FileOrigem = dados.FileOrigem;
            PathOrigem2 = dados.PathOrigem2;
            FileOrigem2 = dados.FileOrigem2;
            PathDestino = dados.PathDestino;
            FileDestino = dados.FileDestino;
            Page = dados.Page;
            AddPosition = dados.PageAdd;
            Resultado = false;
            _erro = null;
            _mensagem = null;
        }
        
        //Função que executa funcionalidade
        public void AddPage() 
        {
            try
            {
                //Validar os dados no model
                if (PathOrigem == null || FileOrigem == null || PathDestino == null || FileDestino == null || PathOrigem2 == null || FileOrigem2 == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (PathOrigem == null)
                        erros.Add("Caminho de Origem");
                    if (FileOrigem == null)
                        erros.Add("Ficheiro de Origem");
                    if (PathOrigem2 == null)
                        erros.Add("Segundo Caminho de Origem");
                    if (FileOrigem2 == null)
                        erros.Add("Segundo Ficheiro de Origem");
                    if (PathDestino == null)
                        erros.Add("Caminho de Destino");
                    if (FileDestino == null)
                        erros.Add("Ficheiro de Destino");
                    Erros =string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Cria caminhos
                string caminhoOrigem = Path.Combine(PathOrigem, FileOrigem);
                string caminhoOrigem2 = Path.Combine(PathOrigem2, FileOrigem2);
                string caminhoDestino = Path.Combine(PathDestino, FileDestino);

                //Valida se o caminho é válido
                if (!File.Exists(caminhoOrigem))
                {
                    Mensagem = "Ficheiro não encontrado!";
                    Erros = caminhoOrigem;
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminhoOrigem);
                }
                //Valida se o caminho é válido
                if (!File.Exists(caminhoOrigem2))
                {
                    Mensagem = "Ficheiro não encontrado!";
                    Erros = caminhoOrigem2;
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminhoOrigem2);
                }
                // Abrir ficheiro com o encodeing
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                PdfDocument inputDocument = PdfReader.Open(caminhoOrigem, PdfDocumentOpenMode.Import);
                PdfDocument inputDocument2 = PdfReader.Open(caminhoOrigem2, PdfDocumentOpenMode.Import);

                if (Page > inputDocument2.PageCount || Page <= 0)//página a obter inválida
                {
                    List<string> erros = new List<string>();
                    erros.Add("Número Página");
                    Erros =string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Número da página a adicionar é inválida.", erros);
                }
                else if (AddPosition <= 0 || AddPosition > inputDocument.PageCount + 1) //posição a colocar é inválida
                {
                    List<string> erros = new List<string>();
                    erros.Add("Posição Página");
                    Erros =string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Posição da página a adicionar é inválida.", erros);
                }
                else
                {
                    //Obter página a adicionar
                    PdfPage pageToAdd = inputDocument2.Pages[Page-1];
                    //Inserir página na posição
                    inputDocument.InsertPage(AddPosition - 1, pageToAdd);
                    //gravar documento substituindo
                    inputDocument.Save(caminhoDestino);
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
            }
            catch (DllNotFoundException erro)
            {
                Mensagem = erro.Message;
                throw new DllNotFoundException(erro.Message);
            }
        }
        
        //Propriedades do atributo
        public string PathOrigem
        {
            get => _pathOrigem;
            set => _pathOrigem = value;
        }

        //Propriedades do atributo
        public string FileOrigem
        {
            get => _fileOrigem;
            set => _fileOrigem = value;
        }

        //Propriedades do atributo
        public string PathDestino
        {
            get => _pathDestino;
            set => _pathDestino = value;
        }

        //Propriedades do atributo
        public string FileDestino
        {
            get => _fileDestino;
            set => _fileDestino = value;
        }

        //Propriedades do atributo
        public string PathDestino2 { get; set; }
        
        //Propriedades do atributo
        public string FileDestino2 { get; set; }
        
        //Propriedades do atributo
        public int NumPages { get; set; }

        //Propriedades do atributo
        public string PathOrigem2
        {
            get => _pathOrigem2;
            set => _pathOrigem2 = value;
        }

        //Propriedades do atributo
        public string FileOrigem2
        {
            get => _fileOrigem2;
            set => _fileOrigem2 = value;
        }

        //Propriedades do atributo
        public int Page
        {
            get => _page;
            set => _page = value;
        }

        //Propriedades do atributo
        public string Texto { get; set; }

        //Propriedades do atributo
        public int AddPosition
        {
            get => _addPosition;
            set => _addPosition = value;
        }

        //Propriedades do atributo
        public bool Resultado
        {
            get => _resultado;
            set => _resultado = value;
        }
        
        //Propriedades do atributo
        public string Mensagem
        {
            get=> _mensagem; 
            set => _mensagem = value;
        }

        //Propriedades do atributo
        public string Erros
        {
            get => _erro;
            set=> _erro = value;
        }
    }
}