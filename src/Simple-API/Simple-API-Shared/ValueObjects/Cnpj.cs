using System;

namespace Simple_API_Shared.ValueObjects
{
    public struct Cnpj
    {
        private readonly string _value;

        private Cnpj(string value)
        {
            _value = value;
        }

        public override string ToString()
            => _value;

        public static implicit operator Cnpj(string input)
            => Parse(input);

        public static Cnpj Parse(string value)
        {
            if (TryParse(value, out var result))
                return result;

            throw new ArgumentException("Cpf is not valid");
        }

        public static bool TryParse(string value, out Cnpj cnpj)
        {
            cnpj = default(Cnpj);

            int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            value = value.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (value.Length != 14)
                return false;

            string tempvalue = value.Substring(0, 12);
            int sum = 0;

            for (int i = 0; i < 12; i++)
                sum += int.Parse(tempvalue[i].ToString()) * multiplier1[i];

            int rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            string digit = rest.ToString();
            tempvalue += digit;
            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += int.Parse(tempvalue[i].ToString()) * multiplier2[i];

            rest = (sum % 11);
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit += rest.ToString();

            if (value.EndsWith(digit))
                cnpj = new Cnpj(value);
            else
                return false;

            return true;
        }
    }
}