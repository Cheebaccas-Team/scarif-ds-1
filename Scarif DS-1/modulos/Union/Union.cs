using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Scarif_DS_1.exceptions;

namespace Scarif_DS_1.modulos.Union
{
    //Classe da funcionalidade de União de ficheiros
    public class Union : IModel
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private string _pathOrigem2;
        private string _fileOrigem2;
        private string _pathDestino;
        private string _fileDestino;
        private bool _resultado;
        private string _mensagem;
        private string _erro;

        //Construtor da classe
        internal Union(UnionDados dados)
        {
            PathOrigem = dados.PathOrigem;
            FileOrigem = dados.FileOrigem;
            PathOrigem2 = dados.PathOrigem2;
            FileOrigem2 = dados.FileOrigem2;
            PathDestino = dados.PathDestino;
            FileDestino = dados.FileDestino;
            _resultado = false;
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
        public string PathOrigem2
        {
            get => _pathOrigem2;
            set => _pathOrigem2 = value;
        }

        //Propriedade do atributo
        public string FileOrigem2
        {
            get => _fileOrigem2;
            set => _fileOrigem2 = value;
        }

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
        public int Page { get; set; }
        
        //Propriedade do atributo
        public string Texto { get; set; }

        //Função que executa funcionalidade de união alternada
        public void Alternar()
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
                    Erros =string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Validar os dados do model
                if (PathOrigem2 == null || FileOrigem2 == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (PathOrigem2 == null)
                        erros.Add("Caminho de Origem");
                    if (FileOrigem2 == null)
                        erros.Add("Ficheiro de Origem");
                    Erros =string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Validar os dados no model
                if (PathDestino == null || FileDestino == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (PathDestino == null)
                        erros.Add("Caminho de Destino");
                    if (FileDestino == null)
                        erros.Add("Ficheiro de Destino");
                    Erros =string.Join(", ", erros);;
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Cria o caminho para o endereço de origem
                string caminho = Path.Combine(PathOrigem, FileOrigem);
                //Valida se o caminho é válido
                if (!File.Exists(caminho))
                {
                    Mensagem = "Ficheiro não encontrado!";
                    Erros = caminho;
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminho);
                }

                //Cria o caminho para o endereço de origem
                string caminho2 = Path.Combine(PathOrigem2, FileOrigem2);
                //Valida se o caminho é válido
                if (!File.Exists(caminho2))
                {
                    Mensagem = "Ficheiro não encontrado!";
                    Erros = caminho2;
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminho);
                }

                //Cria o caminho para o endereço
                string caminhoDestino = Path.Combine(PathDestino, FileDestino);
                //Abrir o ficheiro
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                PdfDocument ficheiro1 = PdfReader.Open(caminho, PdfDocumentOpenMode.Import);
                PdfDocument ficheiro2 = PdfReader.Open(caminho2, PdfDocumentOpenMode.Import);

                //Criar o output 
                PdfDocument outputDocument = new PdfDocument();
                outputDocument.PageLayout = PdfPageLayout.TwoColumnLeft;
                int count = Math.Max(ficheiro1.PageCount, ficheiro2.PageCount);
                //Percorre o documento original e copia a página  para o novo documento
                for (int idx = 0; idx < count; idx++)
                {
                    // Obter pagina do ficheiro 1
                    PdfPage page1 = ficheiro1.PageCount > idx ? ficheiro1.Pages[idx] : new PdfPage();

                    // obter pagina do ficheiro 2
                    PdfPage page2 = ficheiro2.PageCount > idx ? ficheiro2.Pages[idx] : new PdfPage();
                    //Adicionar paginas ao documento de output
                    page1 = outputDocument.AddPage(page1);
                    page2 = outputDocument.AddPage(page2);
                }
                //salvar documento
                outputDocument.Save(caminhoDestino);
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

        //Função que executa funcionalidade de união seguida
        public void Concatenar()
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
                    Erros =string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Validar os dados no model
                if (PathOrigem2 == null || FileOrigem2 == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (PathOrigem2 == null)
                        erros.Add("Caminho de Origem");
                    if (FileOrigem2 == null)
                        erros.Add("Ficheiro de Origem");
                    Erros =string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Validar os dados no model
                if (PathDestino == null || FileDestino == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (PathDestino == null)
                        erros.Add("Caminho de Destino");
                    if (FileDestino == null)
                        erros.Add("Ficheiro de Destino");
                    Erros =string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Cria o caminho para o endereço de origem
                string caminho = Path.Combine(PathOrigem, FileOrigem);
                //Valida se o caminho é válido
                if (!File.Exists(caminho))
                {
                    Mensagem = "Ficheiro não encontrado!";
                    Erros = caminho;
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminho);
                }

                //Cria o caminho para o endereço de origem
                string caminho2 = Path.Combine(PathOrigem2, FileOrigem2);
                //Valida se o caminho é válido
                if (!File.Exists(caminho2))
                {
                    Mensagem = "Ficheiro não encontrado!";
                    Erros = caminho2;
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminho);
                }

                //Cria o caminho para o endereço
                string caminhoDestino = Path.Combine(PathDestino, FileDestino);
                //Abrir o ficheiro
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                // Criar o documento de output
                PdfDocument outputDocument = new PdfDocument();
                //Abrir o documento e importar paginas deste
                PdfDocument inputDocument = PdfReader.Open(caminho, PdfDocumentOpenMode.Import);

                // Adicionar paginas do ficheiro 1
                int count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    // obtem a pagina do ficheiro de input e adiciona no ficheiro de output
                    PdfPage page = inputDocument.Pages[idx];
                    // ...and add it to the output document.
                    outputDocument.AddPage(page);
                }

                //Adicionar paginas do ficheiro 2
                inputDocument = PdfReader.Open(caminho2, PdfDocumentOpenMode.Import);
                count = inputDocument.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    // obtem a pagina do ficheiro de input e adiciona no ficheiro de output
                    PdfPage page = inputDocument.Pages[idx];
                    outputDocument.AddPage(page);
                }

                //salvar documento
                outputDocument.Save(caminhoDestino);
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