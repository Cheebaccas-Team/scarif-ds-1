namespace Scarif_DS_1
{
    public interface IModel
    {
        public string PathOrigem { get; set; }
        public string FileOrigem { get; set; }
        public string PathOrigem2 { get; set; }
        public string FileOrigem2 { get; set; }
        public string PathDestino { get; set; }
        public string FileDestino { get; set; } 
        public string PathDestino2 { get; set; }
        public string FileDestino2 { get; set; }
        public int NumPages { get; set; }
        public int Page { get; set; }
        public string Texto { get; set; }
        public int AddPosition { get; set; }
        public bool Resultado{ get; set;}

    }
}