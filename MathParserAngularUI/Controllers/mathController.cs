using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScreeningMathParser;

namespace MathParserAngularUI.Controllers
{
    public class mathController : ApiController
    {
        // GET api/math
        public float Get(string value)
        {
            var parser = new MathParser();

            return parser.parseString(value);
        }
    }
}
