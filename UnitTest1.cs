using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace AddbUC22
{ 
    public class Pesrson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address{ get; set; }
        public string city { get; set; }
        public string state{ get; set; }
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
        public void OnlyCallingList_return_Personlist()
        {
            IRestResponse response = getPersonList();
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Pesrson> dataResponse = JsonConvert.DeserializeObject<List<Pesrson>>(response.Content);
            Assert.AreEqual(2, dataResponse.Count);
            foreach (Pesrson e in dataResponse)
            {
                Console.WriteLine("FirstName: " + e.FirstName  + " LastName: " + e.LastName + " Address: " + e.Address +" City: "+e.city +" State: "+e.state +" zip: "+e.zip +" PhoneNumber: "+e.PhoneNumber +" Email: "+e.email );
            }
        }
        private IRestResponse getPersonList()
        {
            RestRequest request = new RestRequest("/Person", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
    }
}