using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Scarif_DS_1.exceptions;

namespace Scarif_DS_1.modulos.Create
{
    //Classe da Funcionalidade criar
    public class CreateMod : IModel
    {
        private string _pathDestino;
        private string _fileDestino;
        private string _texto;
        private string _fonte;
        private string _alinhamento;
        private string _estilo;
        private int _tamanho;
        private bool _resultado;
        private string _mensagem;
        private string _erro;

        //Construtor da Classe
        internal CreateMod(CreateDados dados)
        {
            PathDestino = dados.PathDestino;
            FileDestino = dados.FileDestino;
            Texto = dados.Texto;
            Fonte = dados.Fonte;
            Alinhamento = dados.Alinhamento;
            Estilo = dados.Estilo;
            Tamanho = dados.Tamanho;
            Resultado = false;
            _erro = null;
            _mensagem = null;
        }
        
        //Função que executa funcionalidade
        public void Criar()
        {
            try
            {
                //Validar os dados no model
                if (PathDestino == null || FileDestino == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (PathDestino == null)
                        erros.Add("Caminho de Destino");
                    if (FileDestino == null)
                        erros.Add("Ficheiro de Destino");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Validar os dados no model
                if (Texto == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (Texto == null)
                        erros.Add("Texto Inválido");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Validar os dados no model
                if (Fonte == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (Fonte == null)
                        erros.Add("Fonte Inválida");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Validar os dados no model
                if (Alinhamento == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (Alinhamento == null || (Alinhamento != "Left" && Alinhamento != "Center" && Alinhamento != "Right")) 
                        erros.Add("Alinhamento Inválido");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Validar os dados no model
                if (Tamanho == 0)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (Tamanho == 0) 
                        erros.Add("Tamanho Inválido");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Validar os dados no model
                if (Estilo == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (Estilo == null || (Estilo != "Regular" && Estilo != "Bold" && Estilo != "BoldItalic"
                                           && Estilo != "Italic" && Estilo != "Strikeout" && Estilo != "Underline")) 
                        erros.Add("Estilo Inválido");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Cria o caminho para o endereço
                string caminhoDestino = Path.Combine(PathDestino, FileDestino);
                //Criar o output 
                PdfDocument outputDocument = new PdfDocument();

                //Cria uma página vazia
                PdfPage page = outputDocument.AddPage();
                var gfx = XGraphics.FromPdfPage(page);
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                XFont font = new XFont(Fonte, Tamanho, XFontStyle.Regular);
                // Cria a fonte
                if (Estilo == "Bold")
                {
                    font = new XFont(Fonte, Tamanho, XFontStyle.Bold);
                }
                else if (Estilo == "BoldItalic")
                {
                    font = new XFont(Fonte, Tamanho, XFontStyle.BoldItalic);
                }
                else if (Estilo == "Italic")
                {
                    font = new XFont(Fonte, Tamanho, XFontStyle.Italic);
                }
                else if (Estilo == "Strikeout")
                {
                    font = new XFont(Fonte, Tamanho, XFontStyle.Strikeout);
                }
                else if (Estilo == "Underline")
                {
                    font = new XFont(Fonte, Tamanho, XFontStyle.Underline);
                }
                //Cria alinhamento
                if (Alinhamento == "Left")
                {
                    gfx.DrawString(Texto, font, XBrushes.Black,
                        new XRect(0, 0, page.Width, page.Height),
                        XStringFormats.TopLeft);
                }
                else if (Alinhamento == "Center")
                {
                    gfx.DrawString(Texto, font, XBrushes.Black,
                        new XRect(0, 0, page.Width, page.Height),
                        XStringFormats.TopCenter);
                }
                else if (Alinhamento == "Right")
                {
                    gfx.DrawString(Texto, font, XBrushes.Black,
                        new XRect(0, 0, page.Width, page.Height),
                        XStringFormats.TopRight);
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
        public int Page { get; set; }

        //Propriedade do atributo
        public string Texto
        {
            get => _texto;
            set => _texto = value;
        }

        //Propriedade do atributo
        public int AddPosition { get; set; }

        //Propriedade do atributo
        public string Fonte
        {
            get => _fonte;
            set => _fonte = value;
        }

        //Propriedade do atributo
        public string Alinhamento
        {
            get => _alinhamento;
            set => _alinhamento = value;
        }

        //Propriedade do atributo
        public string Estilo
        {
            get => _estilo;
            set => _estilo = value;
        }

        //Propriedade do atributo
        public int Tamanho
        {
            get => _tamanho;
            set => _tamanho = value;
        }
        
        //Propriedade do atributo
        public string PathOrigem { get; set; }
        
        //Propriedade do atributo
        public string FileOrigem { get; set; }
        
        //Propriedade do atributo
        public string PathOrigem2 { get; set; }

        //Propriedade do atributo
        public bool Resultado
        {
            get => _resultado;
            set => _resultado = value;
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




           