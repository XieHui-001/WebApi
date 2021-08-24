using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
namespace WebApi.Controllers
{
    public class ContactController : ApiController
    {
        Users[] contacts = new Users[] {
            new Users(){ ID=1,age_=20,Birthday=Convert.ToDateTime("1988-07-25"),name_="嗷叫",sex_="男"},
            new Users(){ ID=2,age_=18,Birthday=Convert.ToDateTime("1988-07-3"),name_="阿拉斯",sex_="女"},
            new Users(){ ID=3,age_=1,Birthday=Convert.ToDateTime("1988-07-26"),name_="网袜",sex_="女"},
            new Users(){ ID=4,age_=4,Birthday=Convert.ToDateTime("1988-07-5"),name_="哈子",sex_="男"}
        };

        public IEnumerable<Users> GetListAll()
        {
            return contacts;
        }

        public Users PostContactByID(int id)
        {
            Users contact = contacts.FirstOrDefault<Users>(item => item.ID == id);
            if (contact == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return contact;
        }

        public IEnumerable<Users> GetListBySex(string sex)
        {
            return contacts.Where(item => item.sex_ == sex);
        }
    }
}
