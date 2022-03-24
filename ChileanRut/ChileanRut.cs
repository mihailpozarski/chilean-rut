using System;
using System.Linq;

namespace ChileanRutify
{
    /// <summary>
    /// Class that allows you to validate a rut
    /// copyright Mihail Pozarski Rada 2022 - https://github.com/mihailpozarski
    /// </summary>
    public class ChileanRut
    {
        public static bool ValidRutValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            string[] rut_values = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "k", "K" };

            return rut_values.Contains(value);
        }

        public static bool ValidRutValues(string rut)
        {
            if (string.IsNullOrEmpty(rut))
            {
                return false;
            }

            char[] rut_array = rut.ToCharArray();
            foreach (char rut_value in rut_array)
            {
                if (!ValidRutValue(rut_value.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        public static string NormalizeRut(string rut)
        {
            if (string.IsNullOrEmpty(rut))
            {
                return "";
            }

            rut = rut.Replace(".", "");
            rut = rut.Replace("-", "");
            rut = rut.Replace(" ", "");

            return rut.ToUpper();
        }

        public static string GetVerifier(string rut)
        {
            if (string.IsNullOrEmpty(rut))
            {
                return "";
            }

            rut = NormalizeRut(rut);

            string rut_number = rut[0..^1];
            string rut_verifier = rut.Substring(rut.Length - 1, 1);

            int sum = 0;
            int mul = 2;

            char[] inverse_rut = rut_number.ToCharArray();
            Array.Reverse(inverse_rut);
            foreach (char value in inverse_rut)
            {
                int digit = int.Parse(value.ToString());
                sum += digit * mul;
                if (mul == 7)
                {
                    mul = 2;
                }
                else
                {
                    mul++;
                }
            }

            int mod = sum % 11;

            return TransformVerifierModule(mod);
        }

        public static string TransformVerifierModule(int verifier)
        {
            switch (verifier)
            {
                case 0:
                    return "0";
                case 1:
                    return "k";
                default:
                    return (11 - verifier).ToString();
            }
        }

        public static bool ValidRutVerifier(string rut){
            if (string.IsNullOrEmpty(rut))
            {
                return false;
            }

            rut = NormalizeRut(rut);
            if (!ValidRutValues(rut))
            {
                return false;
            }

            string rut_number = rut.Substring(0, rut.Length - 1);
            string rut_verifier = rut.Substring(rut.Length - 1, 1);

            return GetVerifier(rut_number) == rut_verifier;
        }

        public static bool ValidRut(string rut)
        {
            if (string.IsNullOrEmpty(rut))
                return false;

            rut = NormalizeRut(rut);
            if (!ValidRutValues(rut))
                return false;

            return ValidRutVerifier(rut);
        }
    }
}
