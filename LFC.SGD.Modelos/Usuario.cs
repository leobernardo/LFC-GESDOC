using System;

namespace LFC.GesDoc.Modelos
{
    public class Usuario
    {
        public int IDUsuario { get; set; }
        public Processo Processo { get; set; }
        public string DSNome { get; set; }
        public DateTime DTNascimento { get; set; }
        public string DSTelefone1 { get; set; }
        public string DSTelefone2 { get; set; }
        public string DSTelefone3 { get; set; }
        public string DSEmail { get; set; }
        public string DSSenha { get; set; }
        public string DSNivelAcesso { get; set; }
        public bool BTAtivo { get; set; }
    }
}
