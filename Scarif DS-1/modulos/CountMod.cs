using System;
using System.Collections.Generic;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace Scarif_DS_1
{
    public class CountMod
    {
        public static void ProcessarDados(Model modelo)
        {
            try
            {
                if (modelo.PathOrigem == null || modelo.FileOrigem == null)
                {
                    List<string> erros = new List<string>();
                    if(modelo.PathOrigem == null)
                        erros.Add("Caminho de Origem");
                    if(modelo.FileOrigem == null)
                        erros.Add("Ficheiro de Origem");
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                string caminho = Path.Combine(modelo.PathOrigem, modelo.FileOrigem);
                if (!File.Exists(caminho))
                {
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!",caminho);
                }
                //Devolve o número de páginas que o ficheiro PDF indicado tem
                modelo.NumPages = 0;
                // Open the file
                PdfDocument inputDocument = PdfReader.Open(caminho,PdfDocumentOpenMode.Import);
                modelo.NumPages = inputDocument.PageCount;
            }
            catch (ExceptionDadosInvalidos erro)
            {
                Console.WriteLine("Erro: " + erro.Message + " [" + erro.ListaErros()+"]");
            }
            catch (ExceptionFileNotFound erro)
            {
                Console.WriteLine("Erro: " + erro.Message + " [" + erro.Ficheiro+"]");
            }
        }

    }
}