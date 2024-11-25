using Flurl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace AeIndexerTester;

using Flurl.Http;



public class HttpTools
{
    // public static JObject? HttpPostJsonRequestJson(string baseUrl, string path, string contentType, Dictionary<string, object>? headers, object param)
    // {
    //     return HttpRequest( baseUrl,  path, "post",  headers, "contentType", param);
    //     
    // }
    
    public static JObject? HttpPostRequestJson(string baseUrl, string path, string contentType, Dictionary<string, object>? headers, object param)
    {
        return HttpRequest( baseUrl,  path, "post",  headers, contentType, param);
        
    }
    public static JObject? HttpPostJsonRequestJson(string baseUrl, string path, Dictionary<string, object>? headers, object param)
    {
        return HttpRequest( baseUrl,  path, "post",  headers, "application/json", param);
        
    }
    
    public static JObject? HttpGetRequestJson(string baseUrl, string path, string contentType, Dictionary<string, object>? headers, object param)
    {
        return HttpRequest( baseUrl,  path, "get",  headers, contentType, param);
        
    }
    // public static JObject? HttpGetRequestJson(string baseUrl, string path, string contentType, object param)
    // {
    //     return HttpRequest( baseUrl,  path, "get",  headers, contentType, param);
    //     
    // }
    
    public static JObject? HttpGetJsonRequestJson(string baseUrl, string path, object param)
    {
        return HttpRequest( baseUrl,  path, "get", "application/json", param);
    }
    public static JObject? HttpGetFormRequestJson(string baseUrl, string path, object param)
    {
        return HttpRequest( baseUrl,  path, "get", "application/x-www-form-urlencoded", param);
    }
    public static JObject? HttpPostJsonRequestJson(string baseUrl, string path, object param)
    {
        return HttpRequest( baseUrl,  path, "post", "application/json", param);
    }
    public static JObject? HttpPostFormRequestJson(string baseUrl, string path, object param)
    {
        return HttpRequest( baseUrl,  path, "post", "application/x-www-form-urlencoded", param);
    }
    
