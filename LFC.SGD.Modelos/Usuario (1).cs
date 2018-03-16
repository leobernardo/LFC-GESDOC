using System;

namespace LFC.GesDoc.Modelos
{
    public class Usuario
    {
        public Int32 IdUsuario { get; set; }
        public Processo Processo { get; set; }
        public String Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public String Telefone1 { get; set; }
        public String Telefone2 { get; set; }
        public String Telefone3 { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public String NivelAcesso { get; set; }
    }
}
