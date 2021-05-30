using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Scarif_DS_1.exceptions;

namespace Scarif_DS_1.modulos.Split
{
    //Classe da funcionalidade separar ficheiros
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
        private string _mensagem;
        private string _erro;
        
        //Construtor da classe
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
            _erro = null;
            _mensagem = null;
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
        public string PathDestino2
        {
            get => _pathDestino2;
            set => _pathDestino2 = value;
        }

        //Propriedade do atributo
        public string FileDestino2
        {
            get => _fileDestino2;
            set => _fileDestino2 = value;
        }

        //Propriedade do atributo
        public int NumPages { get; set; }

        //Propriedade do atributo
        public int Page
        {
            get => _page;
            set => _page = value;
        }

        //Propriedade do atributo
        public string Texto { get; set; }
        
        //Propriedade do atributo
        public int AddPosition { get; set; }

        //Propriedade do atributo
        public bool Resultado
        {
            get => _resultado;
            set => _resultado = value;
        }

        //Função que executa a funcionalidade
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
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Cria caminhos
                string caminhoOrigem = Path.Combine(PathOrigem, FileOrigem);
                string caminhoDestino = Path.Combine(PathDestino, FileDestino);
                string caminhoDestino2 = Path.Combine(PathDestino2, FileDestino2);

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
                string name = Path.GetFileNameWithoutExtension(caminhoDestino);
                //Verifica se página existe
                if (Page > inputDocument.PageCount || Page <= 0)
                {
                    List<string> erros = new List<string>();
                    erros.Add("Número Página");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
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

                //Percorre ficheiro original e copia páginas para o documento correspondente
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