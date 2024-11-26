using AeIndexerTester;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CaseOne.App
{
    [TestFixture]
    public class OrganizationsTestTests : BaseTestSetup
    {
    
        [SetUp]
        public void Setup()
        {
            SetUpBeforeEachTest(typeof(OrganizationsTestTests));
            //makeBlocks("test001","tDVV",1,1,1);
        }
        
        [Test]
        [Description( "创建组织-组织已存在")]
        public void testOrganizationsExistName_Test()
        {
            JObject param = new JObject();
            
            //request
            param = JObject.Parse("{\"username\": \"admin1\",\"password\": \"1q2W3e*\",\"client_id\": \"AeFinder_App\",\"grant_type\": \"password\",\"scope\": \"AeFinder\"}");
            JObject result1 = HttpRequest.BaseUrl("http://192.168.71.156:8082").Path("/connect/token")
                                                    .ContentType("application/x-www-form-urlencoded")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result1.SelectToken("$.error"));
            Assert.IsNotNull(result1.SelectToken("$.error_description"));
            
            //request
            param = JObject.Parse("{\"displayName\": \"tnet00\"}");
            JObject result2 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/organizations")
                                                    .ContentType("application/json")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result2.SelectToken("$.error"));
        }
        
        [Test]
        [Description( "创建组织")]
        public void testOrganizationsErrorAuth_Test()
        {
            JObject param = new JObject();
            
            //request
            param = JObject.Parse("{\"displayName\": \"tnet00\"}");
            JObject result1 = HttpRequest.BaseUrl("http://192.168.71.156:8081").Path("/api/organizations")
                                                    .ContentType("application/json")
                                                    .Params(param).Exec(oneCaseDto).ToJObject();
            
            // Assert
            Assert.IsNotNull(result1.SelectToken("$.error"));
        }
        
        [TearDown]
        public void TearDown()
        {
            TearDownAfterEachTest(typeof(OrganizationsTestTests));
        }
    }
}