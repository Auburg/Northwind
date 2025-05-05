using FluentAssertions;
using Moq;
using NorthwindDAL.Models;
using NorthwindDAL.Repositories;
using NorthwindDAL.UnitOfWork;

namespace NorthwindTests
{
   
    public class GivenANorthwindUnitOfWork
    {
        private NorthwindUnitOfWork _sut;
        private IQueryable<Employee> TestEmployees;

        public GivenANorthwindUnitOfWork()
        {
            TestEmployees = new List<Employee> { new Employee()
            {
                FirstName = "Arthur",
                LastName = "Smith"
            } }.AsQueryable();

            var mockContext = new Mock<NorthwindDAL.Context.NorthwindContext>();
            var mockRepoFactory = new Mock<IRepositoryFactory>();
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            mockEmployeeRepo.SetupGet(x => x.Employees).Returns(TestEmployees);
            mockRepoFactory.Setup(m => m.CreateEmployeeRepository(It.IsAny<NorthwindDAL.Context.NorthwindContext>()))
                .Returns(mockEmployeeRepo.Object);

            _sut = new NorthwindUnitOfWork(mockContext.Object, mockRepoFactory.Object);
        }

        [Fact]
        public void WhenGetEmployeesIsCalled_TheExpectedEmployeesAreReturned()
        {
            _sut.EmployeeRepository.Employees.Should().BeEquivalentTo(TestEmployees);
        }
    }
}
