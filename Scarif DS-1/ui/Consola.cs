using System;

namespace Scarif_DS_1.ui
{
    public class Consola : View
    {
        //Construtor da Interface de Terminal
        internal Consola(Model modelo, Controller controlo)
        {
            ((View) this).Controlador = controlo;
            ((View) this).Modelo = modelo;
        }

        //Propriedades (getter e setter) do Controlador
        Controller View.Controlador { get; set; }

        //Propriedades (getter e setter) do Modelo
        Model View.Modelo { get; set; }

        //Ativar a Interface
        public void AtivarInterface()
        {
            Console.WriteLine("Obrigado por utilizar o nosso Software!");
            DisponibilizarOpcoes();
        }

        //Disponibilizar as opções do menu principal
        public void DisponibilizarOpcoes()
        {
            int opcao = 0;
            do
            {
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
                        Console.WriteLine("Adeus");
                        break;
                }
            } while (opcao != 0);
        }

        //Disponibilizar as opções do Menu de Edição
        private void OpcaoEdit()
        {
            int opcao = 0;
            do
            {
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
            } while (opcao != 0);
        }

        private void OpcaoCriar()
        {
            int opcao = 0;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Escolha uma opção:");
                    Console.WriteLine("1 - Criar Ficheiro");
                    Console.WriteLine("Escolha 0 para voltar!");
                    opcao = Int32.Parse(Console.ReadLine());
                    if (opcao < 0 || opcao > 6)
                        Console.WriteLine("Opção Inválida! Escolha novamente.");
                } while (opcao < 0 || opcao > 6);

