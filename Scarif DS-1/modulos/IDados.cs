namespace Scarif_DS_1.modulos
{
    public interface IDados
    {
        public string PathOrigem { get; set; }
        public string FileOrigem { get; set; }
        public string PathDestino { get; set; }
        public string FileDestino { get; set; }
        public TipoDados Tipo { get; set; }
    }
}