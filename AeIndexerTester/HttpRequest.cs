using System.Text;
using Flurl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AeIndexerTester;

using Flurl.Http;



public class HttpRequest
{
    private string _baseUrl;
    private string _path;
    private string _method;
    private Dictionary<string, object>? _headers;
    private string _contentType;
    private object _param;
    private static HttpRequest instance;

    private RestResponse response;
    // private string access_token;

    private HttpRequest()
    {
        _baseUrl = "";
        _path = "";
        _method = "post";
        _contentType = "application/json";
        _headers = new Dictionary<string, object>();
        // access_token = "";

    }

    private static HttpRequest getHttpRequest()
    {
        if (null == instance)
        {
            instance = new HttpRequest();
        }
        return instance;
    }
    

    public static HttpRequest BaseUrl(string baseUrl)
    {
        instance = new HttpRequest();
        // HttpRequest httpRequest = getHttpRequest();

        instance._baseUrl = baseUrl;
        return instance;
    }
    
    public  HttpRequest Path(string path)
    {
        // HttpRequest httpRequest = getHttpRequest();

        instance._path = path;
        return instance;
    }
    
    public  HttpRequest HttpMethod(string method)
    {
        // HttpRequest httpRequest = getHttpRequest();

        instance._method = method;
        return instance;
    }
    
    public HttpRequest ContentType(string contentType)
    {
        // HttpRequest httpRequest = getHttpRequest();

        instance._contentType = contentType;
        return instance;
    }
    
    public HttpRequest Headers(Dictionary<string, object> headers)
    {
        // HttpRequest httpRequest = getHttpRequest();

        instance._headers = headers;
        return instance;
    }
    
    public HttpRequest Params(object param)
    {
        // HttpRequest httpRequest = getHttpRequest();

        instance._param = param;
        return instance;
    }
    
    public HttpRequest AddHeader(string headerKey, object headerValue)
    {
        // HttpRequest httpRequest = getHttpRequest();

        instance._headers[headerKey] = headerValue;
        return instance;
    }

