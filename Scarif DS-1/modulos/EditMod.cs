using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using Scarif_DS_1.exceptions;

namespace Scarif_DS_1.modulos
{
    public class EditMod
    {

        public static void RemovePage(Model modelo)
        {
            try { 
                    //Validar os dados no model
                    if (modelo.PathOrigem == null || modelo.FileOrigem == null)
                    {
                        //Cria uma lista com os erros encontrados nos dados
                        List<string> erros = new List<string>();
                        if (modelo.PathOrigem == null)
                            erros.Add("Caminho de Origem");
                        if (modelo.FileOrigem == null)
                            erros.Add("Ficheiro de Origem");
                        throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                    }

                    //Cria caminho
                    string caminho = Path.Combine(modelo.PathOrigem, modelo.FileOrigem);

                    //Valida se o caminho é válido
                    if (!File.Exists(caminho))
                    {
                        throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminho);
                    }

                    
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    // Abrir ficheiro
                    PdfDocument inputDocument = PdfReader.Open(caminho, PdfDocumentOpenMode.Import);

                    if (modelo.Page > inputDocument.PageCount || modelo.Page <= 0)
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
                            if (modelo.Page == idx + 1)
                            {
                                //página a ignorar
                            }
                            else
                            {
                                outputDocument.AddPage(inputDocument.Pages[idx]);
                            }
                        }
                        
                        //gravar documento substituindo
                        outputDocument.Save(caminho);
                        modelo.Resultado = true;
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


        public static void WatermarkFile(Model modelo) {
            try
            {
                //Validar os dados no model
                if (modelo.PathOrigem == null || modelo.FileOrigem == null || modelo.Texto == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (modelo.PathOrigem == null)
                        erros.Add("Caminho de Origem");
                    if (modelo.FileOrigem == null)
                        erros.Add("Ficheiro de Origem");
                    if (modelo.Texto == null)
                        erros.Add("Necessário marca de água");
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Cria caminho
                string caminho = Path.Combine(modelo.PathOrigem, modelo.FileOrigem);

                //Valida se o caminho é válido
                if (!File.Exists(caminho))
                {
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminho);
                }

                //Necessário definir enconding
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                XFont font = new XFont("Arial", 24);

                // Abrir ficheiro
                PdfDocument inputDocument = PdfReader.Open(caminho, PdfDocumentOpenMode.Modify);

                //For each Page in document
                for (int idx = 0; idx < inputDocument.PageCount; idx++)
                {

                    PdfPage page = inputDocument.Pages[idx];
                    // Draw a watermark as a text string.

                    // Get an XGraphics object for drawing beneath the existing content.
                    var gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Prepend);

                    // Get the size (in points) of the text.
                    var size = gfx.MeasureString(modelo.Texto, font);

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
                    gfx.DrawString(modelo.Texto, font, brush,
                        new XPoint((page.Width - size.Width) / 2, (page.Height - size.Height) / 2),
                        format);
                }

                //Gravar documento alterado
                inputDocument.Save(caminho);

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