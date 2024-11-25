using System.Text.Json;
using Newtonsoft.Json.Linq;
using Scriban;
using System.Text;
using RabbitMQ.Client;
using System;
using System.Security.Cryptography;
using System.Text;
using AElf.Types;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using Scriban;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Scriban.Runtime;

namespace AeIndexerTester;

public class CaseMaker
{
    // public void makeRequest(string file)
    // {
    //     
    // }
    
    public static void Main()
    {
        makeCaseCode();
    }


    static void makeCaseCode()
    {
        CaseForTemplateObj caseForTemplateObj = new CaseForTemplateObj();
        // 获取项目的根目录（相对于输出目录） + src路径
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        baseDir = Environment.CurrentDirectory;
        string projectDir = Directory.GetParent(baseDir).Parent.Parent.Parent.FullName;

        // 定位 src 文件夹
        string srcFolderPath = Path.Combine(projectDir, "CaseOne") + "/";

        Console.WriteLine("项目的 src 文件夹路径：" + srcFolderPath);

        var configFilePath = srcFolderPath + "CaseDescription/Template";


        List<string> configFiles = new List<string>();
        // 检查目录是否存在
        if (Directory.Exists(configFilePath))
        {
            // 调用递归函数遍历所有文件
            TraverseDirectory(configFilePath, configFiles);
        }
        else
        {
            Console.WriteLine("指定的目录不存在.");
        }

        string clazzname = "";
        foreach (var configFile in configFiles)
        {
            Console.WriteLine("指定的目录不存在." + configFile);
            string fileName = configFile.Replace(configFilePath, "");
            clazzname = fileName.Replace(".json", "").Substring(1);
            string namespacename = "";
            Console.WriteLine("123指定的目录不存在." + fileName);
            Console.WriteLine("123指定的目录不存在." + fileName.Replace("/", "."));
            string[] str = fileName.Replace("/", ".").Split(".");
            Console.WriteLine("123指定的目录不存在." + str.Length);
            for (int i = 1; i < str.Length - 2; i++)
            {
                namespacename = namespacename + "." + str[i];
            }

            if ("".Equals(namespacename))
            {
                namespacename = "CaseOne";
            }

            if (namespacename.StartsWith("."))
            {
                namespacename = namespacename.Substring(1);
            }

            namespacename = "CaseOne";

            caseForTemplateObj.NameSpaceName = namespacename;
            Console.WriteLine("指定的目录不存在.namespacename:" + namespacename);
            try
            {
                // 读取 JSON 文件内容
                string? jsonString = File.ReadAllText(configFile);
                // List<CaseObj> config = JsonConvert.DeserializeObject<List<CaseObj>>(jsonString);
                // // 将 JS
                CaseObj config = JsonConvert.DeserializeObject<CaseObj>(jsonString);

                caseForTemplateObj.CaseObj = new CaseObjForTemplate()
                {
                    SetUp = config.SetUp,
                    TearDown = config.TearDown
                };
                caseForTemplateObj.CaseObj.CaseDetail = new CaseDetailsForTemplate()
                {
                    Name = config.CaseDetail.Name,
                    Description = config.CaseDetail.Description,
                    DataProvider = config.CaseDetail.DataProvider
                };
                List<StepsForTemplate> stlst = new List<StepsForTemplate>();
                List<Steps> stls = config.CaseDetail.Steps;
                foreach (var stl in stls)
                {
                    var jsonObject = JObject.Parse(stl.Asserts.ToString());
                    List<AssertObj> assertObjList = new List<AssertObj>();
                    foreach (var property in jsonObject.Properties())
                    {
                        assertObjList.Add(new AssertObj()
                        {
                            AssertPath = property.Name,
                            ExpectValue = property.Value
                        });
                    }
                    
                    string resType = "JObject";
                    if (null != stl.ResponseType)
                    {
                        resType = stl.ResponseType;
                    }

                    //参数处理，增加json引号
                    Request re = stl.Request;
                    string paramstr = re.Params.ToString();
                    // paramstr.Replace("\"", "\\\"").Replace("\r\n", "").Replace("\n", "").Replace(" ", "");;
                    // JObject jo = JObject.Parse(re.Params.ToString());
                    re.Params = paramstr.Replace("\"", "\\\"").Replace("\r\n", "").Replace("\n", "").Replace("  ", "");
                    // re.Params = JsonSerializer.Serialize(re.Params.ToString());

                    stlst.Add(new StepsForTemplate()
                    {
                        StepNo = stl.StepNo,
                        Request = re,
                        Asserts = assertObjList,
                        ResponseType = resType
                    });

                }

                caseForTemplateObj.CaseObj.CaseDetail.Steps = stlst;
                Console.WriteLine("Database Connection String: " + config.CaseDetail.Name);
                // Console.teLine("Log File Path: " + appConfig.Logging.LogFilePath);

                caseForTemplateObj.ClazzName = clazzname;
                

                string path = projectDir + "/AeIndexerTester/test_template2.sbn";
                if (null != caseForTemplateObj.CaseObj.CaseDetail.DataProvider)
                {
                    path = projectDir + "/AeIndexerTester/test_template.sbn";
                }

                // string path = projectDir + "/AeIndexerTester/test_template.sbn";
                string fileContent = File.ReadAllText(path);
                // 创建模板
                var template = Template.Parse(fileContent);

                var result = template.Render(new { case_for_template_obj = caseForTemplateObj });
                // 渲染模板并生成测试代码
                // string result = template.Render(model);

                // 将生成的代码保存到文件中
                File.WriteAllText(srcFolderPath + caseForTemplateObj.ClazzName + ".cs", result);

                // 打印生成的代码
                Console.WriteLine("Generated Test Code:\n");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("读取配置文件时出错: " + ex.Message);
            }
        }

        static void TraverseDirectory(string directoryPath, List<string> configFiles)
        {
            try
            {
                // 获取当前目录下的所有文件
                string[] files = Directory.GetFiles(directoryPath);
                foreach (var file in files)
                {
                    Console.WriteLine(file); // 输出文件名
                    configFiles.Add(file);
                }

                // 获取当前目录下的所有子目录并递归遍历
                string[] subDirectories = Directory.GetDirectories(directoryPath);
                foreach (var subDirectory in subDirectories)
                {
                    TraverseDirectory(subDirectory, configFiles); // 递归调用自身
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"遍历目录 {directoryPath} 时出错: {ex.Message}");
            }
        }

    }
}

