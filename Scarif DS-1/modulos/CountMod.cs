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
                //Cria o caminho para o endereço
                string caminho = Path.Combine(modelo.PathOrigem, modelo.FileOrigem);
                //Valida se o caminho é válido
                if (!File.Exists(caminho))
                {
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!",caminho);
                }
                //Inicializa o valor de quantidade de páginas no modelo
                modelo.NumPages = 0;
                //Abre o ficheiro para analisar
                PdfDocument inputDocument = PdfReader.Open(caminho,PdfDocumentOpenMode.Import);
                //Atualiza valor de quantidade de páginas no modelo com a quantidade de páginas calculadas do ficheiro
                modelo.NumPages = inputDocument.PageCount;
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
        }

    }
}