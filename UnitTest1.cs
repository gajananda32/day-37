using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

namespace RestSharpTest
{
    public class Employee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
    }
    [TestClass]
    public class UnitTest1
    {
        RestClient client;
        [TestInitialize]
        public void Setup()
        {
            client = new RestClient(
            "http://localhost:4000");
        }

        [TestMethod]
        public void OnlyCallingList_return_emloyeelist()
        {
            IRestResponse response = getEmloyeeList();
            Assert.AreEqual(response.StatusCode,HttpStatusCode.OK);
            List<Employee> dataResponse = JsonConvert.DeserializeObject<List<Employee>>(response.Content);
            Assert.AreEqual(2, dataResponse.Count);
            foreach (Employee e in dataResponse)
            {
                Console.WriteLine("id: " + e.id + " name: " + e.Name + " salary: " + e.Salary);
            }
        }
        private IRestResponse getEmloyeeList()
        {
            RestRequest request = new RestRequest("/emloyees", Method.GET);
            IRestResponse response = client.Execute(request);
            return response;
        }
        [TestMethod]
        public void givenEmployee_onpost_shold_returnEmployee()
        {
            RestRequest request = new RestRequest("/emlpoyees/2", Method.POST);
            JObject jobjectbody = new JObject();
            jobjectbody.Add("name", "Clark");
            jobjectbody.Add("Salary", 5000);
            request.AddParameter("application/json", jobjectbody, ParameterType.RequestBody);
            IRestResponse response=client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Employee dataresponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Clark", dataresponse.Name);
            Assert.AreEqual(5000, dataresponse.Salary);
            Console.WriteLine(response.Content);
        }
        [TestMethod]
        public void givenEmployee_onUpadate_shold_returnEmployee()
        {
            RestRequest request = new RestRequest("/emlpoyees/2", Method.PUT);
            JObject jobjectbody = new JObject();
            jobjectbody.Add("name", "Clark");
            jobjectbody.Add("Salary", 5000);
            request.AddParameter("application/json", jobjectbody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Employee dataresponse = JsonConvert.DeserializeObject<Employee>(response.Content);
            Assert.AreEqual("Clark", dataresponse.Name);
            Assert.AreEqual(5000, dataresponse.Salary);
            Console.WriteLine(response.Content);
        }
        [TestMethod]
        public void GevenEmloyeeID_OnDelete_ShouldReturnStatus()
        {
            RestRequest request = new RestRequest("/Emloyees/2", Method.DELETE);

            IRestResponse response = client.Execute(request);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Console.WriteLine(response.Content);
        }

    }
}