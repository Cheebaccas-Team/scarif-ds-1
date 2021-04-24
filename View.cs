using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheewbacca_PDFSharp
{
    class View {

        private Model model;
        private Controller controller;

        internal View(Model m, Controller c) {
            model = m;
            controller = c;
        }

        public void AtivarInterface() {
            //Ativar a interface

        }

        public void Opcao() { 
            //Obterm opção escolhida
        
        }

        public void SubmeteDados()
        {
            //Submete os dados

        }

        private void DisponibilizarOpcoes() {
            //Disponibiliza as opções existentes

        }

        public void EncerrarPrograma() {
            //Encerra Programa
            controller.EncerrarPrograma();
        }
    }
}