    // public HttpRequest ExecWithAuth(JObject json)
    // {
    //     instance._headers["Authorization"] = "Bearer " + json.SelectToken("$.access_token");
    //     return Exec();
    // }
    // public HttpRequest JsonExec()
    // {
    //     instance._contentType = "application/json";
    //     return Exec();
    // }
    // public HttpRequest FormExec()
    // {
    //     instance._contentType = "application/x-www-form-urlencoded";
    //     return Exec();
    // }
    //默认
    public HttpRequest Exec(OneCaseDto oneCaseDto)
    {
        if (null == instance)
        {
            return null;
        }
        else
        {
           var client = new RestClient(instance._baseUrl);

            // 创建 RestRequest，指定资源路径和使用 POST 方法
            var request = new RestRequest(instance._path, Method.Post);
            
            
            
            // var client = new RestClient();

            // var request = new RestRequest(instance._baseUrl + instance._path, Method.Get);
            
            
            if ("get".Equals(instance._method))
            {
                request = new RestRequest(instance._path, Method.Get);
            }

            string contentType = instance._contentType;
            bool haveauth = false;
            foreach (var header in instance._headers)
            {
                request.AddHeader(header.Key, header.Value.ToString());
                
                if ("Content-Type".ToLower().Equals(header.Key.ToLower()))
                {
                    contentType = header.Value.ToString();
                }
                else
                {
                    
                }
                if ("Authorization".ToLower().Equals(header.Key.ToLower()))
                {
                    haveauth = true;
                }

            }

            //没有显示传Authorization，则使用默认管理的认证
            if (!haveauth && null!=oneCaseDto.AccessToken)
            {
                request.AddHeader("Authorization", oneCaseDto.AccessToken);
            }
            
            // oneCaseDto.AccessToken = "Bearer " + JObject.Parse(response.Content).SelectToken("$.access_token");
            // instance._headers["Authorization"] = "Bearer " + JObject.Parse(response.Content).SelectToken("$.access_token");

            if ("application/x-www-form-urlencoded".Equals(contentType.ToLower()))
            {
                // request.AddHeader("Content-Type", contentType.ToLower());
                JObject json = JObject.Parse(instance._param.ToString());
                // 遍历键值对
                foreach (var property in json.Properties())
                {
                    Console.WriteLine($"Key: {property.Name}, Value: {property.Value}");
                    request.AddParameter(property.Name, property.Value.ToString());
                }
                
            }
            else if ("application/json".Equals(contentType.ToLower()))
            {
                Console.WriteLine("000999111");
                
                // string jsonParam = instance._param.ToString().Replace("\"", "\\\"").Replace("\r\n", "").Replace("\n", "").Replace("  ", "");
                // JObject json = JObject.Parse(instance._param.ToString());
                
                // 设置请求体为 JSON 格式
                // request.RequestFormat = DataFormat.Json;

                // 序列化为 JSON 并添加到请求体
                string jsonString = JsonConvert.SerializeObject(instance._param);

                // 直接添加 JSON 字符串到请求体
                request.AddParameter("application/json", jsonString, ParameterType.RequestBody);

                // var jsonData = new
                // {
                //     chainId = "AELF",
                //     startBlockHeight = 7000000,
                //     endBlockHeight = 7000002,  // 确保字符串格式
                //     isOnlyConfirmed = false
                // };
                // request.AddJsonBody(jsonData);
                
            }
            //待完善
            else
            {
                JObject json = JObject.Parse(instance._param.ToString());
                // 遍历键值对
                foreach (var property in json.Properties())
                {
                    Console.WriteLine($"Key: {property.Name}, Value: {property.Value}");
                    request.AddParameter(property.Name, property.Value.ToString());
                }
            }
            ;
            
            Console.WriteLine(ConvertToCurl(client, request));
            // 发送请求并得到响应
            var response = client.Execute(request);
            

            // 检查响应的内容
            if (response.IsSuccessful)
            {
                Console.WriteLine("Request was successful!");
                Console.WriteLine(response.Content);
                instance.response = response;

                if (_path.EndsWith("/connect/token"))
                {
                    oneCaseDto.AccessToken = "Bearer " + JObject.Parse(response.Content).SelectToken("$.access_token");

                }
              

                return instance;//response.Content;
                // if (resultType is JArray jArray)
                // {
                //     return JArray.Parse(response.Content);
                // }
                // if (resultType is JObject jobj)
                // {
                //     return JObject.Parse(response.Content);
                // }

                // if (typeof(T) == typeof(JObject))
                // {
                //     return JObject.Parse(response.Content);
                // }
                // else
                // {
                //     return JArray.Parse(response.Content);
                // }
                // var json = JObject.Parse(response.Content);
                // var jarray = JArray.Parse(response.Content);

                // json[""]
                // 动态访问 JSON 数据
                // Console.WriteLine($"access_token: {json["access_token"]}");
                // Console.WriteLine($"token_type: {json["token_type"]}");
                // Console.WriteLine($"expires_in: {json["expires_in"]}");
                // Console.WriteLine($"Completed: {json["completed"]}");

                // if(null != json.SelectToken("$.access_token"))
                // {
                //     instance._headers["Authorization"] = "Bearer " + json.SelectToken("$.access_token");
                // }

                // return jarray;
                // return json;

            }
            else
            {
                Console.WriteLine("Request failed.");
                Console.WriteLine(response.ErrorException);
                Console.WriteLine(response.ErrorMessage);
                Console.WriteLine(response.Content);
                return null;
            } 
        }
    }
    
