using System.Text.RegularExpressions;

namespace CollectToxicWaste.Comum.Validações
{
    public class ValidacaoEmail
    {
        public static bool ValidaEmail(string email)
        {
            return Regex.IsMatch(email, ("(?[^@]+)@(?.+)"));
        }

    }
}
