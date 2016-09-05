using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
namespace AiZheAiNa.Ashx
{
    /// <summary>
    /// GetJson 的摘要说明
    /// </summary>
    public class GetJson : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            jsonList model = new jsonList();
            string f = context.Request["pageIndex"];
            model.id = f;
            string s = "{ \"zongye\":\"20\",\"json\":[" + JsonConvert.SerializeObject(model) + "]}";
            context.Response.Write(s);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        public class jsonList
        {
            public string id = "1";
            public string name = "name";
            public string gen = "gen";
            public string ss = "ss";
            public string vvv = "vvv";

        }

    }
}