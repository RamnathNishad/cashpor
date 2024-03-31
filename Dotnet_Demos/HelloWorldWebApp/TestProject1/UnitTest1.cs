using EmployeeLib;
using Moq;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetBonusSalaryGt5K()
        {
            //A--Arrange : To carry out the test arrange the details
            int salary = 7000;
            Employee emp = new Employee();

            //A--Act : We call the method to get the result
            double actualBonus = emp.GeBonus(salary);

            //A--Assert : We validate the actual with expected result
            Assert.AreEqual(700, actualBonus);

        }

        [Test]
        public void TestGetBonusSalaryLt5K()
        {
            //A--Arrange : To carry out the test arrange the details
            int salary = 4000;
            Employee emp = new Employee();

            //A--Act : We call the method to get the result
            double actualBonus = emp.GeBonus(salary);

            //A--Assert : We validate the actual with expected result
            Assert.AreEqual(800, actualBonus);
        }

        [Test]
        public void TestGetBonusSalaryEqualTo5K()
        {
            //A--Arrange : To carry out the test arrange the details
            int salary = 5000;
            Employee emp = new Employee();

            //A--Act : We call the method to get the result
            double actualBonus = emp.GeBonus(salary);

            //A--Assert : We validate the actual with expected result
            Assert.AreEqual(1000, actualBonus);
        }

        [Test]
        public void Test1()
        {
            Mock<Employee> empMock = new Mock<Employee>();
            empMock.Setup(e => e.GeBonus(7000)).Returns(700);

            var emp = empMock.Object;

            var actualBonus = emp.GeBonus(7000);

            Assert.AreEqual(700, actualBonus);
        }
    }
}