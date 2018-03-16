using System;

namespace LFC.GesDoc.Modelos
{
    public class ArquivamentoInterno
    {
        public Int32 IdArquivamentoInterno { get; set; }
        public Documento Documento { get; set; }
        public Int32 Arquivo { get; set; }
        public Int32 Gaveta { get; set; }
        public Int32 Pasta { get; set; }
        public String ArquivoDocumento { get; set; }
    }
}
