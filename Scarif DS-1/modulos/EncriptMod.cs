using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using Scarif_DS_1.exceptions;

namespace Scarif_DS_1.modulos
{
    public class EncriptMod
    {
        public static void EncriptarMod(Model modelo)
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
                //Validar os dados no model
                if (modelo.Senha == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    erros.Add("Senha não encontrada!");
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                //Cria o caminho para o endereço de origem
                string caminho = Path.Combine(modelo.PathOrigem, modelo.FileOrigem);
                //Valida se o caminho é válido
                if (!File.Exists(caminho))
                {
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!",caminho);
                }
                //Cria o caminho para o endereço
                string caminhoDestino = Path.Combine(modelo.PathDestino, modelo.FileDestino);
                //Abrir o ficheiro
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                PdfDocument ficheiro = PdfReader.Open(caminho, PdfDocumentOpenMode.Modify);
                //Criar os privilegios do ficheiro
                PdfSecuritySettings privilegios = ficheiro.SecuritySettings;
                //Define os privilégios do ficheiro
                privilegios.UserPassword  = modelo.Senha;
                privilegios.OwnerPassword = "";
                privilegios.PermitAccessibilityExtractContent = false;
                privilegios.PermitAnnotations = false;
                privilegios.PermitAssembleDocument = false;
                privilegios.PermitExtractContent = false;
                privilegios.PermitFormsFill = true;
                privilegios.PermitFullQualityPrint = false;
                privilegios.PermitModifyDocument = true;
                privilegios.PermitPrint = false;
                //Salva o ficheiro no destino
                ficheiro.Save(caminhoDestino); 
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
        
        public static void DecriptarMod(Model modelo)
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
                //Validar os dados no model
                if (modelo.Senha == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    erros.Add("Senha não encontrada!");
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                //Cria o caminho para o endereço de origem
                string caminho = Path.Combine(modelo.PathOrigem, modelo.FileOrigem);
                //Valida se o caminho é válido
                if (!File.Exists(caminho))
                {
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!",caminho);
                }
                //Cria o caminho para o endereço
                string caminhoDestino = Path.Combine(modelo.PathDestino, modelo.FileDestino);
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                PdfDocument ficheiro;
                try
                {
                    ficheiro = PdfReader.Open(caminho, modelo.Senha);
                }
                catch (Exception ex)
                {
                    List<string> erros = new List<string>();
                    erros.Add("Senha não Corresponde!");
                    throw new ExceptionDadosInvalidos("Ficheiro não está disponivel!", erros);
                }
                ficheiro = PdfReader.Open(caminho, modelo.Senha, PdfDocumentOpenMode.Modify);
                PdfDocumentSecurityLevel level = ficheiro.SecuritySettings.DocumentSecurityLevel;
                ficheiro.Save(caminhoDestino);
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