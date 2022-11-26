using EmployeePayRoll;
using System.Security.Cryptography.X509Certificates;

namespace EmployeePayRollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given10Employee_WhenAdded_toList_ShouldMatchEmployee_Entries()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            employeeDetails.Add(new EmployeeDetails(emloyeeId: 1, employeeName: "Abhishek", phonenumber: "7894561230"));
            employeeDetails.Add(new EmployeeDetails(emloyeeId: 2, employeeName: "Jhon", phonenumber: "7894561230"));
            employeeDetails.Add(new EmployeeDetails(emloyeeId: 3, employeeName: "Peter", phonenumber: "7894561230"));
            employeeDetails.Add(new EmployeeDetails(emloyeeId: 4, employeeName: "Tony", phonenumber: "7894561230"));
            employeeDetails.Add(new EmployeeDetails(emloyeeId: 5, employeeName: "Stark", phonenumber: "7894561230"));
            employeeDetails.Add(new EmployeeDetails(emloyeeId: 6, employeeName: "kent", phonenumber: "7894561230"));
            employeeDetails.Add(new EmployeeDetails(emloyeeId: 7, employeeName: "joe", phonenumber: "7894561230"));
            employeeDetails.Add(new EmployeeDetails(emloyeeId: 8, employeeName: "Roy", phonenumber: "7894561230"));
            employeeDetails.Add(new EmployeeDetails(emloyeeId: 9, employeeName: "Chunnu", phonenumber: "7894561230"));
            employeeDetails.Add(new EmployeeDetails(emloyeeId: 10, employeeName: "Munnu", phonenumber: "7894561230"));
            EmployeePayRollOperation employeePayRollOperation = new EmployeePayRollOperation();
            // employeePayRollOperation.addEmployeeToPayRoll(employeeDetails);
            DateTime startDateTime = DateTime.Now;
            employeePayRollOperation.addEmployeeToPayRoll(employeeDetails);
            DateTime stopDateTime = DateTime.Now;
            Console.WriteLine("Duration without thread: " + (stopDateTime - stopDateTime));

            DateTime startDateTimeThread = DateTime.Now;
            employeePayRollOperation.addEmloyeeToPayrollWithThread(employeeDetails);
            DateTime stopDateTimeThread = DateTime.Now;
            Console.WriteLine("Duration with thread: " + (stopDateTimeThread - stopDateTimeThread));
        }                    }
    }
}