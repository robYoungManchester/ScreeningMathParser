using System.Web.Http;
using ScreeningMathParser;

namespace MathParserAngularUI.Controllers
{
    public class mathController : ApiController
    {
        // GET api/math
        public float Get(string value)
        {
            return MathParser.ParseString(value);
        }
    }
}
