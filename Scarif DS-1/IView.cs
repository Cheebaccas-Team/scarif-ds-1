
using Scarif_DS_1.exceptions;
using Scarif_DS_1.modulos;
using Scarif_DS_1.ui;

namespace Scarif_DS_1
{
    //Interface para as possiveis diferentes View a serem desenvolvidas
    public interface IView
    {
        public Controller Controlador { get; set;}

        public IModel Modelo { get; set; }

        public  void AtivarInterface();
        
        public  void DisponibilizarOpcoes();

        public void EncerrarPrograma();

        public void ExibeErro();

        public void ExibeResultado(OpcoesExecucao op);

        public void Continuar();
    }
}