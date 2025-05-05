using NorthwindDAL.Context;
using NorthwindDAL.Repositories;

namespace NorthwindDAL.UnitOfWork;

public interface INorthwindUnitOfWork
{
    public IEmployeeRepository EmployeeRepository { get; }
}

public class NorthwindUnitOfWork : INorthwindUnitOfWork, IDisposable
{
    NorthwindContext _northwindContext;

    public NorthwindUnitOfWork(NorthwindContext northwindContext, IRepositoryFactory repositoryFactory)
    {     
        _northwindContext = northwindContext;
        EmployeeRepository = repositoryFactory.CreateEmployeeRepository(_northwindContext);
    }

    public IEmployeeRepository EmployeeRepository { get; }

    private bool _disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _northwindContext.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

