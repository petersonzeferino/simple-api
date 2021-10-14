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
            {
                return result;
            }
            
            throw new ArgumentException("Cpf is not valid");
        }

        public static bool TryParse(string value, out Cpf cpf)
        {
            //TODO: Include validation 
            cpf = new Cpf(value);
            return true;
        }
    }
}