using System;

namespace LFC.GesDoc.Modelos
{
    public class ArquivamentoExterno
    {
        public Int32 IdArquivamentoExterno { get; set; }
        public Documento Documento { get; set; }
        public Int32 Estante { get; set; }
        public Int32 Prateleira { get; set; }
        public Int32 Caixa { get; set; }
        public String ArquivoDocumento { get; set; }
    }
}
