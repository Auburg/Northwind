using NorthwindDAL.Context;
using NorthwindDAL.Repositories;

namespace NorthwindDAL.UnitOfWork;

public interface IRepositoryFactory
{
    public IEmployeeRepository CreateEmployeeRepository(NorthwindContext context);
}

public class RepositoryFactory : IRepositoryFactory
{
    public IEmployeeRepository CreateEmployeeRepository(NorthwindContext context)
    {
        return new EmployeeRepository(context);
    }
}
