namespace SilahTR.Domain.Exceptions
{
    public class IdentificationNumberInvalidException(string value) : Exception($"{value} Tc kimlik doğrulanamadı.")
    {
    }
}
