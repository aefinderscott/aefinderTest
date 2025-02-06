using AeIndexerTester;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CaseOne.Api
{
    [TestFixture]
    public class BlockTestTests : BaseTestSetup
    {
    
        [SetUp]
        public void Setup()
        {
            SetUpBeforeEachTest(typeof(BlockTestTests));
            //makeBlocks("test001","tDVV",1,1,1);
        }
        
        [Test]
        [Description( "block查询-正向")]
        public void testBlockQuery_Test()
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
            param = JObject.Parse("{\"chainId\": \"tDVV\",\"startBlockHeight\": 1,\"endBlockHeight\": 5,\"isOnlyConfirmed\": false}");
            JArray result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/app/block/blocks")
                                        .ContentType("application/json")
                                        .Params(param).Exec(oneCaseDto).ToJArray();
            
            // Assert
            Assert.IsNotNull(result2.SelectToken("$[0].id"));
            Assert.AreEqual("tDVV", result2.SelectToken("$[0].chainId").ToString());
        }
        
        [Test]
        [Description( "block查询-confirm")]
        public void testBlockQueryConfirm_Test()
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
            param = JObject.Parse("{\"chainId\": \"tDVV\",\"startBlockHeight\": 1,\"endBlockHeight\": 5,\"isOnlyConfirmed\": true}");
            JArray result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/app/block/blocks")
                                        .ContentType("application/json")
                                        .Params(param).Exec(oneCaseDto).ToJArray();
            
            // Assert
            Assert.AreEqual("[]", result2.SelectToken("$").ToString());
        }
        
        [Test]
        [Description( "block查询-start>end")]
        public void testBlockQuerySgtE_Test()
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
            param = JObject.Parse("{\"chainId\": \"tDVV\",\"startBlockHeight\": 11,\"endBlockHeight\": 5,\"isOnlyConfirmed\": false}");
            JArray result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/app/block/blocks")
                                        .ContentType("application/json")
                                        .Params(param).Exec(oneCaseDto).ToJArray();
            
            // Assert
            Assert.AreEqual("[]", result2.SelectToken("$").ToString());
        }
        
        [Test]
        [Description( "block查询-startBlockHeight")]
        public void testBlockQueryNoStart_Test()
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
            param = JObject.Parse("{\"chainId\": \"tDVV\",\"endBlockHeight\": 5,\"isOnlyConfirmed\": false}");
            JObject result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/app/block/blocks")
                                                    .ContentType("application/json")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result2.SelectToken("$.error.message"));
        }
        
        [Test]
        [Description( "block查询-NoEnd")]
        public void testBlockQueryNoEnd_Test()
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
            param = JObject.Parse("{\"chainId\": \"tDVV\",\"startBlockHeight\": 1,\"isOnlyConfirmed\": false}");
            JObject result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/app/block/blocks")
                                                    .ContentType("application/json")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result2.SelectToken("$[0].transactionId"));
            Assert.AreEqual("tDVV", result2.SelectToken("$[0].chainId").ToString());
        }
        
        [Test]
        [Description( "block查询-WrongChainId")]
        public void testBlockQueryWrongChainId_Test()
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
            param = JObject.Parse("{\"chainId\": \"tDVV1\",\"startBlockHeight\": 1,\"endBlockHeight\": 5,\"isOnlyConfirmed\": false}");
            JArray result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/app/block/blocks")
                                        .ContentType("application/json")
                                        .Params(param).Exec(oneCaseDto).ToJArray();
            
            // Assert
            Assert.AreEqual("[]", result2.SelectToken("$").ToString());
        }
        
        [Test]
        [Description( "block查询-StartNotExist")]
        public void testBlockQueryStartNotExist_Test()
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
            param = JObject.Parse("{\"chainId\": \"tDVV\",\"startBlockHeight\": 100000,\"endBlockHeight\": 500000000,\"isOnlyConfirmed\": false}");
            JArray result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/app/block/blocks")
                                        .ContentType("application/json")
                                        .Params(param).Exec(oneCaseDto).ToJArray();
            
            // Assert
            Assert.AreEqual("[]", result2.SelectToken("$").ToString());
        }
        
        [TearDown]
        public void TearDown()
        {
            TearDownAfterEachTest(typeof(BlockTestTests));
        }
    }
}