public class CaseObj
{
    // public string CaseName { get; set; }
    // public string CaseDescription { get; set; }
    // public List<CaseDetail> Detail { get; set; }
    
    public object SetUp { get; set; }
    public object TearDown { get; set; }
    public CaseDetails CaseDetail { get; set; }
}

public class CaseObjForTemplate
{
    // public string CaseName { get; set; }
    // public string CaseDescription { get; set; }
    // public List<CaseDetail> Detail { get; set; }
    
    public object SetUp { get; set; }
    public object TearDown { get; set; }
    public CaseDetailsForTemplate CaseDetail { get; set; }
}

public class CaseForTemplateObj
{
    // public string CaseName { get; set; }
    // public string CaseDescription { get; set; }
    // public List<CaseDetail> Detail { get; set; }
    
    public string NameSpaceName { get; set; }
    public string ClazzName { get; set; }
    
    public CaseObjForTemplate CaseObj { get; set; }
}

public class CaseDetails
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Steps> Steps { get; set; }
    public string DataProvider { get; set; }
}
public class CaseDetailsForTemplate
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<StepsForTemplate> Steps { get; set; }
    public string DataProvider { get; set; }
}

public class Steps
{
    public int StepNo { get; set; }
    // public string Description { get; set; }
    // public List<CaseDetail> Detail { get; set; }
    public Request Request  { get; set; }
    public object Asserts { get; set; }
    public string ResponseType { get; set; }
}

public class StepsForTemplate
{
    public int StepNo { get; set; }
    // public string Description { get; set; }
    // public List<CaseDetail> Detail { get; set; }
    public Request Request  { get; set; }
    public List<AssertObj> Asserts { get; set; }
    public string ResponseType { get; set; }
}

public class Request
{
    public string BaseUrl { get; set; }
    public string Path { get; set; }
    public string ContentType { get; set; }
    public Dictionary<string, object> Headers { get; set; }
    public object Params { get; set; }
    public string MethodName { get; set; }
    
}

// public class Asserts
// {
//     public int StepNo { get; set; }
//     public string Description { get; set; }
//     public List<CaseDetail> Detail { get; set; }
// }

public class CaseDetail
{
    public int StepNo { get; set; }
    public string BaseUrl { get; set; }
    public string Path { get; set; }
    public Dictionary<string, object> Headers { get; set; }
    public object Params { get; set; }
    public string MethodName { get; set; }
    public object Asserts { get; set; }
}

public class DataProviderObj
{
    public int StepNo  { get; set; }
    public object Params { get; set; }
    public object Asserts { get; set; }
}

public class AssertObj
{
    public string AssertPath { get; set; }
    public object ExpectValue { get; set; }
}