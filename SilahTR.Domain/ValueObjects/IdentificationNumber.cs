using SilahTR.Domain.Common;
using SilahTR.Domain.Exceptions;

namespace SilahTR.Domain.ValueObjects
{
    public class IdentificationNumber : ValueObject
    {
        public string Value { get; private set; }

        public IdentificationNumber(string value)
        {
            try
            {
                if (!IsValid(value))
                {
                    throw new IdentificationNumberInvalidException(value);
                }

                Value = value;
            }
            catch (Exception)
            {
                throw new IdentificationNumberInvalidException(value);
            }

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static bool IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length != 11 || !value.All(char.IsDigit) ||
                value.StartsWith('0'))
            {
                return false;
            }

            if (!long.TryParse(value, out long tckn))
            {
                return false;
            }

            long atcno = tckn / 100;
            long btcno = tckn / 100;
            long c1 = atcno % 10;
            atcno /= 10;
            long c2 = atcno % 10;
            atcno /= 10;
            long c3 = atcno % 10;
            atcno /= 10;
            long c4 = atcno % 10;
            atcno /= 10;
            long c5 = atcno % 10;
            atcno /= 10;
            long c6 = atcno % 10;
            atcno /= 10;
            long c7 = atcno % 10;
            atcno /= 10;
            long c8 = atcno % 10;
            atcno /= 10;
            long c9 = atcno % 10;
            long q1 = ((10 - ((((c1 + c3 + c5 + c7 + c9) * 3) + (c2 + c4 + c6 + c8)) % 10)) % 10);
            long q2 = ((10 - (((((c2 + c4 + c6 + c8) + q1) * 3) + (c1 + c3 + c5 + c7 + c9)) % 10)) % 10);
            return ((btcno * 100) + (q1 * 10) + q2 == tckn);
        }
    }
}