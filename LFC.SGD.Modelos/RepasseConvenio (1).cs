using System;

namespace LFC.GesDoc.Modelos
{
    public class RepasseConvenio
    {
        public int IdRepasseConvenio { get; set; }
        public Convenio Convenio { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataRepasse { get; set; }
        public decimal ValorRepasse { get; set; }
        public string Status { get; set; }
    }
}