    public static JObject? HttpRequest(string baseUrl, string path, string method, Dictionary<string, object>? headers, object param)
    {
        // object Params
        // Dictionary<string, object> Headers
        // Dictionary<string, object>? p
        // 创建 RestClient 并设置基础 URL
        var client = new RestClient(baseUrl);

        // 创建 RestRequest，指定资源路径和使用 POST 方法
        var request = new RestRequest(path, Method.Post);
        if ("get".Equals(method))
        {
            request = new RestRequest(path, Method.Get);
        }

        string contentType = "";
        foreach (var header in headers)
        {
            request.AddHeader(header.Key, header.Value.ToString());
            if ("Content-Type".ToLower().Equals(header.Key.ToLower()))
            {
                contentType = header.Value.ToString();
            }

        }

        if ("application/x-www-form-urlencoded".Equals(contentType.ToLower()))
        {
            JObject json = JObject.Parse(param.ToString());
            // 遍历键值对
            foreach (var property in json.Properties())
            {
                Console.WriteLine($"Key: {property.Name}, Value: {property.Value}");
                request.AddParameter(property.Name, property.Value.ToString());
            }
            
        }
        else if ("application/json".Equals(contentType.ToLower()))
        {
            JObject json = JObject.Parse(param.ToString());
            
            // 设置请求体为 JSON 格式
            request.RequestFormat = DataFormat.Json;

            // 序列化为 JSON 并添加到请求体
            request.AddJsonBody(json);
            
        }
        //待完善
        else
        {
            JObject json = JObject.Parse(param.ToString());
            // 遍历键值对
            foreach (var property in json.Properties())
            {
                Console.WriteLine($"Key: {property.Name}, Value: {property.Value}");
                request.AddParameter(property.Name, property.Value.ToString());
            }
        }
        ;
        
        // 发送请求并得到响应
        var response = client.Execute(request);

        // 检查响应的内容
        if (response.IsSuccessful)
        {
            Console.WriteLine("Request was successful!");
            Console.WriteLine(response.Content);
            
            
            var json = JObject.Parse(response.Content);

            // json[""]
            // 动态访问 JSON 数据
            // Console.WriteLine($"access_token: {json["access_token"]}");
            // Console.WriteLine($"token_type: {json["token_type"]}");
            // Console.WriteLine($"expires_in: {json["expires_in"]}");
            // Console.WriteLine($"Completed: {json["completed"]}");
            return json;

        }
        else
        {
            Console.WriteLine("Request failed.");
            Console.WriteLine(response.Content);
            return null;
        }
    }
    
    
    public static JObject? HttpRequest(string baseUrl, string path, string method, Dictionary<string, object>? headers,  string contentType, object param)
    {
        // object Params
        // Dictionary<string, object> Headers
        // Dictionary<string, object>? p
        // 创建 RestClient 并设置基础 URL
        var client = new RestClient(baseUrl);

        // 创建 RestRequest，指定资源路径和使用 POST 方法
        var request = new RestRequest(path, Method.Post);
        if ("get".Equals(method))
        {
            request = new RestRequest(path, Method.Get);
        }

        // string contentType = "";
        foreach (var header in headers)
        {
            request.AddHeader(header.Key, header.Value.ToString());
            if ("Content-Type".ToLower().Equals(header.Key.ToLower()))
            {
                contentType = header.Value.ToString();
            }

        }

        if ("application/x-www-form-urlencoded".Equals(contentType.ToLower()))
        {
            JObject json = JObject.Parse(param.ToString());
            // 遍历键值对
            foreach (var property in json.Properties())
            {
                Console.WriteLine($"Key: {property.Name}, Value: {property.Value}");
                request.AddParameter(property.Name, property.Value.ToString());
            }
            
        }
        else if ("application/json".Equals(contentType.ToLower()))
        {
            JObject json = JObject.Parse(param.ToString());
            
            // 设置请求体为 JSON 格式
            request.RequestFormat = DataFormat.Json;

            // 序列化为 JSON 并添加到请求体
            request.AddJsonBody(json);
            
        }
        //待完善
        else
        {
            JObject json = JObject.Parse(param.ToString());
            // 遍历键值对
            foreach (var property in json.Properties())
            {
                Console.WriteLine($"Key: {property.Name}, Value: {property.Value}");
                request.AddParameter(property.Name, property.Value.ToString());
            }
        }
        ;
        
        // 发送请求并得到响应
        var response = client.Execute(request);

        // 检查响应的内容
        if (response.IsSuccessful)
        {
            Console.WriteLine("Request was successful!");
            Console.WriteLine(response.Content);
            
            
            var json = JObject.Parse(response.Content);

            // json[""]
            // 动态访问 JSON 数据
            // Console.WriteLine($"access_token: {json["access_token"]}");
            // Console.WriteLine($"token_type: {json["token_type"]}");
            // Console.WriteLine($"expires_in: {json["expires_in"]}");
            // Console.WriteLine($"Completed: {json["completed"]}");
            return json;

        }
        else
        {
            Console.WriteLine("Request failed.");
            Console.WriteLine(response.Content);
            return null;
        }
    }
    
