using System;

namespace LFC.GesDoc.Modelos
{
    public class Processo
    {
        public int IDProcesso { get; set; }
        public string DSProcesso { get; set; }
        public int NRPrazoMaximo { get; set; }
        public string DSEmail { get; set; }
        public bool BTAtivo { get; set; }
    }
}
