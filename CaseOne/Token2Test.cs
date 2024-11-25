using AeIndexerTester;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CaseOne
{
    [TestFixture]
    public class Token2TestTests : BaseTestSetup
    {
        [SetUp]
        public void Setup()
        {
            SetUpBeforeEachTest(TestContext.CurrentContext.Test.FullName);
            makeBlocks("test001","tDVV",1,1,1);
        }
        
        [Test]
        [Description( "test001")]
        public void test001_Test()
        {
            JObject param = new JObject();
            
            //request
            param = JObject.Parse("{\"username\": \"admin\",\"password\": \"1q2W3e*\",\"client_id\": \"AeFinder_App\",\"grant_type\": \"password\",\"scope\": \"AeFinder\"}");
            JObject result1 = HttpRequest.BaseUrl("http://192.168.71.128:8082").Path("/connect/token")
                                                    .ContentType("application/x-www-form-urlencoded")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result1.SelectToken("$.access_token"));
            Assert.AreEqual("Bearer", result1.SelectToken("$.token_type").ToString());
            
            //request
            param = JObject.Parse("{\"chainId\": \"AELF\",\"startBlockHeight\": 7000000,\"endBlockHeight\": 7000002,\"isOnlyConfirmed\": false}");
            JArray result2 = HttpRequest.BaseUrl("http://192.168.71.128:8081").Path("/api/app/block/blocks")
                                        .ContentType("application/json")
                                        .Params(param).Exec(oneCaseDto).ToJArray();
            
            // Assert
            Assert.AreEqual("ec815f4898d49c6a7e6cfd0747f53e69e53e0e7b371167241ee6285957b66340", result2.SelectToken("$[0].id").ToString());
            Assert.AreEqual("0", result2.SelectToken("$[0].extraProperties.Version").ToString());
            Assert.AreEqual("42ed60883588e53c2d11a035acf629c63f13e0a9f78a08a95575fb7b123046ea", result2.SelectToken("$[0].transactionIds[1]").ToString());
        }
    }
}