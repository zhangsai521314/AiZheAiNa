using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace AiZheAiNa.Ashx
{
    /// <summary>
    /// Jsonp 的摘要说明
    /// </summary>
    public class Jsonp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string jsonpValue = context.Request.QueryString["zhangzhixia"];
                // string s = jsonpValue + "([" + JsonConvert.SerializeObject(new Message()) + "])";

                string s = jsonpValue + "([" + "{ \"zongye\":\"20\",\"json\":[" + JsonConvert.SerializeObject(new jsonList()) + "]}" + "])";
                context.Response.Write(s);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class jsonList
    {
        public int id = 1;
        public string name = "name";
        public string gen = "gen";
        public string ss = "ss";
        public string vvv = "vvv";

    }

    public class Message
    {
        public int id = 1;
        public string name = "name";
        public string gen = "gen";
        public string ss = "ss";
        public string vvv = "vvv";

    }
}