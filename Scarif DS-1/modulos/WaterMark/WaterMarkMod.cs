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
    //Classer da funcionalidade Marca de Agua
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
        public int Page { get; set; }

        //Propriedade do atributo
        public string Texto
        {
            get => _texto;
            set => _texto = value;
        }

        //Propriedade do atributo
        public int AddPosition { get; set; }

        //Construtor da Classe
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
        
        //Função que executa a funcionalidade 
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
                //Abrir ficheiro
                PdfDocument inputDocument = PdfReader.Open(caminhoOrigem, PdfDocumentOpenMode.Modify);
                //Percorre documento original
                for (int idx = 0; idx < inputDocument.PageCount; idx++)
                {
                    PdfPage page = inputDocument.Pages[idx];
                    //Cria as propriedades da marca de agua
                    var gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Prepend);
                    var size = gfx.MeasureString(Texto, font);
                    gfx.TranslateTransform(page.Width / 2, page.Height / 2);
                    gfx.RotateTransform(-Math.Atan(page.Height / page.Width) * 180 / Math.PI);
                    gfx.TranslateTransform(-page.Width / 2, -page.Height / 2);
                    var format = new XStringFormat();
                    format.Alignment = XStringAlignment.Near;
                    format.LineAlignment = XLineAlignment.Near;
                    XBrush brush = new XSolidBrush(XColor.FromArgb(128, 255, 0, 0));
                    //Adiciona a marca de água
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
        
        //Propriedade do atributo
        public bool Resultado { get => _resultado; set => _resultado = value; }
        
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