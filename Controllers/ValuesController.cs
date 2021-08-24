using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
namespace WebApi.Controllers
{
    // origins = * 代表支持所有网页请求  可设置固定网页请求 如 www.baidu.com:5555    headers * 表示所有头请求都可以       methods * 表示所有 get post 等类型都可以请求
    [EnableCors(origins: "*", headers: "*", methods: "Get,Post")]
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/values/5
        public string Get(int id)
        {
            if (id == 1) {
                return "张三";
            }
            return "value";
        }
        [HttpPost]
        // POST api/values
        public string Post([FromBody] string value)
        {
            if (value.Equals("张三")) {
                return "李四";
            }
            return "";
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }



        [HttpPost]
        [Route("login")]
        public bool login(string name,string pwd) {
            if (name.Length > 0 && pwd.Equals("123")) {
                return true;
            }
            return false;
        }
    }
}
