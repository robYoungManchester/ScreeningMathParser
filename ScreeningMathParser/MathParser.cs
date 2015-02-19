using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ScreeningMathParser
{
    public class MathParser
    {
        public float parseString(string math2Parse)
        {
            // first evaluate the contents of brackets, starting with the most heavily nested pair
            // the contents of each set of brackets is evaluated then replaced with the result of the evaluation
            Regex rgx = new Regex(@"e([0-9abcd]+)f");

            while (rgx.IsMatch(math2Parse))
            {
                math2Parse = rgx.Replace(math2Parse, evaluateNumericOperators(rgx.Match(math2Parse).Groups[1].ToString()));
            }
            // finally evaluate the whole expression
            var returnVal = new float();
            Regex testForMatchingCharacters = new Regex(@"[abcdef]");
            while (!float.TryParse(math2Parse, out returnVal) && testForMatchingCharacters.IsMatch(math2Parse))
            {
                math2Parse = evaluateNumericOperators(math2Parse);
            }

            return returnVal;
        }

        public string evaluateNumericOperators(string subString2Parse)
        {
            // parse from left to right - note this doesn't follow the rules of maths since we would usually evaluate
            // in order of precedence with * and / evaluated first

            // parse from beginning (left) of the string
            Regex rgx = new Regex(@"^(\d+)([abcd])(\d+)");

            while (rgx.IsMatch(subString2Parse))
            {
                var match = rgx.Match(subString2Parse);
                var val1 = float.Parse(match.Groups[1].ToString());
                var val2 = float.Parse(match.Groups[3].ToString());
                switch (match.Groups[2].ToString())
                {
                    case "a":
                        subString2Parse = rgx.Replace(subString2Parse,(val1 + val2).ToString());
                        break;
                    case "b":
                        subString2Parse = rgx.Replace(subString2Parse,(val1 - val2).ToString());
                        break;
                    case "c":
                        subString2Parse = rgx.Replace(subString2Parse,(val1 * val2).ToString());
                        break;
                    case "d":
                        subString2Parse = rgx.Replace(subString2Parse,(val1 / val2).ToString());
                        break;
                }
            }

            return subString2Parse;
        }
    }
}