    public HttpRequest QuickExec()
    {
        if (null == instance)
        {
            return null;
        }
        else
        {
           var client = new RestClient(instance._baseUrl);

            // 创建 RestRequest，指定资源路径和使用 POST 方法
            var request = new RestRequest(instance._path, Method.Post);
            
            
            
            // var client = new RestClient();

            // var request = new RestRequest(instance._baseUrl + instance._path, Method.Get);
            
            
            if ("get".Equals(instance._method))
            {
                request = new RestRequest(instance._path, Method.Get);
            }

            string contentType = instance._contentType;
            // bool haveauth = false;
            foreach (var header in instance._headers)
            {
                request.AddHeader(header.Key, header.Value.ToString());
                
                if ("Content-Type".ToLower().Equals(header.Key.ToLower()))
                {
                    contentType = header.Value.ToString();
                }
                else
                {
                    
                }
                // if ("Authorization".ToLower().Equals(header.Key.ToLower()))
                // {
                //     haveauth = true;
                // }

            }

            //没有显示传Authorization，则使用默认管理的认证
            // if (!haveauth && null!=oneCaseDto.AccessToken)
            // {
            //     request.AddHeader("Authorization", oneCaseDto.AccessToken);
            // }
            
            // oneCaseDto.AccessToken = "Bearer " + JObject.Parse(response.Content).SelectToken("$.access_token");
            // instance._headers["Authorization"] = "Bearer " + JObject.Parse(response.Content).SelectToken("$.access_token");

            if ("application/x-www-form-urlencoded".Equals(contentType.ToLower()))
            {
                // request.AddHeader("Content-Type", contentType.ToLower());
                JObject json = JObject.Parse(instance._param.ToString());
                // 遍历键值对
                foreach (var property in json.Properties())
                {
                    Console.WriteLine($"Key: {property.Name}, Value: {property.Value}");
                    request.AddParameter(property.Name, property.Value.ToString());
                }
                
            }
            else if ("application/json".Equals(contentType.ToLower()))
            {
                Console.WriteLine("000999111");
                
                // string jsonParam = instance._param.ToString().Replace("\"", "\\\"").Replace("\r\n", "").Replace("\n", "").Replace("  ", "");
                // JObject json = JObject.Parse(instance._param.ToString());
                
                // 设置请求体为 JSON 格式
                // request.RequestFormat = DataFormat.Json;

                // 序列化为 JSON 并添加到请求体
                string jsonString = JsonConvert.SerializeObject(instance._param);

                // 直接添加 JSON 字符串到请求体
                request.AddParameter("application/json", jsonString, ParameterType.RequestBody);

                // var jsonData = new
                // {
                //     chainId = "AELF",
                //     startBlockHeight = 7000000,
                //     endBlockHeight = 7000002,  // 确保字符串格式
                //     isOnlyConfirmed = false
                // };
                // request.AddJsonBody(jsonData);
                
            }
            //待完善
            else
            {
                JObject json = JObject.Parse(instance._param.ToString());
                // 遍历键值对
                foreach (var property in json.Properties())
                {
                    Console.WriteLine($"Key: {property.Name}, Value: {property.Value}");
                    request.AddParameter(property.Name, property.Value.ToString());
                }
            }
            ;
            
            Console.WriteLine(ConvertToCurl(client, request));
            // 发送请求并得到响应
            var response = client.Execute(request);
            

            // 检查响应的内容
            if (response.IsSuccessful)
            {
                Console.WriteLine("Request was successful!");
                Console.WriteLine(response.Content);
                instance.response = response;

                // if (_path.EndsWith("/connect/token"))
                // {
                //     oneCaseDto.AccessToken = "Bearer " + JObject.Parse(response.Content).SelectToken("$.access_token");
                //
                // }
              

                return instance;//response.Content;
                // if (resultType is JArray jArray)
                // {
                //     return JArray.Parse(response.Content);
                // }
                // if (resultType is JObject jobj)
                // {
                //     return JObject.Parse(response.Content);
                // }

                // if (typeof(T) == typeof(JObject))
                // {
                //     return JObject.Parse(response.Content);
                // }
                // else
                // {
                //     return JArray.Parse(response.Content);
                // }
                // var json = JObject.Parse(response.Content);
                // var jarray = JArray.Parse(response.Content);

                // json[""]
                // 动态访问 JSON 数据
                // Console.WriteLine($"access_token: {json["access_token"]}");
                // Console.WriteLine($"token_type: {json["token_type"]}");
                // Console.WriteLine($"expires_in: {json["expires_in"]}");
                // Console.WriteLine($"Completed: {json["completed"]}");

                // if(null != json.SelectToken("$.access_token"))
                // {
                //     instance._headers["Authorization"] = "Bearer " + json.SelectToken("$.access_token");
                // }

                // return jarray;
                // return json;

            }
            else
            {
                Console.WriteLine("Request failed.");
                Console.WriteLine(response.ErrorException);
                Console.WriteLine(response.ErrorMessage);
                Console.WriteLine(response.Content);
                return null;
            } 
        }
    }

    public JArray ToJArray()
    {
        return JArray.Parse(instance.response.Content);
    }
    
    public JObject ToJObject()
    {
        return JObject.Parse(instance.response.Content);
    }
    
    public string ToString()
    {
        return instance.response.Content;
    }
    
