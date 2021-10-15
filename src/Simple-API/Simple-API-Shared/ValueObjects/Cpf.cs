using System;

namespace Simple_API_Shared.ValueObjects
{
    public struct Cpf
    {
        private readonly string _value;

        private Cpf(string value)
        {
            _value = value;
        }

        public override string ToString()
            => _value;

        public static implicit operator Cpf(string input)
            => Parse(input);

        public static Cpf Parse(string value)
        {
            if (TryParse(value, out var result))
                return result;

            throw new ArgumentException("Cpf is not valid");
        }

        public static bool TryParse(string value, out Cpf cpf)
        {
            cpf = default(Cpf);

            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            value = value.Trim().Replace(".", "").Replace("-", "");

            if (value.Length != 11)
                return false;

            switch (value)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "2222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            for (int j = 0; j < 10; j++)
            {
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == value)
                    return false;
            }

            string tempCpf = value.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];

            int rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            string digit = rest.ToString();
            tempCpf += digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];

            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit += rest.ToString();

            if (value.EndsWith(digit))
                cpf = new Cpf(value);
            else
                return false;

            return true;
        }
    }
}