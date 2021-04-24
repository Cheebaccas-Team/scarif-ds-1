using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheewbacca_PDFSharp
{
    class Controller{
        Model model;
        View view;

        public delegate void AtivacaoInterface(object origem);
        public event AtivacaoInterface AtivarInterface;

        public void IniciarPrograma() {
            //Iniciar o programa
            view.AtivarInterface();
        }

        private void ValidaDados() {
            //Permite validar os dados

        }

        public void SubmeteDados() {
            //Submete os dados

        }

        public void EncerrarPrograma() {
            //Encerrar o programa
            model.Destruir();
        }

    }
}
