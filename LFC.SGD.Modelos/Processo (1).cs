using System;

namespace LFC.GesDoc.Modelos
{
    public class Processo
    {
        public Int32 IdProcesso { get; set; }
        public String Nome { get; set; }
        public Int32 PrazoMaximo { get; set; }
        public String Email { get; set; }
        public String Ativo { get; set; }
    }
}
