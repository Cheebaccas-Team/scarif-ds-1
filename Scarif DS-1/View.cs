using System.Runtime.CompilerServices;

namespace Scarif_DS_1
{
    public interface View
    {
        public Controller Controlador { get; set;}

        public Model Modelo { get; set; }

        public  void AtivarInterface();
        
        public  void DisponibilizarOpcoes();

        public  void ProcessarDados();
        
    }
}