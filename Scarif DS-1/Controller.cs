using Scarif_DS_1.ui;

namespace Scarif_DS_1
{
    public class Controller
    {
        private Model modelo;
        private View ui;

        
        
        internal Controller()
        {
            modelo = new Model(ui);
            ui = new Consola(modelo, this);
            ui.AtivarInterface();
        }

        public bool SubmeterDados(string pathOrigem, string pathDestino, string fileOrigem, string fileDestino)
        {
            modelo.PathOrigem = pathOrigem;
            modelo.PathDestino = pathDestino;
            modelo.FileOrigem = fileOrigem;
            modelo.FileDestino = fileDestino;
            return true;
        }
        
        
        public void processarDados(int op)
        {
            switch (op)
            {
                case 1:
                    modelo.EfetuarProcesso = CountMod.ProcessarDados;
                    break;
            }
            modelo.EfetuarProcesso(modelo);
        }
    }
}