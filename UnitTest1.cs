using RestShatp;
using System.Net;

namespace AddbUC25
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
    }
    [TestMethod]
    public void DeleteUsingFirstName_OnDelete_ShouldReturnStatus()
    {
        RestRequest request = new RestRequest("/Person/Amit", Method.DELETE);

        IRestResponse response = client.Execute(request);
        Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        Console.WriteLine(response.Content);
    }
}