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

    }
}