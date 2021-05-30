using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Scarif_DS_1.exceptions;

namespace Scarif_DS_1.modulos.WaterMark
{
    public class WaterMarkMod : IModel
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private string _pathDestino;
        private string _fileDestino;
        private string _texto;
        private bool _resultado;
        private string _mensagem;
        private string _erro;

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
        public int Page { get; set; }

        public string Texto
        {
            get => _texto;
            set => _texto = value;
        }

        public int AddPosition { get; set; }

        internal WaterMarkMod(WaterMarkDados dados)
        {
            PathOrigem = dados.PathOrigem;
            FileOrigem = dados.FileOrigem;
            PathDestino = dados.PathDestino;
            FileDestino = dados.FileDestino;
            Texto = dados.Texto;
            _erro = null;
            _mensagem = null;
        }
        
        public void WatermarkFile() { 
            try
            { 
                //Validar os dados no model
                if (PathOrigem == null || FileOrigem == null || Texto == null || PathDestino == null || FileDestino == null )
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (PathOrigem == null)
                        erros.Add("Caminho de Origem");
                    if (FileOrigem == null)
                        erros.Add("Ficheiro de Origem");
                    if (Texto == null)
                        erros.Add("Necessário marca de água");
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
                string caminhoDestino = Path.Combine(PathDestino, FileDestino);
        
                //Valida se o caminho é válido
                if (!File.Exists(caminhoOrigem))
                {
                    Mensagem = "Ficheiro não encontrado!";
                    Erros = caminhoOrigem;
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminhoOrigem);
                }
        
                //Necessário definir enconding
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                XFont font = new XFont("Arial", 24);
                // Abrir ficheiro
                PdfDocument inputDocument = PdfReader.Open(caminhoOrigem, PdfDocumentOpenMode.Modify);
                //For each Page in document
                for (int idx = 0; idx < inputDocument.PageCount; idx++)
                {
                    PdfPage page = inputDocument.Pages[idx];
                    // Draw a watermark as a text string.
                    // Get an XGraphics object for drawing beneath the existing content.
                    var gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Prepend);
                    // Get the size (in points) of the text.
                    var size = gfx.MeasureString(Texto, font);
                    // Define a rotation transformation at the center of the page.
                    gfx.TranslateTransform(page.Width / 2, page.Height / 2);
                    gfx.RotateTransform(-Math.Atan(page.Height / page.Width) * 180 / Math.PI);
                    gfx.TranslateTransform(-page.Width / 2, -page.Height / 2);
                    // Create a string format.
                    var format = new XStringFormat();
                    format.Alignment = XStringAlignment.Near;
                    format.LineAlignment = XLineAlignment.Near;
                    // Create a dimmed red brush.
                    XBrush brush = new XSolidBrush(XColor.FromArgb(128, 255, 0, 0));
                    // Draw the string
                    gfx.DrawString(Texto, font, brush,
                        new XPoint((page.Width - size.Width) / 2, (page.Height - size.Height) / 2),
                        format);
                }
                //Gravar documento alterado
                inputDocument.Save(caminhoDestino);
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
            }catch (DllNotFoundException erro)
            {
                Mensagem = erro.Message;
                throw new DllNotFoundException(erro.Message);
            }
        }
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