    public static JObject? HttpRequest(string baseUrl, string path, string method,  string contentType, object param)
    {
        // object Params
        // Dictionary<string, object> Headers
        // Dictionary<string, object>? p
        // 创建 RestClient 并设置基础 URL
        var client = new RestClient(baseUrl);

        // 创建 RestRequest，指定资源路径和使用 POST 方法
        var request = new RestRequest(path, Method.Post);
        if ("get".Equals(method))
        {
            request = new RestRequest(path, Method.Get);
        }

        // string contentType = "";
        // foreach (var header in headers)
        // {
        //     request.AddHeader(header.Key, header.Value.ToString());
        //     if ("Content-Type".ToLower().Equals(header.Key.ToLower()))
        //     {
        //         contentType = header.Value.ToString();
        //     }
        //
        // }

        if ("application/x-www-form-urlencoded".Equals(contentType.ToLower()))
        {
            JObject json = JObject.Parse(param.ToString());
            // 遍历键值对
            foreach (var property in json.Properties())
            {
                Console.WriteLine($"Key: {property.Name}, Value: {property.Value}");
                request.AddParameter(property.Name.ToLower(), property.Value.ToString());
            }
            
        }
        else if ("application/json".Equals(contentType.ToLower()))
        {
            JObject json = JObject.Parse(param.ToString());
            
            // 设置请求体为 JSON 格式
            request.RequestFormat = DataFormat.Json;

            // 序列化为 JSON 并添加到请求体
            request.AddJsonBody(json);
            
        }
        //待完善
        else
        {
            JObject json = JObject.Parse(param.ToString());
            // 遍历键值对
            foreach (var property in json.Properties())
            {
                Console.WriteLine($"Key: {property.Name}, Value: {property.Value}");
                request.AddParameter(property.Name, property.Value.ToString());
            }
        }
        ;
        
        // 发送请求并得到响应
        var response = client.Execute(request);

        // 检查响应的内容
        if (response.IsSuccessful)
        {
            Console.WriteLine("Request was successful!");
            Console.WriteLine(response.Content);
            
            
            var json = JObject.Parse(response.Content);

            // json[""]
            // 动态访问 JSON 数据
            // Console.WriteLine($"access_token: {json["access_token"]}");
            // Console.WriteLine($"token_type: {json["token_type"]}");
            // Console.WriteLine($"expires_in: {json["expires_in"]}");
            // Console.WriteLine($"Completed: {json["completed"]}");
            return json;

        }
        else
        {
            Console.WriteLine("Request failed.");
            Console.WriteLine(response.Content);
            return null;
        }
    }
    
    public static JObject? GetRequest(string baseUrl, string path, Dictionary<string, object> headers, object param)
    {
        // object Params
        // Dictionary<string, object> Headers
        // Dictionary<string, object>? p
        // 创建 RestClient 并设置基础 URL
        var client = new RestClient(baseUrl);

        // 创建 RestRequest，指定资源路径和使用 POST 方法
        var request = new RestRequest(path, Method.Get);
        

        string contentType = "";
        foreach (var header in headers)
        {
            request.AddHeader(header.Key, header.Value.ToString());
            if ("Content-Type".ToLower().Equals(header.Key.ToLower()))
            {
                contentType = header.Value.ToString();
            }

        }

        if ("application/x-www-form-urlencoded".Equals(contentType.ToLower()))
        {
            JObject json = JObject.Parse(param.ToString());
            // 遍历键值对
            foreach (var property in json.Properties())
            {
                Console.WriteLine($"Key: {property.Name}, Value: {property.Value}");
                request.AddParameter(property.Name, property.Value.ToString());
            }
            
        }
        else if ("application/json".Equals(contentType.ToLower()))
        {
            JObject json = JObject.Parse(param.ToString());
            
            // 设置请求体为 JSON 格式
            request.RequestFormat = DataFormat.Json;

            // 序列化为 JSON 并添加到请求体
            request.AddJsonBody(json);
            
        }
        //待完善
        else
        {
            JObject json = JObject.Parse(param.ToString());
            // 遍历键值对
            foreach (var property in json.Properties())
            {
                Console.WriteLine($"Key: {property.Name}, Value: {property.Value}");
                request.AddParameter(property.Name, property.Value.ToString());
            }
        }
        ;
        
        // 发送请求并得到响应
        var response = client.Execute(request);

        // 检查响应的内容
        if (response.IsSuccessful)
        {
            Console.WriteLine("Request was successful!");
            Console.WriteLine(response.Content);
            
            var json = JObject.Parse(response.Content);

            return json;

        }
        else
        {
            Console.WriteLine("Request failed.");
            Console.WriteLine(response.Content);
            return null;
        }
    }
    
