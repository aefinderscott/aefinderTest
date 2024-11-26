using AeIndexerTester;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CaseOne
{
    [TestFixture]
    public class TokenTestTests : BaseTestSetup
    {
        public static IEnumerable<Object[]?> GetData_TokenTestDataProvider()
        {
            return GetDataProvider("TokenTestDataProvider.json"); 
        }
        public static IEnumerable<Object[]?> GetData_xx()
        {
            return GetDataProvider("xx.json"); 
        }
    
        [SetUp]
        public void Setup()
        {
            SetUpBeforeEachTest(typeof(TokenTestTests));
            //makeBlocks("test001","tDVV",1,1,1);
        }
        
        [Test, TestCaseSource(nameof(GetData_TokenTestDataProvider))]
        [Description( "test001")]
        public void test001_Test(Dictionary<int, DataProviderObj> dictionary)
        {
            JObject jsResponse = new JObject();
            
            //request
            JObject result1 = HttpRequest.BaseUrl("http://192.168.71.156:8082").Path("/connect/token")
                                                    .ContentType("application/x-www-form-urlencoded")
                                                    .Params(dictionary[1].Params).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result1.SelectToken("$.access_token"));
            Assert.AreEqual(JObject.Parse(dictionary[1].Asserts.ToString())["$.token_type"].ToString(), result1.SelectToken("$.token_type").ToString());
            
            //request
            JArray result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/app/block/blocks")
                                        .ContentType("application/json")
                                        .Params(dictionary[2].Params).Exec(oneCaseDto).ToJArray();
            
            // Assert
            Assert.IsNotNull(result2.SelectToken("$[0].id"));
            Assert.AreEqual(JObject.Parse(dictionary[2].Asserts.ToString())["$[0].extraProperties.Version"].ToString(), result2.SelectToken("$[0].extraProperties.Version").ToString());
            Assert.IsNotNull(result2.SelectToken("$[0].transactionIds[1]"));
        }
        
        [Test]
        [Description( "test002")]
        public void test002_Test()
        {
            JObject param = new JObject();
            
            //request
            param = JObject.Parse("{\"username\": \"admin\",\"password\": \"1q2W3e*\",\"client_id\": \"AeFinder_App\",\"grant_type\": \"password\",\"scope\": \"AeFinder\"}");
            JObject result1 = HttpRequest.BaseUrl("http://192.168.71.156:8082").Path("/connect/token")
                                                    .ContentType("application/x-www-form-urlencoded")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result1.SelectToken("$.access_token"));
            Assert.AreEqual("Bearer", result1.SelectToken("$.token_type").ToString());
            
            //request
            param = JObject.Parse("{\"chainId\": \"AELF\",\"startBlockHeight\": 7000000,\"endBlockHeight\": 7000002,\"isOnlyConfirmed\": false}");
            JArray result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/app/block/blocks")
                                        .ContentType("application/json")
                                        .Params(param).Exec(oneCaseDto).ToJArray();
            
            // Assert
            Assert.IsNotNull(result2.SelectToken("$[0].id"));
            Assert.AreEqual("0", result2.SelectToken("$[0].extraProperties.Version").ToString());
            Assert.IsNotNull(result2.SelectToken("$[0].transactionIds[1]"));
        }
        
        [Test]
        [Description( "test003")]
        public void test003_Test()
        {
            JObject param = new JObject();
            
            //request
            param = JObject.Parse("{\"username\": \"admin\",\"password\": \"1q2W3e*\",\"client_id\": \"AeFinder_App\",\"grant_type\": \"password\",\"scope\": \"AeFinder\"}");
            JObject result1 = HttpRequest.BaseUrl("http://192.168.71.156:8082").Path("/connect/token")
                                                    .ContentType("application/x-www-form-urlencoded")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result1.SelectToken("$.access_token"));
            Assert.AreEqual("Bearer", result1.SelectToken("$.token_type").ToString());
            
            //request
            param = JObject.Parse("{\"chainId\": \"AELF\",\"startBlockHeight\": 7000000,\"endBlockHeight\": 7000002,\"isOnlyConfirmed\": false}");
            JArray result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/app/block/blocks")
                                        .ContentType("application/json")
                                        .Params(param).Exec(oneCaseDto).ToJArray();
            
            // Assert
            Assert.IsNotNull(result2.SelectToken("$[0].id"));
            Assert.AreEqual("0", result2.SelectToken("$[0].extraProperties.Version").ToString());
            Assert.IsNotNull(result2.SelectToken("$[0].transactionIds[1]"));
        }
        
        [Test, TestCaseSource(nameof(GetData_xx))]
        [Description( "test004")]
        public void test004_Test(Dictionary<int, DataProviderObj> dictionary)
        {
            JObject jsResponse = new JObject();
            
            //request
            JObject result1 = HttpRequest.BaseUrl("http://192.168.71.156:8082").Path("/connect/token")
                                                    .ContentType("application/x-www-form-urlencoded")
                                                    .Params(dictionary[1].Params).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result1.SelectToken("$.access_token"));
            Assert.AreEqual(JObject.Parse(dictionary[1].Asserts.ToString())["$.token_type"].ToString(), result1.SelectToken("$.token_type").ToString());
            
            //request
            JArray result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/app/block/blocks")
                                        .ContentType("application/json")
                                        .Params(dictionary[2].Params).Exec(oneCaseDto).ToJArray();
            
            // Assert
            Assert.IsNotNull(result2.SelectToken("$[0].id"));
            Assert.AreEqual(JObject.Parse(dictionary[2].Asserts.ToString())["$[0].extraProperties.Version"].ToString(), result2.SelectToken("$[0].extraProperties.Version").ToString());
            Assert.IsNotNull(result2.SelectToken("$[0].transactionIds[1]"));
        }
        
        [TearDown]
        public void TearDown()
        {
            TearDownAfterEachTest(typeof(TokenTestTests));
        }
    }
}