using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalango
{
    public static class Validar
    {
        public static bool CNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public static bool CodBarras(string codbarra)
        {
            if (codbarra != (new System.Text.RegularExpressions.Regex("[^0-9]")).Replace(codbarra, ""))
            {
                // VERIFICA SE É NÚMERO
                return false;
            }
            // VERIFICA O TAMANHO CODIGO DE BARRA(EAN-8 OU EAN-13)
            switch (codbarra.Length)
            {
                case 8:
                    codbarra = "000000" + codbarra;
                    break;
                case 13:
                    codbarra = "0" + codbarra;
                    break;
                default:
                   
                    return false;
            }
            // CALCULA O DIGITO DE VERIFICAÇÃO EAN-13 e EAN-8
            int[] a = new int[13];
            a[0] = int.Parse(codbarra[0].ToString()) * 3;
            a[1] = int.Parse(codbarra[1].ToString());
            a[2] = int.Parse(codbarra[2].ToString()) * 3;
            a[3] = int.Parse(codbarra[3].ToString());
            a[4] = int.Parse(codbarra[4].ToString()) * 3;
            a[5] = int.Parse(codbarra[5].ToString());
            a[6] = int.Parse(codbarra[6].ToString()) * 3;
            a[7] = int.Parse(codbarra[7].ToString());
            a[8] = int.Parse(codbarra[8].ToString()) * 3;
            a[9] = int.Parse(codbarra[9].ToString());
            a[10] = int.Parse(codbarra[10].ToString()) * 3;
            a[11] = int.Parse(codbarra[11].ToString());
            a[12] = int.Parse(codbarra[12].ToString()) * 3;
            int soma = a[0] + a[1] + a[2] + a[3] + a[4] + a[5] + a[6] + a[7] + a[8] + a[9] + a[10] + a[11] + a[12];
            int verifica = (10 - (soma % 10)) % 10;
            // VALIDA DIGITO DE VERIFICAÇÃO PARA EAN-13 e EAN-8
            int ultimo = int.Parse(codbarra[13].ToString());
            return verifica == ultimo;
        }

        public static bool InscricaoEstadual(string pInscr)
        {
            if (string.IsNullOrWhiteSpace(pInscr))
                return false;
            bool retorno = false;
            string strBase;
            string strBase2;
            string strOrigem;
            string strDigito1;
            string strDigito2;
            int intPos;
            int intValor;
            int intSoma = 0;
            int intResto;
            int intPeso = 0;

            strBase = "";
            strBase2 = "";
            strOrigem = "";

            if ((pInscr.Trim().ToUpper() == "ISENTO"))
                return true;

            for (intPos = 1; intPos <= pInscr.Trim().Length; intPos++)
            {
                if ((("0123456789P".IndexOf(pInscr.Substring((intPos - 1), 1), 0, System.StringComparison.OrdinalIgnoreCase) + 1) > 0))
                    strOrigem = (strOrigem + pInscr.Substring((intPos - 1), 1));
            }

            if ((strOrigem.Substring(0, 1) == "P"))
            {
                strBase = (strOrigem.Trim() + "0000000000000").Substring(0, 13);
                strBase2 = strBase.Substring(1, 8);
                intSoma = 0;
                intPeso = 1;

                for (intPos = 1; (intPos <= 8); intPos++)
                {
                    intValor = int.Parse(strBase.Substring((intPos), 1));
                    intValor = (intValor * intPeso);
                    intSoma = (intSoma + intValor);
                    intPeso = (intPeso + 1);

                    if ((intPeso == 2))
                        intPeso = 3;

                    if ((intPeso == 9))
                        intPeso = 10;
                }

                intResto = (intSoma % 11);
                strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                strBase2 = (strBase.Substring(0, 9) + (strDigito1 + strBase.Substring(10, 3)));
            }
            else
            {
                strBase = (strOrigem.Trim() + "000000000000").Substring(0, 12);
                intSoma = 0;
                intPeso = 1;

                for (intPos = 1; (intPos <= 8); intPos++)
                {
                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                    intValor = (intValor * intPeso);
                    intSoma = (intSoma + intValor);
                    intPeso = (intPeso + 1);

                    if ((intPeso == 2))
                        intPeso = 3;

                    if ((intPeso == 9))
                        intPeso = 10;
                }

                intResto = (intSoma % 11);
                strDigito1 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                strBase2 = (strBase.Substring(0, 8) + (strDigito1 + strBase.Substring(9, 2)));
                intSoma = 0;
                intPeso = 2;

                for (intPos = 11; (intPos >= 1); intPos = (intPos + -1))
                {
                    intValor = int.Parse(strBase.Substring((intPos - 1), 1));
                    intValor = (intValor * intPeso);
                    intSoma = (intSoma + intValor);
                    intPeso = (intPeso + 1);

                    if ((intPeso > 10))
                        intPeso = 2;
                }

                intResto = (intSoma % 11);
                strDigito2 = Convert.ToString(intResto).Substring((Convert.ToString(intResto).Length - 1));
                strBase2 = (strBase2 + strDigito2);
            }

            if ((strBase2 == strOrigem))
            {
                retorno = true;
            }


            return retorno;
        }

        public static bool Email(string email)
        {
            bool Validar = false;
            int Analisar = email.IndexOf("@");
            if (Analisar > 0)
            {
                if (email.IndexOf("@", Analisar + 1) > 0)
                {
                    return Validar;
                }
                int i = email.IndexOf(".", Analisar);
                if (i - 1 > Analisar)
                {
                    if (i + 1 < email.Length)
                    {
                        string r = email.Substring(i + 1, 1);
                        if (r != ".")
                        {
                            Validar = true;
                        }
                    }
                }
            }
            return Validar;
        }
    }
}
