using System;

namespace Scarif_DS_1.modulos.WaterMark
{
    public class WaterMarkDados: IDados
    {
        private string _pathOrigem;
        private string _fileOrigem;
        private string _pathDestino;
        private string _fileDestino;
        private string _texto;
        private TipoDados _tipo;
        
        internal WaterMarkDados(string caminhoOrigem, string caminhoDestino, string marcaAgua)
        {
            int separar = caminhoOrigem.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathOrigem = caminhoOrigem.Substring(0, separar+1);                                  
            FileOrigem = caminhoOrigem.Substring(separar + 1);
            separar = caminhoDestino.LastIndexOf("/", StringComparison.Ordinal);                                               
            PathDestino = caminhoDestino.Substring(0, separar+1);                                  
            FileDestino = caminhoDestino.Substring(separar + 1);
            Texto = marcaAgua;
            Tipo = TipoDados.WaterMark;
        }

        public string PathOrigem
        {
            get => _pathOrigem;
            set => _pathOrigem = value;
        }

        public string FileOrigem
        {
            get => _fileOrigem;
            set => _fileOrigem = value;
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

        public string Texto
        {
            get => _texto;
            set => _texto = value;
        }

        public TipoDados Tipo { get=>_tipo; set=> _tipo = value; }
    }
}