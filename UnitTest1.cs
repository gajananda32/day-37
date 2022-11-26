using RestSharp;
namespace AddbUC24
{
    public class Pesrson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public string PhoneNumber { get; set; }
        public string email { get; set; }

    }
    [TestClass]
    public class UnitTest1
    {
        RestClient client;
        [TestInitialize]
        public void Setup()
        {
            client = new RestClient(
            "http://localhost:3000");
        }
        [TestMethod]
        public void Addperson_onUpdate_shold_returnPerson()
        {
            RestRequest request = new RestRequest("/Person/LastName", Method.PUT);
            JObject jobjectbody = new JObject();
            jobjectbody.Add("FirstName", "Anirudh");
            jobjectbody.Add("LastName", "kumar");
            jobjectbody.Add("Address", "shivagi nagar");
            jobjectbody.Add("city", "Bengaluru");
            jobjectbody.Add("state", "Karnataka");
            jobjectbody.Add("zip", 500059);
            jobjectbody.Add("PhoneNumber", "785412359");
            jobjectbody.Add("Email", "ani@gmail.com");
            request.AddParameter("application/json", jobjectbody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Pesrson dataresponse = JsonConvert.DeserializeObject<Pesrson>(response.Content);
            Assert.AreEqual("Anirudh", dataresponse.FirstName);
            Assert.AreEqual("kumar", dataresponse.LastName);
            Assert.AreEqual("shivagi nagar", dataresponse.Address);
            Assert.AreEqual("Bengaluru", dataresponse.city);
            Assert.AreEqual("Karnataka", dataresponse.state);
            Assert.AreEqual(500059, dataresponse.zip);
            Assert.AreEqual("785412359", dataresponse.PhoneNumber);
            Assert.AreEqual("ani@gmail.com", dataresponse.email);
            Console.WriteLine(response.Content);
        }
    }
}