using AeIndexerTester;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CaseOne
{
    [TestFixture]
    public class TokenTestTests : BaseTestSetup
    {
        public static IEnumerable<Object[]?> GetData()
        {
            return GetDataProvider("TokenTestDataProvider.json"); 
        }
    
        [SetUp]
        public void Setup()
        {
            SetUpBeforeEachTest(typeof(TokenTestTests));
            //makeBlocks("test001","tDVV",1,1,1);
        }
        
        [Test, TestCaseSource(nameof(GetData))]
        [Description( "test001")]
        public void test001_Test(Dictionary<int, DataProviderObj> dictionary)
        {
            JObject jsResponse = new JObject();
            
            //request
            JObject result1 = HttpRequest.BaseUrl("http://192.168.71.128:8082").Path("/connect/token")
                                                    .ContentType("application/x-www-form-urlencoded")
                                                    .Params(dictionary[1].Params).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result1.SelectToken("$.access_token"));
            Assert.AreEqual(JObject.Parse(dictionary[1].Asserts.ToString())["$.token_type"].ToString(), result1.SelectToken("$.token_type").ToString());
            
            //request
            JArray result2 = HttpRequest.BaseUrl("http://192.168.71.128:8081").Path("/api/app/block/blocks")
                                        .ContentType("application/json")
                                        .Params(dictionary[2].Params).Exec(oneCaseDto).ToJArray();
            
            // Assert
            Assert.AreEqual(JObject.Parse(dictionary[2].Asserts.ToString())["$[0].id"].ToString(), result2.SelectToken("$[0].id").ToString());
            Assert.AreEqual(JObject.Parse(dictionary[2].Asserts.ToString())["$[0].extraProperties.Version"].ToString(), result2.SelectToken("$[0].extraProperties.Version").ToString());
            Assert.AreEqual(JObject.Parse(dictionary[2].Asserts.ToString())["$[0].transactionIds[1]"].ToString(), result2.SelectToken("$[0].transactionIds[1]").ToString());
        }
        
        [TearDown]
        public void TearDown()
        {
            TearDownAfterEachTest(typeof(TokenTestTests));
        }
    }
}