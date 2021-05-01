using System;

namespace Scarif_DS_1.ui
{
    public class Consola : View
    {
        
        internal Consola(Model modelo, Controller controlo)
        {
            ((View) this).Controlador = controlo;
            ((View) this).Modelo = modelo;
        }

        Controller View.Controlador { get; set;}
        Model View.Modelo { get; set; }

        public  void AtivarInterface() {
            //Ativar a interface
            Console.WriteLine("Obrigado por utilizar o nosso Software!");
            ProcessarDados();
            //DisponibilizarOpcoes();
       
        }

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
                    Console.WriteLine("Escolha 0 para sair!");
                    opcao = Int32.Parse(Console.ReadLine());
                    if (opcao < 0 || opcao > 3)
                        Console.WriteLine("Opção Inválida! Escolha novamente.");
                } while (opcao < 0 || opcao > 3);
            } while (opcao != 0);
        }

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
            } while (opcao != 0);
        }

        public void ProcessarDados()
        {
            string pathOrigem = "/home/paulojmnicolau/Livros";
            string fileOrigem = "IA.pdf";
            ((View) this).Controlador.SubmeterDados(pathOrigem, null, fileOrigem, null);
            ((View) this).Controlador.processarDados(1);
            Console.WriteLine(((View) this).Modelo.NumPages);
        }
        /*
            PDFSharpIntegrate obj = new PDFSharpIntegrate();
            obj.SplitDocument("c://PDFTests", "21111SO-20-efA.pdf", "c://PDFTests/Output"); //Testado
            Console.WriteLine(obj.CountPages("c://PDFTests", "21111SO-20-efA.pdf")); //Testado deu 3
            Console.WriteLine(obj.CountPages("c://PDFTests", "pdf1.pdf")); //Testado deu 9
            Console.WriteLine(obj.CountPages("c://PDFTests", "pdf2.pdf")); //Testado deu 96
            Console.WriteLine(obj.CountPages("c://PDFTests", "pdf3.pdf")); //Testado deu 83
            obj.WatermarkFile("c://PDFTests", "21111SO-20-efA.pdf","PDF Sharp");//Testado
            obj.RemovePage("c://PDFTests", "21111SO-20-efA.pdf", 2);
            */
    }
}