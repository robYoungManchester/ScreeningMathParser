using System.Globalization;
using System.Text.RegularExpressions;

namespace ScreeningMathParser
{
    public class MathParser
    {
        public static float ParseString(string math2Parse)
        {
            // first evaluate the contents of brackets, starting with the most heavily nested pair
            // the contents of each set of brackets is evaluated then replaced with the result of the evaluation
            var rgx = new Regex(@"e([0-9abcd]+)f");

            while (rgx.IsMatch(math2Parse))
            {
                math2Parse = rgx.Replace(math2Parse, EvaluateNumericOperators(rgx.Match(math2Parse).Groups[1].ToString()));
            }
            // finally evaluate the whole expression
            float returnVal;
            var testForMatchingCharacters = new Regex(@"[abcdef]");
            var count = 0;
            while (!float.TryParse(math2Parse, out returnVal) && testForMatchingCharacters.IsMatch(math2Parse) && count < math2Parse.Length)
            {
                math2Parse = EvaluateNumericOperators(math2Parse);
                count++;
            }

            return float.Parse(math2Parse);
        }

        private static string EvaluateNumericOperators(string subString2Parse)
        {
            // parse from left to right - note this doesn't follow the rules of maths since we would usually evaluate
            // in order of precedence with * and / evaluated first

            // parse from beginning (left) of the string
            var rgx = new Regex(@"^([-+]?[0-9]*\.?[0-9]+)([abcd])([-+]?[0-9]*\.?[0-9]+)");

            var count = 0;
            while (rgx.IsMatch(subString2Parse) && count < subString2Parse.Length)
            {
                var match = rgx.Match(subString2Parse);
                var val1 = float.Parse(match.Groups[1].ToString());
                var val2 = float.Parse(match.Groups[3].ToString());
                switch (match.Groups[2].ToString())
                {
                    case "a":
                        subString2Parse = rgx.Replace(subString2Parse, (val1 + val2).ToString(CultureInfo.CurrentCulture));
                        break;
                    case "b":
                        subString2Parse = rgx.Replace(subString2Parse, (val1 - val2).ToString(CultureInfo.CurrentCulture));
                        break;
                    case "c":
                        subString2Parse = rgx.Replace(subString2Parse,(val1 * val2).ToString(CultureInfo.CurrentCulture));
                        break;
                    case "d":
                        subString2Parse = rgx.Replace(subString2Parse,(val1 / val2).ToString(CultureInfo.CurrentCulture));
                        break;
                }
                count++;
            }

            return subString2Parse;
        }
    }
}
