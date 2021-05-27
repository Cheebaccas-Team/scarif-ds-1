using System;

namespace Scarif_DS_1.modulos.Create
{
    public class CreateDados : IDados
    {
        private string _pathDestino;
        private string _fileDestino;
        private string _alinhamento;
        private string _estilo;
        private int _tamanho;
        private string _fonte;
        private string _texto;
        private TipoDados _tipo;

        internal CreateDados(string caminhoDestino, string texto, string estilo, string alinhamento, string fonte,
            int tamanho)
        {
            int separar = caminhoDestino.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathDestino = caminhoDestino.Substring(0, separar+1);                                  
            FileDestino = caminhoDestino.Substring(separar + 1);
            Texto = texto;
            Alinhamento = alinhamento;
            Estilo = estilo;
            Tamanho = tamanho;
            Fonte = fonte;
            Tipo = TipoDados.Create;
        }

        public string PathDestino
        {
            get => _pathDestino;
            set => _pathDestino = value;
        }

        public string FileDestino
        {
            get => _fileDestino;
            set => _fileDestino = value;
        }

        public string Alinhamento
        {
            get => _alinhamento;
            set => _alinhamento = value;
        }

        public string Estilo
        {
            get => _estilo;
            set => _estilo = value;
        }

        public int Tamanho
        {
            get => _tamanho;
            set => _tamanho = value;
        }

        public string Fonte
        {
            get => _fonte;
            set => _fonte = value;
        }

        public string Texto
        {
            get => _texto;
            set => _texto = value;
        }

        public string PathOrigem { get; set; }
        public string FileOrigem { get; set; }

        public TipoDados Tipo
        {
            get => _tipo;
            set => _tipo = value;
        }
        
    }
}