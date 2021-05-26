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
    public class CreateMod
    {

        public static void SplitDocument(Model modelo)
        {
            try
            {
                //Validar os dados no model
                if (modelo.PathOrigem == null || modelo.FileOrigem == null || modelo.PathDestino == null || modelo.FileDestino == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if (modelo.PathOrigem == null)
                        erros.Add("Caminho de Origem");
                    if (modelo.FileOrigem == null)
                        erros.Add("Ficheiro de Origem");
                    if (modelo.PathDestino == null)
                        erros.Add("Caminho de Destino");
                    if (modelo.FileDestino == null)
                        erros.Add("Ficheiro de Destino");
                    if (modelo.PathDestino2 == null)
                        erros.Add("Segundo Caminho de Destino");
                    if (modelo.FileDestino2 == null)
                        erros.Add("Segundo Ficheiro de Destino");
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa", erros);
                }

                //Cria caminhos
                string caminhoOrigem = Path.Combine(modelo.PathOrigem, modelo.FileOrigem);
                string caminhoDestino = Path.Combine(modelo.PathDestino, modelo.FileDestino);
                string caminhoDestino2 = Path.Combine(modelo.PathDestino2, modelo.FileDestino2);

                //Valida se o caminho é válido
                if (!File.Exists(caminhoOrigem))
                {
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!", caminhoOrigem);
                }
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                // Abrir ficheiro
                PdfDocument inputDocument = PdfReader.Open(caminhoOrigem, PdfDocumentOpenMode.Import);

                string name = Path.GetFileNameWithoutExtension(caminhoDestino);

                if (modelo.Page > inputDocument.PageCount || modelo.Page <= 0)
                {
                    List<string> erros = new List<string>();
                    erros.Add("Número Página");
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

                for (int idx = 0; idx < inputDocument.PageCount; idx++)
                {
                    //cria o primeiro documento com as páginas maiores ou iguais à selecionada
                    if (idx >= modelo.Page)
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
            }
            catch (DllNotFoundException erro)
            {
                throw new DllNotFoundException(erro.Message);

            }
            } } 

}




           