    public JObject? RestTest(CaseDetail caseDetail)
    {
        // Dictionary<string, object>? p
        // 创建 RestClient 并设置基础 URL
        var client = new RestClient(caseDetail.BaseUrl);

        // 创建 RestRequest，指定资源路径和使用 POST 方法
        var request = new RestRequest(caseDetail.Path, Method.Post);
        if ("post".Equals(caseDetail.MethodName))
        {
            request = new RestRequest(caseDetail.Path, Method.Post);
        }
        else
        {
            request = new RestRequest(caseDetail.Path, Method.Get);
        }


        string contentType = "";
        foreach (var VARIABLE in caseDetail.Headers)
        {
            request.AddHeader(VARIABLE.Key, VARIABLE.Value.ToString());

        }

        if ("application/x-www-form-urlencoded".Equals(contentType))
        {
            JObject json = JObject.Parse(caseDetail.Params.ToString());
            // 遍历键值对
            foreach (var property in json.Properties())
            {
                Console.WriteLine($"Key: {property.Name}, Value: {property.Value}");
                request.AddParameter(property.Name, property.Value.ToString());
            }
            
        }
        else
        {
            JObject json = JObject.Parse(caseDetail.Params.ToString());
            
            
            // 设置请求体为 JSON 格式
            request.RequestFormat = DataFormat.Json;

            // // 创建一个要传递的 JSON 对象
            // var data = new
            // {
            //     // 这里是你的 JSON 参数
            //     key1 = "value1",
            //     key2 = "value2"
            // };

            // 序列化为 JSON 并添加到请求体
            request.AddJsonBody(json);
            
        }
        // 添加 ContentType 头部为 application/x-www-form-urlencoded
        // request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

        // 添加表单参数
        // request.AddParameter("username", "admin");
        // request.AddParameter("password", "1q2W3e*");
        // request.AddParameter("client_id", "AeFinder_App");
        // request.AddParameter("grant_type", "password");
        // request.AddParameter("scope", "AeFinder");
        
        // 发送请求并得到响应
        var response = client.Execute(request);

        // 检查响应的内容
        if (response.IsSuccessful)
        {
            Console.WriteLine("Request was successful!");
            Console.WriteLine(response.Content);
            
            
            var json = JObject.Parse(response.Content);

            // json[""]
            // 动态访问 JSON 数据
            Console.WriteLine($"access_token: {json["access_token"]}");
            Console.WriteLine($"token_type: {json["token_type"]}");
            Console.WriteLine($"expires_in: {json["expires_in"]}");
            // Console.WriteLine($"Completed: {json["completed"]}");
            return json;

        }
        else
        {
            Console.WriteLine("Request failed.");
            Console.WriteLine(response.Content);
            return null;
        }
    }
    
