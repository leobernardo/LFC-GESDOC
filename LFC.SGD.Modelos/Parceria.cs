using System;

namespace LFC.GesDoc.Modelos
{
    public class Parceria
    {
        public int IdParceria { get; set; }
        public Unidade Unidade { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Objetivo { get; set; }
        public string Observacoes { get; set; }
        public bool PossuiPagamentoRH { get; set; }
        public bool PossuiRecursosFinanceiros { get; set; }
        public bool PossuiVigencia { get; set; }
        public DateTime InicioVigencia { get; set; }
        public DateTime FimVigencia { get; set; }
        public decimal ValorPrevistoAnual { get; set; }
        public string ArquivoAnexo { get; set; }
        public string Status { get; set; }
    }
}