    public static string ConvertRestRequestToCurl(RestRequest request)
    {
        // client.BaseUrl = "1";
        // var baseUrl = client.BaseUrl == null ? "" : client.BaseUrl.ToString();
        // var baseUrl =  request.get

        var resource = request.Resource ?? "";
        var url = $"{resource}";

        foreach (var VARIABLE in request.Parameters)
        {
            Console.WriteLine(VARIABLE.Type);
        }
        
        // 处理 Query 参数
        if (request.Parameters.Any(p => p.Type == ParameterType.QueryString))
        {
            var queryParameters = string.Join("&",
                request.Parameters
                    .Where(p => p.Type == ParameterType.QueryString)
                    .Select(p => $"{p.Name}={p.Value}")
            );
            url += "?" + queryParameters;
        }

        // 初始化 curl 命令
        var curlCommand = $"curl -X {request.Method.ToString().ToUpper()} \"{url}\"";

        // 处理 Headers
        foreach (var header in request.Parameters.Where(p => p.Type == ParameterType.HttpHeader))
        {
            curlCommand += $" -H \"{header.Name}: {header.Value}\"";
        }

        // 处理 Body
        var bodyParam = request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody);
        if (bodyParam != null && bodyParam.Value != null)
        {
            var bodyContent = bodyParam.Value.ToString();
            curlCommand += $" -d '{bodyContent}'";
        }
        
        // 处理 Body
        // var bodyParam = request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody);
        // if (bodyParam != null && bodyParam.Value != null)
        // {
        //     var bodyContent = bodyParam.Value.ToString();
        //     curlCommand += $" -d '{bodyContent}'";
        // }

        return curlCommand;
    }
    
    public static string ConvertToCurl(RestRequest request)
    {
        var sb = new StringBuilder();
        sb.Append("curl");

        // Base URL
        var url = new Uri(request.Resource, UriKind.Relative);
        sb.Append($" \"{url}\"");

        // HTTP method
        sb.Append($" -X {request.Method}");

        // Headers
        foreach (var header in request.Parameters)
        {
            if (header.Type == ParameterType.HttpHeader)
            {
                sb.Append($" -H \"{header.Name}: {header.Value}\"");
            }
        }

        // Parameters (Query for GET, Body for POST)
        if (request.Method == Method.Get)
        {
            string queryString = "";
            foreach (var param in request.Parameters)
            {
                if (param.Type == ParameterType.QueryString)
                {
                    queryString = $"{queryString}{param.Name}={param.Value}&";
                }
            }

            if (queryString.Length > 0)
            {
                queryString = queryString.TrimEnd('&');
                sb.Append($" \"?{queryString}\"");
            }
        }
        else if (request.Method == Method.Post)
        {
            foreach (var param in request.Parameters)
            {
                if (param.Type == ParameterType.GetOrPost)
                {
                    sb.Append($" -d \"{param.Name}={param.Value}\"");
                }
            }
        }

        return sb.ToString();
    }
    
    
    public static string ConvertToCurl(RestClient client, RestRequest request)
    {
        var sb = new StringBuilder("curl");

        // Base URL and Resource
        var url = client.BuildUri(request);
        sb.Append($" \"{url}\"");

        // HTTP Method
        sb.Append($" -X {request.Method.ToString().ToUpper()}");

        // Headers
        foreach (var header in request.Parameters.Where(p => p.Type == ParameterType.HttpHeader))
        {
            sb.Append($" -H \"{header.Name}: {header.Value}\"");
        }

        // GetOrPost Parameters for POST and PUT
        if (request.Method == Method.Post || request.Method == Method.Put)
        {
            Console.WriteLine(100);
            foreach (var VARIABLE in request.Parameters)
            {
                Console.WriteLine(VARIABLE.Type);
            }
            foreach (var param in request.Parameters.Where(p => p.Type == ParameterType.GetOrPost))
            {
                Console.WriteLine(100);
                sb.Append($" --data-urlencode \"{param.Name}={param.Value}\"");
            }

            
            // 处理 Body
            // var bodyParam = request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody);
            // if (bodyParam != null && bodyParam.Value != null)
            // {
            //     var bodyContent = bodyParam.Value.ToString();
            //     curlCommand += $" -d '{bodyContent}'";
            // }
            
            
            // Add JSON body if there is one
            var jsonBody = request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody);
            Console.WriteLine("=============");
            // Console.WriteLine(jsonBody.ContentType);
            // if (jsonBody != null && jsonBody.Name == "application/json")
            if (jsonBody != null && jsonBody.Value != null)
            {
                Console.WriteLine(200);
                sb.Append($" -H \"Content-Type: application/json\"");
                sb.Append($" -d \'{jsonBody.Value}'");
            }
        }
        else
        {
            // Query Parameters for GET
            foreach (var param in request.Parameters.Where(p => p.Type == ParameterType.QueryString))
            {
                sb.Append($" -G --data-urlencode \"{param.Name}={param.Value}\"");
            }
        }

        return sb.ToString();
    }
}