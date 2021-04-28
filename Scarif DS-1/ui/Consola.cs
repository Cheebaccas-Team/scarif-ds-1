using System;

namespace Scarif_DS_1.ui
{
    public class Consola : View
    {

        internal Consola(Model modelo, Controller controlador) : base(controlador, modelo){ }
        
        public override void AtivarInterface() {
            //Ativar a interface
            Console.WriteLine("Obrigado por utilizar o nosso Software!");
            DisponibilizarOpcoes();
        }

        public override void DisponibilizarOpcoes()
        {
            Console.WriteLine("Qual a tarefa que pretende executar?");
            
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