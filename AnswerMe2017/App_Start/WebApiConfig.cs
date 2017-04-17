using AnswerMe2017.MessageHandlers;
using AnswerMe2017.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace AnswerMe2017
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            // 只返回 json 格式
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("datatype", "json", "application/json"));

            // Web API 配置和服务
            // config.MessageHandlers.Add(new AuthMessageHandler());
            
            // Web API 路由
            config.MapHttpAttributeRoutes();
        }
    }
}
;