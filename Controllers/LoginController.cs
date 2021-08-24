using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "Get,Post")]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        SqlConnection strCon = new SqlConnection("server=DESKTOP-3N5JSFQ;database=Test;uid=sa;pwd=323402171");
        [Route("login")]
        public IHttpActionResult Login(Models.LoginViewModle us)
        {
            bool trueopen = false;
            try
            {
                openSql();
                string sql = "select * from LoginTable where Name='" + us.name + "' and Password='" + us.pwd + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter s = new SqlDataAdapter(sql, strCon);
                s.Fill(ds);
                DataTable tbl = ds.Tables[0];
                DataRow row = tbl.Rows[0];
                if (!row.HasErrors)
                {
                    trueopen = true;
                }
            }
            catch (Exception ex)
            {
                return Ok(new Models.ResponseData() { data = null, code = 500, msg = "账号密码有误" });
                throw ex;
            }
            finally {
                CloseSql();
            }
            if (trueopen)
            {
                if (ModelState.IsValid)
                {
                   
                    return Ok(new Models.ResponseData()
                    {
                        data = JwtTools.Encoder(new Dictionary<string, object> {
                        { "name",us.name}
                    }),
                        msg = "Success",

                    });
                }
                else
                {
                    return Ok(new Models.ResponseData() { code = 500, msg = "账号密码有误" });
                }
            }
            else {
                return Ok(new Models.ResponseData() { code = 500, msg = "账号密码有误" });
            }

        }
        // 开启数据库
        public void openSql()
        {
            strCon.Open();
        }
        // 关闭数据库
        public void CloseSql()
        {
            strCon.Close();
        }

    }
}
