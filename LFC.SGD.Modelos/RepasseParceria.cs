using System;

namespace LFC.GesDoc.Modelos
{
    public class RepasseParceria
    {
        public int IdRepasseParceria { get; set; }
        public Parceria Parceria { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataRepasse { get; set; }
        public decimal ValorRepasse { get; set; }
        public string Status { get; set; }
    }
}