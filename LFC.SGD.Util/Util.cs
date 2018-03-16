using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace LFC.GesDoc
{
    public static class Util
    {
        public static string formataTexto(string _Texto)
        {
            string strTexto;

            strTexto = _Texto.ToUpper();
            strTexto = strTexto.Replace("Á", "A");
            strTexto = strTexto.Replace("Ã", "A");
            strTexto = strTexto.Replace("Â", "A");
            strTexto = strTexto.Replace("À", "A");
            strTexto = strTexto.Replace("É", "E");
            strTexto = strTexto.Replace("Ê", "E");
            strTexto = strTexto.Replace("È", "E");
            strTexto = strTexto.Replace("Í", "I");
            strTexto = strTexto.Replace("Î", "I");
            strTexto = strTexto.Replace("Ì", "I");
            strTexto = strTexto.Replace("Ó", "O");
            strTexto = strTexto.Replace("Ô", "O");
            strTexto = strTexto.Replace("Ò", "O");
            strTexto = strTexto.Replace("Õ", "O");
            strTexto = strTexto.Replace("Ú", "U");
            strTexto = strTexto.Replace("Û", "U");
            strTexto = strTexto.Replace("Ù", "U");
            strTexto = strTexto.Replace("Ü", "U");
            strTexto = strTexto.Replace("Ç", "C");
            strTexto = strTexto.Replace("\t", "");

            return strTexto;
        }

        public static string getVencimentoVigencia(string _VencimentoVigencia)
        {
            if (_VencimentoVigencia == "1/1/1900")
            {
                return "<font style='font-weight:bold;color:#CC0000;'>N/D</font>";
            }
            else
            {
                return "<font style='font-weight:bold;'>" + _VencimentoVigencia + "</font>";
            }
        }

        public static string getExpira(string _Expira)
        {
            switch (_Expira)
            {
                case "Não":
                    return "<font style='font-weight:bold;color:#006600;'>Não</font>";
                case "Sim":
                    return "<font style='font-weight:bold;color:#CC0000;'>Sim</font>";
            }

            return "";
        }

        public static List<int> preencheAno(int intAnoInicio, int intAnoFim)
        {
            List<int> lstAno = new List<int>();

            for (int i = intAnoInicio; i <= (intAnoFim); i++)
            { lstAno.Add(i); }
            return lstAno;
        }

        public static int ObterAno()
        {
            if (HttpContext.Current.Request.QueryString["ano"] != null)
            { return Convert.ToInt32(HttpContext.Current.Request.QueryString["ano"]); }
            else
            { return DateTime.Now.Year; }
        }

        public static List<string> preencheAnoFabricacao()
        {
            List<string> lst = new List<string>();

            lst.Add("");

            for (int i = 1970; i <= DateTime.Now.Year; i++)
            { lst.Add(i.ToString()); }

            return lst;
        }

        public static List<string> preencheAnoModelo()
        {
            List<string> lst = new List<string>();

            lst.Add("");

            for (int i = 1970; i <= DateTime.Now.Year; i++)
            { lst.Add(i.ToString()); }

            return lst;
        }
        
        public static List<string> preencheEstados()
        {
            List<string> lst = new List<string>();

            lst.Add("");
            lst.Add("AC");
            lst.Add("AL");
            lst.Add("AM");
            lst.Add("AP");
            lst.Add("BA");
            lst.Add("CE");
            lst.Add("DF");
            lst.Add("ES");
            lst.Add("GO");
            lst.Add("MA");
            lst.Add("MG");
            lst.Add("MS");
            lst.Add("MT");
            lst.Add("PA");
            lst.Add("PB");
            lst.Add("PE");
            lst.Add("PI");
            lst.Add("PR");
            lst.Add("RJ");
            lst.Add("RN");
            lst.Add("RO");
            lst.Add("RR");
            lst.Add("RS");
            lst.Add("SC");
            lst.Add("SE");
            lst.Add("SP");
            lst.Add("TO");

            return lst;
        }
    }
}