                switch (opcao)
                {
                    case (int) OpcoesMenuCriar.Criar:

                        break;
                    case (int) OpcoesMenuCriar.Sair:
                        Console.Clear();
                        break;
                }
            } while (opcao != 0);
        }

        private void OpcaoProteger()
        {
            int opcao = 0;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Escolha uma opção:");
                    Console.WriteLine("1 - Adicionar Encriptação");
                    Console.WriteLine("2 - Remover Encriptação");
                    Console.WriteLine("Escolha 0 para voltar!");
                    opcao = Int32.Parse(Console.ReadLine());
                    if (opcao < 0 || opcao > 6)
                        Console.WriteLine("Opção Inválida! Escolha novamente.");
                } while (opcao < 0 || opcao > 6);

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
            } while (opcao != 0);
        }

        //Disponibiliza as opções do Menu de Outras Tarefas
        private void OpcaoOutra()
        {
            int opcao = 0;
            do
            {
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
            } while (opcao != 0);
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
                //Solicita os dados ao utilizador
                caminhoOrigem = this.caminhoOrigem();
                try
                {
                    //Submete os dados no controlador
                    ((View) this).Controlador.SubmeterDados(caminhoOrigem, null);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    ProcessarDados(OpcoesExecucao.ContarPaginas);
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.ListaErros() + "]");
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.Ficheiro + "]");
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao.ToUpper() != "S" || opcao.ToUpper() != "SIM")
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
                    ((View) this).Controlador.SubmeterDados(caminhoOrigem, caminhoDestino, pagina, null, null);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    ProcessarDados(OpcoesExecucao.RemoverPagina);
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.ListaErros() + "]");
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.Ficheiro + "]");
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao.ToUpper() != "S" || opcao.ToUpper() != "SIM")
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
                    ((View) this).Controlador.SubmeterDados(caminhoOrigem, caminhoDestino, 0, null, marcaAgua);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    ProcessarDados(OpcoesExecucao.AdicionarMarca);
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.ListaErros() + "]");
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.Ficheiro + "]");
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao.ToUpper() != "S" || opcao.ToUpper() != "SIM")
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
                    if (!senha.Equals(confirmacao))
                        Console.WriteLine("Senha não é igual");
                } while (!senha.Equals(confirmacao));

                try
                {
                    //Submete os dados no controlador
                    ((View) this).Controlador.SubmeterDados(caminhoOrigem, caminhoDestino, 0, senha, null);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    ProcessarDados(OpcoesExecucao.Encriptar);
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.ListaErros() + "]");
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.Ficheiro + "]");
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao.ToUpper() != "S" || opcao.ToUpper() != "SIM")
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
                    ((View) this).Controlador.SubmeterDados(caminhoOrigem, caminhoDestino, 0, senha, null);
                    //Processa os dados no Modelo verificando se ocorrem erros
                    ProcessarDados(OpcoesExecucao.Decriptar);
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.ListaErros() + "]");
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.Ficheiro + "]");
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao.ToUpper() != "S" || opcao.ToUpper() != "SIM")
                    continuar = false;
            } while (continuar);

            Console.Clear();
        }

        private void MenuUnir(OpcoesExecucao op)
        {
            string caminhoOrigem;
            string caminhoOrigem2;
            string caminhoDestino;
            string senha;
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
                //Solicitar Senha
                Console.WriteLine("Qual a senha do ficheiro?");
                senha = Console.ReadLine();
                try
                {
                    //Submete os dados no controlador
                    ((View) this).Controlador.SubmeterDados(caminhoOrigem, caminhoDestino, caminhoOrigem2, null);
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
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.ListaErros() + "]");
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.Ficheiro + "]");
                }

                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao.ToUpper() != "S" || opcao.ToUpper() != "SIM")
                    continuar = false;
            } while (continuar);

            Console.Clear();
        }

        private void MenuSeparar()
        {
        }

        private void MenuAdicionar()
        {
        }

        public void ProcessarDados(OpcoesExecucao op)
        {
            try
            {
                switch (op)
                {
                    case OpcoesExecucao.AdicionarPagina:
                        break;
                    case OpcoesExecucao.RemoverPagina:
                        ((View) this).Controlador.ProcessarDados(op);
                        if (((View) this).Modelo.Resultado)
                        {
                            Console.WriteLine("Foi removida a página " + ((View) this).Modelo.PageToRemove +
                                              " do ficheiro "
                                              + ((View) this).Modelo.FileOrigem + ".");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível remover a página do ficheiro " +
                                              ((View) this).Modelo.FileOrigem);
                        }

                        break;
                    case OpcoesExecucao.AdicionarMarca:
                        ((View) this).Controlador.ProcessarDados(op);
                        if (((View) this).Modelo.Resultado)
                        {
                            Console.WriteLine("Foi adicionada a seguinte marca de água " + ((View) this).Modelo.Texto +
                                              " no ficheiro " + ((View) this).Modelo.FileDestino);
                        }
                        else
                        {
                            Console.WriteLine("Não Foi possível adicionar a marca de água no ficheiro " +
                                              ((View) this).Modelo.FileOrigem);
                        }

                        break;
                    case OpcoesExecucao.Unir:
                        ((View) this).Controlador.ProcessarDados(op);
                        if (((View) this).Modelo.Resultado)
                        {
                            Console.WriteLine("Ficheiro " + ((View) this).Modelo.FileOrigem + " e " +
                                              ((View) this).Modelo.FileOrigem2 +
                                              " foram unidos de forma alternada.");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível unir ficheiros " + ((View) this).Modelo.FileOrigem +
                                              " e " + ((View) this).Modelo.FileOrigem2);
                        }
                        break;
                    case OpcoesExecucao.Concatenar:
                        ((View) this).Controlador.ProcessarDados(OpcoesExecucao.Concatenar);
                        if (((View) this).Modelo.Resultado)
                        {
                            Console.WriteLine("Ficheiro " + ((View) this).Modelo.FileOrigem + " e " +
                                              ((View) this).Modelo.FileOrigem2 +
                                              " foram concatenados.");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível unir ficheiros " + ((View) this).Modelo.FileOrigem +
                                              " e " + ((View) this).Modelo.FileOrigem2);
                        }
                        break;
                    case OpcoesExecucao.Encriptar:
                        ((View) this).Controlador.ProcessarDados(OpcoesExecucao.Encriptar);
                        if (((View) this).Modelo.Resultado)
                        {
                            Console.WriteLine("O ficheiro " + ((View) this).Modelo.FileDestino + " foi encriptado");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível encriptar o ficheiro" + ((View) this).Modelo.FileOrigem);
                        }
                        break;
                    case OpcoesExecucao.Decriptar:
                        ((View) this).Controlador.ProcessarDados(OpcoesExecucao.Decriptar);
                        if (((View) this).Modelo.Resultado)
                        {
                            Console.WriteLine("Foi removida a encriptação no ficheiro " + ((View) this).Modelo.FileDestino);
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível remover encriptação! Senha não é válida.");
                        }
                        break;
                    case OpcoesExecucao.ContarPaginas:
                        ((View) this).Controlador.ProcessarDados(OpcoesExecucao.ContarPaginas);
                        if (((View) this).Modelo.Resultado)
                        {
                            Console.WriteLine("O ficheiro " + ((View) this).Modelo.FileOrigem + " possui " +
                                              ((View) this).Modelo.NumPages +
                                              " páginas.");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível contar as páginas do ficheiro " +
                                              ((View) this).Modelo.FileOrigem);
                        }
                        break;
                    case OpcoesExecucao.SepararFicheiro:
                        break;
                    case OpcoesExecucao.Criar:
                        break;
                }
            }
            catch (ExceptionDadosInvalidos erro)
            {
                Console.WriteLine("Erro: " + erro.Message + " [" + erro.ListaErros() + "]");
            }
            catch (ExceptionFileNotFound erro)
            {
                Console.WriteLine("Erro: " + erro.Message + " [" + erro.Ficheiro + "]");
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
                opcao = opcao.ToLower();
                if (!opcao.Equals("s") && !opcao.Equals("sim") && !opcao.Equals("n") && !opcao.Equals("não"))
                {
                    Console.WriteLine("Erro: Opção Inválida!");
                }
            } while (!opcao.Equals("s") && !opcao.Equals("sim") && !opcao.Equals("n") && !opcao.Equals("não"));
            if (opcao.Equals("s") || opcao.Equals("sim")) {
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
    }
}