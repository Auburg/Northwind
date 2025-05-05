using NorthwindDAL.Context;
using NorthwindDAL.Models;

namespace NorthwindDAL.Repositories;

public interface IEmployeeRepository
{
    IQueryable<Employee> Employees { get; }

    IQueryable<Employee> GetEmployees(int afterId, int count);
}

public class EmployeeRepository(NorthwindContext northwindContext) : IEmployeeRepository
{
    public IQueryable<Employee> Employees => northwindContext.Employees;

    public IQueryable<Employee> GetEmployees(int afterId, int count)
    {
        return northwindContext.Employees
            .OrderBy(e=>e.EmployeeId)
            .Where(e => e.EmployeeId>afterId)
            .Take(count);
    }
}
