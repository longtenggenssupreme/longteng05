using System.Collections.Generic;
using System.Web.Http;

namespace ConsoleTestOWIN
{
    public class TestController: ApiController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> list = new List<string> { "111", "222", "333" };
            return list;
        }

        [HttpGet]
        public string Get(int id)
        {
            return $"收到数据{id}";
        }

        public string Post([FromBody] string data)
        {
            return data;
        }

        public string Delete(int id)
        {
            return $"delete数据{id}"; ;
        }
    }
}
