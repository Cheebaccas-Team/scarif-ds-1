using System;
using Scarif_DS_1.exceptions;
using Scarif_DS_1.modulos;

namespace Scarif_DS_1.ui
{
    public class Consola : IView
    {
        //Construtor da Interface de Terminal
        internal Consola(Model modelo, Controller controlo)
        {
            ((IView) this).Controlador = controlo;
            ((IView) this).Modelo = modelo;
        }

        //Propriedades (getter e setter) do Controlador
        Controller IView.Controlador { get; set; }

        //Propriedades (getter e setter) do Modelo
        Model IView.Modelo { get; set; }

        //Ativar a Interface
        public void AtivarInterface()
        {
            Console.WriteLine("Obrigado por utilizar o nosso Software!");
        }

        //Disponibilizar as opções do menu principal
        public void DisponibilizarOpcoes()
        {
            int opcao;
            do
            {
                Console.WriteLine("Qual a tarefa que pretende executar?");
                Console.WriteLine("1 - Editar Ficheiros");
                Console.WriteLine("2 - Criar Ficheiro");
                Console.WriteLine("3 - Proteção Ficheiros");
                Console.WriteLine("4 - Outras Funções");
                Console.WriteLine("Escolha 0 para sair!");
                Console.Write("Opção: ");
                
                    opcao = Int32.Parse(Console.ReadLine());
                if (opcao < 0 || opcao > 4)
                    Console.WriteLine("Opção Inválida! Escolha novamente.");
            } while (opcao < 0 || opcao > 4);
            switch (opcao)
            {
                case (int) OpcoesMenuPrincipal.Editar:
                    OpcaoEdit();
                    break;
                case (int) OpcoesMenuPrincipal.Criar:
                    OpcaoCriar();
                    break;
                case (int) OpcoesMenuPrincipal.Proteger:
                    OpcaoProteger();
                    break;
                case (int) OpcoesMenuPrincipal.Outra:
                    OpcaoOutra();
                    break;
                case (int) OpcoesMenuPrincipal.Sair:
                    ((IView) this).Controlador.Executar = false;
                    break;
            }
        }

        //Disponibilizar as opções do Menu de Edição
        private void OpcaoEdit()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar Página");
                Console.WriteLine("2 - Remover Página");
                Console.WriteLine("3 - Unir Ficheiros - Concatenar");
                Console.WriteLine("4 - Unir Ficheiros - Alternado");
                Console.WriteLine("5 - Separar Ficheiros");
                Console.WriteLine("6 - Marca de Água");
                Console.WriteLine("Escolha 0 para voltar!");
                opcao = Int32.Parse(Console.ReadLine());
                if (opcao < 0 || opcao > 6)
                    Console.WriteLine("Opção Inválida! Escolha novamente.");
            } while (opcao < 0 || opcao > 6);

