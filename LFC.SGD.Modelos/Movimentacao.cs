using System;

namespace LFC.GesDoc.Modelos
{
    public class Movimentacao
    {
        public Int32 IdMovimentacao { get; set; }
        public Documento Documento { get; set; }
        public Int32 ProcessoOrigem { get; set; }
        public Int32 ProcessoDestino { get; set; }
        public String MovimentadoPor { get; set; }
        public String DataHoraMovimentacao { get; set; }
        public String Recebido { get; set; }
        public String RecebidoPor { get; set; }
        public String DataHoraRecebimento { get; set; }
        public DateTime Prazo { get; set; }
        public String Despacho { get; set; }
        public String EntreguePara { get; set; }
        public String AlertaPrazo { get; set; }
    }
}