    public JObject? RestTest()
    {
        // 创建 RestClient 并设置基础 URL
        var client = new RestClient("http://192.168.71.128:8082");

        // 创建 RestRequest，指定资源路径和使用 POST 方法
        var request = new RestRequest("/connect/token", Method.Post);

        // 添加 ContentType 头部为 application/x-www-form-urlencoded
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

        // 添加表单参数
        request.AddParameter("username", "admin");
        request.AddParameter("password", "1q2W3e*");
        request.AddParameter("client_id", "AeFinder_App");
        request.AddParameter("grant_type", "password");
        request.AddParameter("scope", "AeFinder");
        
        // 发送请求并得到响应
        var response = client.Execute(request);

        // 检查响应的内容
        if (response.IsSuccessful)
        {
            Console.WriteLine("Request was successful!");
            Console.WriteLine(response.Content);
            
            
            var json = JObject.Parse(response.Content);

            // 动态访问 JSON 数据
            Console.WriteLine($"access_token: {json["access_token"]}");
            Console.WriteLine($"token_type: {json["token_type"]}");
            Console.WriteLine($"expires_in: {json["expires_in"]}");
            // Console.WriteLine($"Completed: {json["completed"]}");
            return json;

        }
        else
        {
            Console.WriteLine("Request failed.");
            Console.WriteLine(response.Content);
            return null;
        }
    }
    
    
    
        
    static  void FormDataRequest()
    {
        // 请求的 URL
        string url = "http://192.168.71.128:8082/connect/token";

        // 创建要发送的表单数据
        var formData = new
        {
            grant_type="password",
            scope="AeFinder",
            username="admin" ,
            password="1q2W3e*" ,
            client_id="AeFinder_App",
           
        };

        try
        {
            // 使用 Flurl 发送 POST 请求，自动将对象序列化为 x-www-form-urlencoded 格式
            var response =  url
                .PostUrlEncodedAsync(formData)
                .ReceiveString(); // 接收响应作为字符串

            // 显示服务器响应
            Console.WriteLine(response);
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"Request failed: {ex.Message}");
        }
    }
        
        
    public static void Main1()
    {
        var json =  "http://192.168.71.128:8082/connect/token"
            .SetQueryParam("grant_type", "password")
            .GetJsonAsync<dynamic>();
        Console.WriteLine(json);

    }
    
    
    
    // public static void  Main()
    // {
    //     string url = "http://192.168.71.128:8082/connect/token";
    //
    //     // 创建要发送的表单数据
    //     var formData = new
    //     {
    //         grant_type="password",
    //         scope="AeFinder",
    //         username="admin" ,
    //         password="1q2W3e*" ,
    //         client_id="AeFinder_App",
    //        
    //     };
    //     
    //     
    //     
    //     // string url = "https://api.example.com/post-endpoint";
    //     //
    //     // var postData = new
    //     // {
    //     //     Name = "John Doe",
    //     //     Age = 30
    //     // };
    //
    //     try
    //     {
    //         // 发起同步 POST 请求并获取响应
    //         var response = url.PostUrlEncodedAsync(formData).Result;
    //
    //         // 显示响应内容
    //         Console.WriteLine(response);
    //     }
    //     catch (FlurlHttpException ex)
    //     {
    //         // 捕获请求异常
    //         Console.WriteLine($"Request failed: {ex.Message}");
    //         var error = ex.GetResponseJsonAsync<dynamic>().Result;
    //         Console.WriteLine($"Error response: {error}");
    //     }
    // }
        
        
        

        // try
        // {
        //     // 使用 Flurl 发送 POST 请求，自动将对象序列化为 x-www-form-urlencoded 格式
        //     var response =  url
        //         .PostUrlEncodedAsync(formData)
        //         .ReceiveJson<dynamic>(); // 接收响应作为字符串
        //
        //     // 显示服务器响应
        //     Console.WriteLine(response);
        // }
        // catch (FlurlHttpException ex)
        // {
        //     Console.WriteLine($"Request failed: {ex.Message}");
        // }
        // catch (Exception ex)
        // {
        //     // 处理其它类型的异常
        //     Console.WriteLine($"Unexpected error: {ex.Message}");
        // }
        
        // // 请求的 URL
        // string url = "http://192.168.71.128:8082/connect/token";
        //
        // // 构造要发送的 JSON 数据
        // var jsonData = new
        // {
        //     Name = "John Doe",
        //     Age = 30,
        //     Email = "john.doe@example.com"
        // };
        //
        // try
        // {
        //     // 使用 Flurl 发送 POST 请求，自动将对象序列化为 JSON
        //     var response = await url
        //         .PostJsonAsync(jsonData)
        //         .ReceiveJson<dynamic>(); // 接收并解析响应为动态类型
        //
        //     // 显示服务器响应
        //     Console.WriteLine(response);
        // }
        // catch (FlurlHttpException ex)
        // {
        //     Console.WriteLine($"Request failed: {ex.Message}");
        //     // 进一步处理异常，例如检查响应内容
        // }
    // }
    
    // public static async Task Main(string[] args)
    // {
    //     Console.WriteLine("Start fetching data...");
    //
    //     // 异步调用方法并等待其完成
    //     // await Main123();
    //
    //     Console.WriteLine("Data fetch complete.");
    // }

    static void Main(string[] args)
    {
        RunAsyncTask().GetAwaiter().GetResult();
        Console.WriteLine("Async task completed using GetAwaiter().GetResult().");
    }
    // public static async Task Main123()
    static async Task RunAsyncTask()
    {
        // 目标 URL
        string url = "https://api.example.com/submit";

        // 表单数据
        var formData = new
        {
            username = "john_doe",
            password = "securepassword",
            age = 30
        };

        try
        {
            // 使用 Flurl 发送 POST 请求，数据会自动按照 x-www-form-urlencoded 格式编码
            var response = await url
                .PostUrlEncodedAsync(formData)
                .ReceiveString(); // 阻止响应内容，普通文本

            // 显示服务器响应
            Console.WriteLine(response);
        }
        catch (FlurlHttpException ex)
        {
            Console.WriteLine($"请求失败: {ex.Message}");

            // 可以进一步获取错误的响应内容
            string errorResponse = await ex.GetResponseStringAsync();
            Console.WriteLine($"错误响应: {errorResponse}");
        }
    }
    
}