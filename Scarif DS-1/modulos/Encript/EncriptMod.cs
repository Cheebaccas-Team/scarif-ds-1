using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using Scarif_DS_1.exceptions;

namespace Scarif_DS_1.modulos.Encript
{
    //Classe da funcionalidade Encriptar/Decriptar
    public class EncriptMod : IModel
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private string _pathDestino;
        private string _fileDestino;
        private string _senha;
        private bool _resultado;
        private string _mensagem;
        private string _erro;

        //Construtor da Classe
        internal EncriptMod(EncriptDados dados)
        {
            PathOrigem = dados.PathOrigem;
            FileOrigem = dados.FileOrigem;
            PathDestino = dados.PathDestino;
            FileDestino = dados.FileDestino;
            Senha = dados.Senha;
            Resultado = false;
            _erro = null;
            _mensagem = null;
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
        public string Texto { get; set; }
        
        //Propriedade do atributo
        public int AddPosition { get; set; }

        //Propriedade do atributo
        public string Senha
        {
            get => _senha;
            set => _senha = value;
        }

        //Propriedade do atributo
        public bool Resultado
        {
            get => _resultado;
            set => _resultado = value;
        }

        //Função que executa funcionalidade de encriptar
        public void EncriptarMod()
        {
            try
            {
                //Validar os dados no model
                if (PathOrigem == null || FileOrigem == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if(PathOrigem == null)
                        erros.Add("Caminho de Origem");
                    if(FileOrigem == null)
                        erros.Add("Ficheiro de Origem");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                //Validar os dados no model
                if (PathDestino == null || FileDestino == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if(PathDestino == null)
                        erros.Add("Caminho de Destino");
                    if(FileDestino == null)
                        erros.Add("Ficheiro de Destino");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                //Validar os dados no model
                if (Senha == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    erros.Add("Senha não encontrada!");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                //Cria o caminho para o endereço de origem
                string caminho = Path.Combine(PathOrigem, FileOrigem);
                //Valida se o caminho é válido
                if (!File.Exists(caminho))
                {
                    Mensagem = "Ficheiro não encontrado!";
                    Erros = caminho;
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!",caminho);
                }
                //Cria o caminho para o endereço
                string caminhoDestino = Path.Combine(PathDestino, FileDestino);
                //Abrir o ficheiro
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                PdfDocument ficheiro = PdfReader.Open(caminho, PdfDocumentOpenMode.Modify);
                //Criar os privilegios do ficheiro
                PdfSecuritySettings privilegios = ficheiro.SecuritySettings;
                //Define os privilégios do ficheiro
                privilegios.UserPassword  = Senha;
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
        
        //Função que executa funcionalidade de remover encriptação
        public void DecriptarMod()
        {
            try
            {
                //Validar os dados no model
                if (PathOrigem == null || FileOrigem == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if(PathOrigem == null)
                        erros.Add("Caminho de Origem");
                    if(FileOrigem == null)
                        erros.Add("Ficheiro de Origem");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                //Validar os dados no model
                if (PathDestino == null || FileDestino == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    if(PathDestino == null)
                        erros.Add("Caminho de Destino");
                    if(FileDestino == null)
                        erros.Add("Ficheiro de Destino");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                //Validar os dados no model
                if (Senha == null)
                {
                    //Cria uma lista com os erros encontrados nos dados
                    List<string> erros = new List<string>();
                    erros.Add("Senha não encontrada!");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Faltam Dados para concluir a tarefa",erros);
                }
                //Cria o caminho para o endereço de origem
                string caminho = Path.Combine(PathOrigem, FileOrigem);
                //Valida se o caminho é válido
                if (!File.Exists(caminho))
                {
                    Mensagem = "Ficheiro não encontrado!";
                    Erros = caminho;
                    throw new ExceptionFileNotFound("Ficheiro não encontrado!",caminho);
                }
                //Cria o caminho para o endereço
                string caminhoDestino = Path.Combine(PathDestino, FileDestino);
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                //Verifica se ficheiro possui a senha indicada
                PdfDocument ficheiro;
                try
                {
                    ficheiro = PdfReader.Open(caminho, Senha);
                }
                catch (Exception)
                {
                    List<string> erros = new List<string>();
                    erros.Add("Senha não Corresponde!");
                    Erros = string.Join(", ", erros);
                    Mensagem = "Faltam Dados para concluir a tarefa";
                    throw new ExceptionDadosInvalidos("Ficheiro não está disponivel!", erros);
                }
                //Modifica o ficheiro removendo a senha
                ficheiro = PdfReader.Open(caminho, Senha, PdfDocumentOpenMode.Modify);
                PdfDocumentSecurityLevel level = ficheiro.SecuritySettings.DocumentSecurityLevel;
                ficheiro.Save(caminhoDestino);
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