            switch (opcao)
            {
                case (int) OpcoesMenuEdit.Adicionar:
                    MenuAdicionar();
                    break;
                case (int) OpcoesMenuEdit.Remover:
                    MenuRemover();
                    break;
                case (int) OpcoesMenuEdit.Alternar:
                    MenuUnir(OpcoesExecucao.Unir);
                    break;
                case (int) OpcoesMenuEdit.Concatenar:
                    MenuUnir(OpcoesExecucao.Concatenar);
                    break;
                case (int) OpcoesMenuEdit.Separar:
                    MenuSeparar();
                    break;
                case (int) OpcoesMenuEdit.MarcaAgua:
                    MenuMarcaAgua();
                    break;
                case (int) OpcoesMenuEdit.Sair:
                    Console.Clear();
                    break;
            }
        }

        private void OpcaoCriar()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Criar Ficheiro");
                Console.WriteLine("Escolha 0 para voltar!");
                opcao = Int32.Parse(Console.ReadLine());
                if (opcao < 0 || opcao > 1)
                    Console.WriteLine("Opção Inválida! Escolha novamente.");
            } while (opcao < 0 || opcao > 1);
            switch (opcao)
            {
                case (int) OpcoesMenuCriar.Criar:
                    MenuCriar();
                    break;
                case (int) OpcoesMenuCriar.Sair:
                    Console.Clear();
                    break;
            }
        }

        private void OpcaoProteger()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar Encriptação");
                Console.WriteLine("2 - Remover Encriptação");
                Console.WriteLine("Escolha 0 para voltar!");
                opcao = Int32.Parse(Console.ReadLine());
                if (opcao < 0 || opcao > 2)
                    Console.WriteLine("Opção Inválida! Escolha novamente.");
            } while (opcao < 0 || opcao > 2);
            switch (opcao)
            {
                case (int) OpcoesMenuEncriptar.Adicionar:
                    MenuAdicionarEncriptar();
                    break;
                case (int) OpcoesMenuEncriptar.Remover:
                    MenuRemoverEncriptacao();
                    break;
                case (int) OpcoesMenuEncriptar.Sair:
                    Console.Clear();
                    break;
            }
        }

        //Disponibiliza as opções do Menu de Outras Tarefas
        private void OpcaoOutra()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Contar Páginas");
                Console.WriteLine("Escolha 0 para voltar!");
                opcao = Int32.Parse(Console.ReadLine());
                if (opcao < 0 || opcao > 1)
                    Console.WriteLine("Opção Inválida! Escolha novamente.");
            } while (opcao < 0 || opcao > 1);

            switch (opcao)
            {
                case (int) OpcoesMenuOutra.Contar:
                    MenuContar();
                    break;
                case (int) OpcoesMenuOutra.Sair:
                    Console.Clear();
                    break;
            }
        }

        //Executa função de Contar páginas
        private void MenuContar()
        {
            string caminhoOrigem;
            bool continuar = true;
            do
            {
                //Limpa o terminal
                Console.Clear();
                try
                {
                    //Solicita os dados ao utilizador
                    caminhoOrigem = this.caminhoOrigem();
                    //Submete os dados no controlador
                    ((IView) this).Controlador.SubmeterDados(caminhoOrigem, TipoDados.CaminhoOrigem);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    ProcessarDados(OpcoesExecucao.ContarPaginas);
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.ListaErros());
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.Ficheiro);
                }
                catch (DllNotFoundException erro)
                {
                    Console.WriteLine("Erro: {0}", erro.Message);
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao != null && opcao.ToUpper() != "S" && opcao.ToUpper() != "SIM")
                    continuar = false;
            } while (continuar);
            Console.Clear();
        }

        //Executa função de Remover página
        private void MenuRemover()
        {
            string caminhoOrigem;
            string caminhoDestino;
            int pagina;
            bool continuar = true;
            do
            {
                //Limpa o terminal
                Console.Clear();
                //Solicita os dados ao utilizador
                caminhoOrigem = this.caminhoOrigem();
                caminhoDestino = this.caminhoDestino(caminhoOrigem);
                Console.WriteLine("Indique o número da página a remover");
                pagina = Convert.ToInt32(Console.ReadLine());
                //Submete os dados no controlador
                try
                {
                    ((IView) this).Controlador.SubmeterDados(caminhoOrigem, TipoDados.CaminhoOrigem);
                    ((IView) this).Controlador.SubmeterDados(caminhoDestino, TipoDados.CaminhoDestino);
                    ((IView) this).Controlador.SubmeterDados(pagina, TipoDados.Pagina);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    ProcessarDados(OpcoesExecucao.RemoverPagina);
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.ListaErros());
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.Ficheiro);
                }catch (DllNotFoundException erro)
                {
                    Console.WriteLine("Erro: {0}", erro.Message);
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao != null && opcao.ToUpper() != "S" && opcao.ToUpper() != "SIM")
                    continuar = false;
            } while (continuar);
            Console.Clear();
        }

        //Executa função de Marca Água
        private void MenuMarcaAgua()
        {
            string caminhoOrigem;
            string caminhoDestino;
            string marcaAgua;
            bool continuar = true;
            do
            {
                //Limpa o terminal
                Console.Clear();
                //Solicita os dados ao utilizador
                caminhoOrigem = this.caminhoOrigem();
                //Questiona se ficheiro é para substituir
                caminhoDestino = this.caminhoDestino(caminhoOrigem);
                Console.WriteLine("Indique o texto a colocar como Marca de Água");
                marcaAgua = Console.ReadLine();
                try
                {
                    //Submete os dados no controlador
                    ((IView) this).Controlador.SubmeterDados(caminhoOrigem, TipoDados.CaminhoOrigem);
                    ((IView) this).Controlador.SubmeterDados(caminhoDestino, TipoDados.CaminhoDestino);
                    ((IView) this).Controlador.SubmeterDados(marcaAgua, TipoDados.Texto);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    ProcessarDados(OpcoesExecucao.AdicionarMarca);
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.ListaErros());
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.Ficheiro);
                }catch (DllNotFoundException erro)
                {
                    Console.WriteLine("Erro: {0}", erro.Message);
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao != null && opcao.ToUpper() != "S" && opcao.ToUpper() != "SIM")
                    continuar = false;
            } while (continuar);
            Console.Clear();
        }

        private void MenuAdicionarEncriptar()
        {
            string caminhoOrigem;
            string caminhoDestino;
            string senha;
            string confirmacao;
            bool continuar = true;
            do
            {
                //Limpa o terminal
                Console.Clear();
                //Solicita os dados ao utilizador
                caminhoOrigem = this.caminhoOrigem();
                caminhoDestino = this.caminhoDestino(caminhoOrigem);
                //Solicitar Senha
                do
                {
                    Console.WriteLine("Qual a senha que pretende?");
                    senha = Console.ReadLine();
                    Console.WriteLine("Confirme Senha!");
                    confirmacao = Console.ReadLine();
                    if (senha != null && !senha.Equals(confirmacao))
                        Console.WriteLine("Senha não é igual");
                } while (senha != null && !senha.Equals(confirmacao));

                try
                {
                    //Submete os dados no controlador
                    ((IView) this).Controlador.SubmeterDados(caminhoOrigem, TipoDados.CaminhoOrigem);
                    ((IView) this).Controlador.SubmeterDados(caminhoDestino, TipoDados.CaminhoDestino);
                    ((IView) this).Controlador.SubmeterDados(senha, TipoDados.Senha);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    ProcessarDados(OpcoesExecucao.Encriptar);
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.ListaErros());
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.Ficheiro);
                }catch (DllNotFoundException erro)
                {
                    Console.WriteLine("Erro: {0}", erro.Message);
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao != null && opcao.ToUpper() != "S" && opcao.ToUpper() != "SIM")
                    continuar = false;
            } while (continuar);

            Console.Clear();
        }
        private void MenuCriar()
        {
            string caminhoDestino;
            string texto;
            string fonte;
            int tamanho;
            string estilo;
            bool continuar = true;
            do
            {
                //Limpa o terminal
                Console.Clear();
                //Solicita os dados ao utilizador
                caminhoDestino = caminhoOrigem();
                //Solicitar Texto
                Console.WriteLine("Insira o texto a incluir no novo documento");
                texto = Console.ReadLine();

                //Solicitar Fonte
                Console.WriteLine("Insira a fonte pretendida");
                fonte = Console.ReadLine();

                //Solicitar Tamanho
                Console.WriteLine("Insira o tamanho");
                tamanho = Convert.ToInt32(Console.ReadLine());

                //Solicitar Estilo
                Console.WriteLine("Insira o estilo: Regular/Bold/BoldItalic/Italic/Strikeout/Underline");
                estilo = Console.ReadLine();

                try
                {
                    //Submete os dados no controlador
                    ((IView)this).Controlador.SubmeterDados(caminhoDestino, TipoDados.CaminhoDestino);
                    ((IView)this).Controlador.SubmeterDados(texto, TipoDados.Texto);
                    ((IView)this).Controlador.SubmeterDados(fonte, TipoDados.Fonte);
                    ((IView)this).Controlador.SubmeterDados(tamanho, TipoDados.Tamanho);
                    ((IView)this).Controlador.SubmeterDados(estilo, TipoDados.Estilo);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    ProcessarDados(OpcoesExecucao.Criar);
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.ListaErros());
                }
                catch (DllNotFoundException erro)
                {
                    Console.WriteLine("Erro: {0}", erro.Message);
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao != null && opcao.ToUpper() != "S" && opcao.ToUpper() != "SIM")
                    continuar = false;
            } while (continuar);

            Console.Clear();
        }

        private void MenuRemoverEncriptacao()
        {
            string caminhoOrigem;
            string caminhoDestino;
            string senha;
            bool continuar = true;
            do
            {
                //Limpa o terminal
                Console.Clear();
                //Solicita os dados ao utilizador
                caminhoOrigem = this.caminhoOrigem();
                caminhoDestino = this.caminhoDestino(caminhoOrigem);
                //Solicitar Senha
                Console.WriteLine("Qual a senha do ficheiro?");
                senha = Console.ReadLine();
                try
                {
                    //Submete os dados no controlador
                    ((IView) this).Controlador.SubmeterDados(caminhoOrigem, TipoDados.CaminhoOrigem);
                    ((IView) this).Controlador.SubmeterDados(caminhoDestino, TipoDados.CaminhoDestino);
                    ((IView) this).Controlador.SubmeterDados(senha, TipoDados.Senha);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    ProcessarDados(OpcoesExecucao.Decriptar);
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.ListaErros());
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.Ficheiro);
                }catch (DllNotFoundException erro)
                {
                    Console.WriteLine("Erro: {0}", erro.Message);
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao != null && opcao.ToUpper() != "S" && opcao.ToUpper() != "SIM")
                    continuar = false;
            } while (continuar);
            Console.Clear();
        }

        private void MenuUnir(OpcoesExecucao op)
        {
            string caminhoOrigem;
            string caminhoOrigem2;
            string caminhoDestino;
            bool continuar = true;
            do
            {
                //Limpa o terminal
                Console.Clear();
                //Solicita os dados ao utilizador
                caminhoOrigem = this.caminhoOrigem();
                Console.WriteLine("Dados do 2º ficheiro:");
                caminhoOrigem2 = this.caminhoOrigem();
                caminhoDestino = this.caminhoDestino(caminhoOrigem);
                try
                {
                    //Submete os dados no controlador
                    ((IView) this).Controlador.SubmeterDados(caminhoOrigem, TipoDados.CaminhoOrigem);
                    ((IView) this).Controlador.SubmeterDados(caminhoDestino, TipoDados.CaminhoDestino);
                    ((IView) this).Controlador.SubmeterDados(caminhoOrigem2, TipoDados.CaminhoOrigem2);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    switch (op)
                    {
                        case OpcoesExecucao.Unir:
                            ProcessarDados(OpcoesExecucao.Unir);
                            break;
                        case OpcoesExecucao.Concatenar:
                            ProcessarDados(OpcoesExecucao.Concatenar);
                            break;
                    }
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.ListaErros());
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.Ficheiro);
                }catch (DllNotFoundException erro)
                {
                    Console.WriteLine("Erro: {0}", erro.Message);
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao != null && opcao.ToUpper() != "S" && opcao.ToUpper() != "SIM")
                    continuar = false;
            } while (continuar);

            Console.Clear();
        }

        private void MenuSeparar()
        {
            string caminhoOrigem;
            string caminhoDestino;
            string caminhoDestino2;
            int pagina;
            bool continuar = true;
            do
            {
                //Limpa o terminal
                Console.Clear();
                //Solicita os dados ao utilizador
                caminhoOrigem = this.caminhoOrigem();
                caminhoDestino = this.caminhoDestino(caminhoOrigem);
                Console.WriteLine("Dados de 2ºMetade do ficheiro");
                caminhoDestino2 = this.caminhoOrigem();
                Console.WriteLine("Página onde realizar a separação?");
                pagina = Int32.Parse(Console.ReadLine());
                try
                {
                    //Submete os dados no controlador
                    ((IView) this).Controlador.SubmeterDados(caminhoOrigem, TipoDados.CaminhoOrigem);
                    ((IView) this).Controlador.SubmeterDados(caminhoDestino, TipoDados.CaminhoDestino);
                    ((IView) this).Controlador.SubmeterDados(caminhoDestino2, TipoDados.CaminhoDestino2);
                    ((IView) this).Controlador.SubmeterDados(pagina, TipoDados.Pagina);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    ProcessarDados(OpcoesExecucao.SepararFicheiro);
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.ListaErros());
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.Ficheiro);
                }catch (DllNotFoundException erro)
                {
                    Console.WriteLine("Erro: {0}", erro.Message);
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao != null && opcao.ToUpper() != "S" && opcao.ToUpper() != "SIM")
                    continuar = false;
            } while (continuar);

            Console.Clear();
        }

        private void MenuAdicionar()
        {
            string caminhoOrigem;
            string caminhoOrigem2;
            string caminhoDestino;
            int pagina;
            int posicao;
            bool continuar = true;
            do
            {
                //Limpa o terminal
                Console.Clear();
                //Solicita os dados ao utilizador
                caminhoOrigem = this.caminhoOrigem();
                Console.WriteLine("Indique o caminho para o ficheiro com a página pretendida");
                caminhoOrigem2 = Console.ReadLine();
                caminhoDestino = this.caminhoDestino(caminhoOrigem);
                Console.WriteLine("Indique o número da página a adicionar");
                pagina = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Indique a posição para adicionar a página no primeiro ficheiro");
                posicao = Convert.ToInt32(Console.ReadLine());
                //Submete os dados no controlador
                try
                {
                    ((IView)this).Controlador.SubmeterDados(caminhoOrigem, TipoDados.CaminhoOrigem);
                    ((IView)this).Controlador.SubmeterDados(caminhoOrigem2, TipoDados.CaminhoOrigem2);
                    ((IView)this).Controlador.SubmeterDados(caminhoDestino, TipoDados.CaminhoDestino);
                    ((IView)this).Controlador.SubmeterDados(pagina, TipoDados.Pagina);
                    ((IView)this).Controlador.SubmeterDados(posicao, TipoDados.PosicaoAdicionar);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    ProcessarDados(OpcoesExecucao.AdicionarPagina);
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.ListaErros());
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.Ficheiro);
                }
                catch (DllNotFoundException erro)
                {
                    Console.WriteLine("Erro: {0}", erro.Message);
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao != null && opcao.ToUpper() != "S" && opcao.ToUpper() != "SIM")
                    continuar = false;
            } while (continuar);
            Console.Clear();
        }

        public void ProcessarDados(OpcoesExecucao op)
        {
            try
            {
                switch (op)
                {
                    case OpcoesExecucao.AdicionarPagina:
                        ((IView)this).Controlador.ProcessarDados(op);
                        if (((IView)this).Modelo.Resultado)
                        {
                            Console.WriteLine("Foi adicionada a página {0} do ficheiro {1}, na posição {2} do ficheiro {3}.", ((IView)this).Modelo.Page, ((IView)this).Modelo.FileOrigem2, ((IView)this).Modelo.AddPosition, ((IView)this).Modelo.FileDestino);
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível adicionar a página ao ficheiro {0}", ((IView)this).Modelo.FileDestino);
                        }

                        break;
                    case OpcoesExecucao.RemoverPagina:
                        ((IView)this).Controlador.ProcessarDados(op);
                        if (((IView)this).Modelo.Resultado)
                        {
                            Console.WriteLine("Foi removida a página {0} do ficheiro {1}.", ((IView)this).Modelo.Page, ((IView)this).Modelo.FileDestino);
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível remover a página do ficheiro {0}", ((IView)this).Modelo.FileDestino);
                        }

                        break;
                    case OpcoesExecucao.AdicionarMarca:
                        ((IView)this).Controlador.ProcessarDados(op);
                        if (((IView)this).Modelo.Resultado)
                        {
                            Console.WriteLine("Foi adicionada a seguinte marca de água {0} no ficheiro {1}", ((IView)this).Modelo.Texto, ((IView)this).Modelo.FileDestino);
                        }
                        else
                        {
                            Console.WriteLine("Não Foi possível adicionar a marca de água no ficheiro {0}", ((IView)this).Modelo.FileDestino);
                        }

                        break;
                    case OpcoesExecucao.Unir:
                        ((IView)this).Controlador.ProcessarDados(op);
                        if (((IView)this).Modelo.Resultado)
                        {
                            Console.WriteLine("Ficheiro {0} e {1} foram unidos de forma alternada.", ((IView)this).Modelo.FileOrigem, ((IView)this).Modelo.FileOrigem2);
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível unir ficheiros {0} e {1}", ((IView)this).Modelo.FileOrigem, ((IView)this).Modelo.FileOrigem2);
                        }

                        break;
                    case OpcoesExecucao.Concatenar:
                        ((IView)this).Controlador.ProcessarDados(OpcoesExecucao.Concatenar);
                        if (((IView)this).Modelo.Resultado)
                        {
                            Console.WriteLine("Ficheiro {0} e {1} foram concatenados.", ((IView)this).Modelo.FileOrigem, ((IView)this).Modelo.FileOrigem2);
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível unir ficheiros {0} e {1}", ((IView)this).Modelo.FileOrigem, ((IView)this).Modelo.FileOrigem2);
                        }

                        break;
                    case OpcoesExecucao.Encriptar:
                        ((IView)this).Controlador.ProcessarDados(OpcoesExecucao.Encriptar);
                        if (((IView)this).Modelo.Resultado)
                        {
                            Console.WriteLine("O ficheiro {0} foi encriptado", ((IView)this).Modelo.FileDestino);
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível encriptar o ficheiro{0}", ((IView)this).Modelo.FileOrigem);
                        }

                        break;
                    case OpcoesExecucao.Decriptar:
                        ((IView)this).Controlador.ProcessarDados(OpcoesExecucao.Decriptar);
                        if (((IView)this).Modelo.Resultado)
                        {
                            Console.WriteLine("Foi removida a encriptação no ficheiro {0}", ((IView)this).Modelo.FileDestino);
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível remover encriptação! Senha não é válida.");
                        }

                        break;
                    case OpcoesExecucao.ContarPaginas:
                        ((IView)this).Controlador.ProcessarDados(OpcoesExecucao.ContarPaginas);
                        if (((IView)this).Modelo.Resultado)
                        {
                            Console.WriteLine("O ficheiro {0} possui {1} páginas.", ((IView)this).Modelo.FileOrigem,
                                ((IView)this).Modelo.NumPages);
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível contar as páginas do ficheiro {0}", ((IView)this).Modelo.FileOrigem);
                        }

                        break;
                    case OpcoesExecucao.SepararFicheiro:
                        ((IView)this).Controlador.ProcessarDados(OpcoesExecucao.SepararFicheiro);
                        if (((IView)this).Modelo.Resultado)
                        {
                            Console.WriteLine(
                                "O ficheiro {0} foi dividido na página {1} criando os ficheiros {2} e {3}",
                                ((IView)this).Modelo.FileOrigem, ((IView)this).Modelo.Page,
                                ((IView)this).Modelo.FileDestino, ((IView)this).Modelo.FileDestino2);
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível separar o ficheiro {0}", ((IView)this).Modelo.FileOrigem);
                        }
                        break;

                    case OpcoesExecucao.Criar:
                        ((IView)this).Controlador.ProcessarDados(OpcoesExecucao.Criar);
                        if (((IView)this).Modelo.Resultado)
                        {
                            Console.WriteLine("Foi adicionada a seguinte texto: {0} \r\nno ficheiro {1}", ((IView)this).Modelo.Texto, ((IView)this).Modelo.FileDestino);
                        }
                        else
                        {
                            Console.WriteLine("Não Foi possível adicionar o texto no2 ficheiro {0}", ((IView)this).Modelo.FileDestino);
                        }

                        break;
                }

            }
            catch (ExceptionDadosInvalidos erro)
            {
                Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.ListaErros());
            }
            catch (ExceptionFileNotFound erro)
            {
                Console.WriteLine("Erro: {0} [{1}]", erro.Message, erro.Ficheiro);
            }catch (DllNotFoundException erro)
            {
                Console.WriteLine("Erro: {0}", erro.Message);
            }
        }


        //Função que implementa pedido de caminho de destino
        private string caminhoDestino(string caminho)
        {
            string opcao;
            Console.WriteLine("Substituir Ficheiro?");
            do
            {
                Console.WriteLine("Digite [(S)im] | [(N)ão]");
                opcao = Console.ReadLine();
                if (opcao != null)
                {
                    opcao = opcao.ToLower();
                    if (!opcao.Equals("s") && !opcao.Equals("sim") && !opcao.Equals("n") && !opcao.Equals("não"))
                    {
                        Console.WriteLine("Erro: Opção Inválida!");
                    }
                }
            } while (opcao != null && !opcao.Equals("s") && !opcao.Equals("sim") && !opcao.Equals("n") && !opcao.Equals("não"));

            if (opcao != null && (opcao.Equals("s") || opcao.Equals("sim")))
            {
                return caminho;
            }

            Console.WriteLine("Qual o caminho de destino onde pretende guardar o ficheiro?");
            return Console.ReadLine();
        }

        //Função que implementa pedido de caminho de destino
        private string caminhoOrigem()
        {
            Console.WriteLine("Introduza o caminho para o ficheiro");
            return Console.ReadLine();
        }


        public void EncerrarPrograma()
        {
            Console.WriteLine("Adeus");
        }
    }
}