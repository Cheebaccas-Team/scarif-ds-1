using System;
using Scarif_DS_1.exceptions;
using Scarif_DS_1.modulos;
using Scarif_DS_1.modulos.AddPage;
using Scarif_DS_1.modulos.Count;
using Scarif_DS_1.modulos.Create;
using Scarif_DS_1.modulos.Encript;
using Scarif_DS_1.modulos.RemovePage;
using Scarif_DS_1.modulos.Split;
using Scarif_DS_1.modulos.Union;
using Scarif_DS_1.modulos.WaterMark;
using Scarif_DS_1.ui;

namespace Scarif_DS_1
{
    public class Controller
    {
        private IModel _modelo;
        private IView _ui;
        private bool _executar;
        private OpcoesExecucao _opcao;

        public delegate void EfetuarProcessamento();
        
        //Construtor do Controlador
        internal Controller()
        {
            _modelo = null;
            _ui = new Consola(_modelo, this);
            Opcao = OpcoesExecucao.Vazio;
        }

        public void IniciarPrograma()
        {
            _ui.AtivarInterface();
            Executar = true;
            while(Executar){
                _ui.DisponibilizarOpcoes();
                if(Opcao!= OpcoesExecucao.Vazio)
                    _ui.ProcessarDados(Opcao);
            }
            _ui.EncerrarPrograma();
        }

        //Função que permite atualizar os dados do modelo
        public void SubmeterDados(IDados dados, OpcoesExecucao operacao)
        {
            try
            {
                if (dados.Tipo == TipoDados.Count)
                {
                    _modelo = new CountMod((CountDados) dados);
                }
                else if (dados.Tipo == TipoDados.Alternate)
                {
                    _modelo = new Union((UnionDados) dados);
                }
                else if (dados.Tipo == TipoDados.Concat)
                {
                    _modelo = new Union((UnionDados) dados);
                }
                else if (dados.Tipo == TipoDados.Create)
                {
                    _modelo = new CreateMod((CreateDados) dados);
                }
                else if (dados.Tipo == TipoDados.Protect)
                {
                    _modelo = new EncriptMod((EncriptDados) dados);
                }
                else if (dados.Tipo == TipoDados.Split)
                {
                    _modelo = new SplitMod((SplitDados) dados);
                }
                else if (dados.Tipo == TipoDados.Unprotect)
                {
                    _modelo = new EncriptMod((EncriptDados) dados);
                }
                else if (dados.Tipo == TipoDados.AddPage)
                {
                    _modelo = new AddPageMod((AddPageDados) dados);
                }
                else if (dados.Tipo == TipoDados.RemovePage)
                {
                    _modelo = new RemoveMod((RemoveDados) dados);
                }
                else if (dados.Tipo == TipoDados.WaterMark)
                {
                    _modelo = new WaterMarkMod((WaterMarkDados) dados);
                }
                _ui.Modelo = _modelo;
                Opcao = operacao;
            }
            catch (ExceptionFileNotFound erro)
            {
                throw new ExceptionFileNotFound(erro);
            }
            catch (ExceptionDadosInvalidos erro)
            {
                throw new ExceptionDadosInvalidos(erro);
            }
            catch (DllNotFoundException erro)
            {
                throw new DllNotFoundException(erro.Message);
            }
        }
        
        //Função que executa a funcionalidade
        public void ProcessarDados(OpcoesExecucao op)
        {
            EfetuarProcessamento efetuarProcesso = null;
            try
            {
                switch (op)
                {
                    case OpcoesExecucao.ContarPaginas:
                        efetuarProcesso= ((CountMod)_modelo).ContarPaginas;
                        break;
                    case OpcoesExecucao.RemoverPagina:
                        efetuarProcesso= ((RemoveMod) _modelo).RemovePage;
                        break;
                    case OpcoesExecucao.AdicionarMarca:
                        efetuarProcesso = ((WaterMarkMod) _modelo).WatermarkFile;
                        break;
                    case OpcoesExecucao.AdicionarPagina:
                        efetuarProcesso = ((AddPageMod) _modelo).AddPage;
                        break;
                    case OpcoesExecucao.Encriptar:
                        efetuarProcesso = ((EncriptMod) _modelo).EncriptarMod;
                        break;
                    case OpcoesExecucao.Decriptar:
                        efetuarProcesso = ((EncriptMod) _modelo).DecriptarMod;
                        break;
                    case OpcoesExecucao.Concatenar:
                        efetuarProcesso = ((Union) _modelo).Concatenar;
                        break;
                    case OpcoesExecucao.Unir:
                        efetuarProcesso = ((Union) _modelo).Alternar;
                        break;
                    case OpcoesExecucao.Criar:
                        efetuarProcesso = ((CreateMod) _modelo).Criar;
                        break;
                    case OpcoesExecucao.SepararFicheiro:
                        efetuarProcesso = ((SplitMod) _modelo).SplitDocument;
                        break;
                }
                efetuarProcesso.Invoke();
            }
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
        public bool Executar
        {
            get => _executar;
            set => _executar = value;
        }

        public OpcoesExecucao Opcao
        {
            get => _opcao;
            set => _opcao = value;
        }
    }
}