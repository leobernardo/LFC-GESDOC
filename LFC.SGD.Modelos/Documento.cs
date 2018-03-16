using System;

namespace LFC.GesDoc.Modelos
{
    public class Documento
    {
        public Int32 IdDocumento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public String Descricao { get; set; }
        public String NomePortador { get; set; }
        public String RG { get; set; }
        public String NumeroINSS { get; set; }
        public String CPFCNPJ { get; set; }
        public Int32 Vigencia { get; set; }
        public DateTime VencimentoVigencia { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataAssinatura { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime Descarte { get; set; }
        public Int32 SetorAtual { get; set; }
        public String Arquivado { get; set; }
        public String AlertaVencimentoVigencia { get; set; }
        public DateTime DataPagamentoRecebimento { get; set; }
        public String NumeroParcelas { get; set; }
        public String ValorPrevistoParcela { get; set; }
        public String Arquivo { get; set; }
        public String Ativo { get; set; }
    }
}
