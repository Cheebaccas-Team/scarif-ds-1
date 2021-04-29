using System.Runtime.CompilerServices;

namespace Scarif_DS_1
{
    public abstract class View
    {
        private Controller controlador;
        private Model modelo;

        internal View(Controller controlo, Model modelo)
        {
            controlador = controlo;
            this.modelo = modelo;
        }

        public abstract void AtivarInterface();
        
        public abstract void DisponibilizarOpcoes();

        public abstract void processarDados();
        public Controller Controlador => controlador;
        public Model Modelo => modelo;

    }
}