using Scarif_DS_1.ui;

namespace Scarif_DS_1
{
    public class Controller
    {
        private Model modelo;
        private View ui;

        internal Controller()
        {
            this.modelo = new Model(this.ui);
            this.ui = new Consola(this.modelo, this);
            ui.AtivarInterface();
        }

        public void processarDados(int op)
        {
            switch (op)
            {
                case 1:
                    modelo.PathOrigem = "/home/paulojmnicolau/Livros";
                    modelo.FileOrigem = "IAProlog.pdf";
                    modelo.CountPages();
                    break;
            }
        }
    }
}