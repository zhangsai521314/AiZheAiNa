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
                string data = jsonpValue + "([" + JsonConvert.SerializeObject(new Message()) + "])";
                context.Response.Write(data);
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

    public class Message
    {
        public string value = "张志霞";
    }
}