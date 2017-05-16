using System.Text.RegularExpressions;

namespace Gestao.Infra.CrossCutting.Common.HelperTools
{
    public class CaracteresHelper
    {
        public static string SomenteNumeros(string texto)
        {
            string resultString = string.Empty;
            Regex regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(texto, "");
            return resultString;
        }
    }
}
