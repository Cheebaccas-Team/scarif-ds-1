using System;

namespace Scarif_DS_1.ui
{
    public class Consola : View
    {
        //Enumerador das Opções do Menu Principal
        public enum OpcoesMenuPrincipal
        {
            Sair = 0,
            Editar=1,
            Criar=2,
            Proteger=3,
            Outra=4
        };

        //Enumerador das Opções do Menu de Edição
        public enum OpcoesMenuEdit
        {
            Sair,
            Adicionar,
            Remover,
            Concatenar,
            Alternar,
            Separar
        }

        //Enumerador das Opções do Menu de Outras Funcionalidades
        public enum OpcoesMenuOutra
        {
            Sair,
            Contar
        }
        
    
        //Construtor da Interface de Terminal
        internal Consola(Model modelo, Controller controlo)
        {
            ((View) this).Controlador = controlo;
            ((View) this).Modelo = modelo;
        }

        //Propriedades (getter e setter) do Controlador
        Controller View.Controlador { get; set;}
        
        //Propriedades (getter e setter) do Modelo
        Model View.Modelo { get; set; }

        //Ativar a Interface
        public  void AtivarInterface() {
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
                        break;
                    case (int) OpcoesMenuPrincipal.Proteger:
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
                    Console.WriteLine("Escolha 0 para voltar!");
                    opcao = Int32.Parse(Console.ReadLine());
                    if (opcao < 0 || opcao > 5)
                        Console.WriteLine("Opção Inválida! Escolha novamente.");
                } while (opcao < 0 || opcao > 5);
                switch (opcao)
                {
                    case (int) OpcoesMenuEdit.Adicionar:
                        break;
                    case (int) OpcoesMenuEdit.Remover:
                        break;
                    case (int) OpcoesMenuEdit.Alternar:
                        break;
                    case (int) OpcoesMenuEdit.Concatenar:
                        break;
                    case (int) OpcoesMenuEdit.Separar:
                        break;
                    case (int) OpcoesMenuEdit.Sair:
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
        public void MenuContar()
        {
            string caminho;
            string nomeFicheiro;
            string diretoria;
            bool continuar = true;
            do
            {
                //Limpa o terminal
                Console.Clear();
                //Solicita os dados ao utilizador
                Console.WriteLine("Introduza o caminho para o ficheiro");
                caminho = Console.ReadLine();
                //Prepara os dados para fornecer ao Controlador
                int separar = caminho.LastIndexOf("/");
                diretoria = caminho.Substring(0, separar+1);
                nomeFicheiro = caminho.Substring(separar + 1);
                //Submete os dados no controlador
                ((View) this).Controlador.SubmeterDados(diretoria, null, nomeFicheiro, null);
                //Processa os dados no Modelo verificando se ocorrem erros
                try
                {
                    ((View) this).Controlador.ProcessarDados(1);
                    Console.WriteLine("O ficheiro " + nomeFicheiro + " possui " + ((View) this).Modelo.NumPages +
                                      " páginas");
                }
                catch (ExceptionDadosInvalidos erro)
                {
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.ListaErros()+"]");
                }
                catch (ExceptionFileNotFound erro)
                {
                    Console.WriteLine("Erro: " + erro.Message + " [" + erro.Ficheiro+"]");
                }
                //valida se é para continuar na mesma tarefa
                Console.WriteLine("Pretende Continuar? [(S)im] [(N)ão]");
                string opcao = Console.ReadLine();
                if (opcao.ToUpper() != "S" || opcao.ToUpper() != "SIM")
                    continuar = false;
            } while (continuar);
            Console.Clear();
        }

        public void ProcessarDados()
        {
            throw new NotImplementedException();
        }
        
    }
}