using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using Scarif_DS_1.exceptions;

namespace Scarif_DS_1.modulos
{
    public class CreateMod
    {
        public static void Alternar(Model modelo)
        {
            try
            {
                //Validar os dados no model
                if (modelo.PathOrigem == null || modelo.FileOrigem == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if(modelo.PathOrigem == null)
                        erros.Add("Caminho de Origem");
                    if(modelo.FileOrigem == null)
                        erros.Add("Ficheiro de Origem");
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                if (modelo.PathOrigem2 == null || modelo.FileOrigem2 == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if(modelo.PathOrigem2 == null)
                        erros.Add("Caminho de Origem");
                    if(modelo.FileOrigem2 == null)
                        erros.Add("Ficheiro de Origem");
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                //Validar os dados no model
                if (modelo.PathDestino == null || modelo.FileDestino == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if(modelo.PathDestino == null)
                        erros.Add("Caminho de Destino");
                    if(modelo.FileDestino == null)
                        erros.Add("Ficheiro de Destino");
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                
                //Cria o caminho para o endereço de origem
                string caminho = Path.Combine(modelo.PathOrigem, modelo.FileOrigem);
                //Valida se o caminho é válido
                if (!File.Exists(caminho))
                {
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!",caminho);
                }
                
                //Cria o caminho para o endereço de origem
                string caminho2 = Path.Combine(modelo.PathOrigem2, modelo.FileOrigem2);
                //Valida se o caminho é válido
                if (!File.Exists(caminho))
                {
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!",caminho);
                }
                
                //Cria o caminho para o endereço
                string caminhoDestino = Path.Combine(modelo.PathDestino, modelo.FileDestino);
                //Abrir o ficheiro
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                PdfDocument ficheiro1 = PdfReader.Open(caminho, PdfDocumentOpenMode.Import);
                PdfDocument ficheiro2 = PdfReader.Open(caminho2, PdfDocumentOpenMode.Import);
 
                //Criar o output 
                PdfDocument outputDocument = new PdfDocument();
                outputDocument.PageLayout = PdfPageLayout.TwoColumnLeft;
                int count = Math.Max(ficheiro1.PageCount, ficheiro2.PageCount);
                for (int idx = 0; idx < count; idx++)
                {
                    // Obter pagina do ficheiro 1
                    PdfPage page1 = ficheiro1.PageCount > idx ?
                        ficheiro1.Pages[idx] : new PdfPage();
 
                    // obter pagina do ficheiro 2
                    PdfPage page2 = ficheiro2.PageCount > idx ?
                        ficheiro2.Pages[idx] : new PdfPage();
                    //Adicionar paginas ao documento de output
                    page1 = outputDocument.AddPage(page1);
                    page2 = outputDocument.AddPage(page2);
                }
                //salvar documento
                outputDocument.Save(caminhoDestino);
                modelo.Resultado = true;
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
    
          public static void Concatenar(Model modelo)
        {
            try
            {
                //Validar os dados no model
                if (modelo.PathOrigem == null || modelo.FileOrigem == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if(modelo.PathOrigem == null)
                        erros.Add("Caminho de Origem");
                    if(modelo.FileOrigem == null)
                        erros.Add("Ficheiro de Origem");
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                if (modelo.PathOrigem2 == null || modelo.FileOrigem2 == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if(modelo.PathOrigem2 == null)
                        erros.Add("Caminho de Origem");
                    if(modelo.FileOrigem2 == null)
                        erros.Add("Ficheiro de Origem");
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                //Validar os dados no model
                if (modelo.PathDestino == null || modelo.FileDestino == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if(modelo.PathDestino == null)
                        erros.Add("Caminho de Destino");
                    if(modelo.FileDestino == null)
                        erros.Add("Ficheiro de Destino");
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                
                //Cria o caminho para o endereço de origem
                string caminho = Path.Combine(modelo.PathOrigem, modelo.FileOrigem);
                //Valida se o caminho é válido
                if (!File.Exists(caminho))
                {
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!",caminho);
                }
                
                //Cria o caminho para o endereço de origem
                string caminho2 = Path.Combine(modelo.PathOrigem2, modelo.FileOrigem2);
                //Valida se o caminho é válido
                if (!File.Exists(caminho))
                {
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!",caminho);
                }
                
                //Cria o caminho para o endereço
                string caminhoDestino = Path.Combine(modelo.PathDestino, modelo.FileDestino);
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
                modelo.Resultado = true;
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

